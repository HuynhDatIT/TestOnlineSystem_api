using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Mini_project_API.Helper;
using Mini_project_API.Interface;
using Mini_project_API.Interface.IService;
using Mini_project_API.Models;
using Mini_project_API.ViewModel;
using Mini_project_API.ViewModel.Request;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Mini_project_API.Service
{
    public class LoginService : ILoginService
    {
        private readonly IConfiguration iconfiguration;

        private readonly IUnitOfWork unitOfWork;

        public LoginService(IConfiguration iconfiguration, IUnitOfWork unitOfWork)
        {
            this.iconfiguration = iconfiguration;
            this.unitOfWork = unitOfWork;
        }

        public Tokens Authentica(LoginViewModel loginViewModel)
        {
            var account = unitOfWork.AccountRepository.Authentication(loginViewModel);
            if ( account == null)
            {
                return new Tokens
                {
                    Messege = "Fail",
                    Token = null
                };
            }
            else
            {
                return new Tokens
                {
                    Messege = "Success",
                    Token = GeneraToken(account)
                };
            }
        }

        

        private string GeneraToken(Account account)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
             new Claim(ClaimTypes.Name, account.Username),
             new Claim(ClaimTypes.Role, account.Role.Name)

              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(
                                        new SymmetricSecurityKey(tokenKey), 
                                            SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            var tokenstring = tokenHandler.WriteToken(token);
            
            return tokenstring;
        }


    }
}
