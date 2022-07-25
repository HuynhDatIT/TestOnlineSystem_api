using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_project_API.Filter
{
    public class AuthorizationMiddleware
    {

        private readonly RequestDelegate _next;
        private readonly IConfiguration _config;
        public AuthorizationMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _config = config;
        }
        public async Task Invoke(HttpContext context)
        {
            var token = context.Request.Headers["Authorization"]
                .ToString().Replace("Bearer ", "");
            if (token != null && token != "")
            {
                ValidateJwtToken(context, token);
            }
            await _next(context);
        }
        public void ValidateJwtToken(HttpContext context, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_config["JWT:Key"]);
            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);
                var jwtToken = (JwtSecurityToken)validatedToken;
                var role = jwtToken.Claims.FirstOrDefault(x => x.Type == "role").Value;
                context.Items["Role"] = role;
            }
            catch
            {
                _next(context);
            }
        }
    }
}

