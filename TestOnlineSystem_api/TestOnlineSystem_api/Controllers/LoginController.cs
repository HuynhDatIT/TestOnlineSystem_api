using Microsoft.AspNetCore.Mvc;
using Mini_project_API.Interface.IService;
using Mini_project_API.ViewModel;
using Mini_project_API.ViewModel.Request;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Mini_project_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;
        private readonly IRegisterService _registerService;
        public LoginController(ILoginService loginService, IRegisterService registerService)
        {
            this._loginService = loginService;
            this._registerService = registerService; 
        }


        // POST api/<LoginController>
        [HttpPost("Login")]
        public Tokens Login([FromBody] LoginViewModel loginView)
        {
           var token = _loginService.Authentica(loginView);
           
            return token;
        }
        // POST api/<LoginController>
        [HttpPost("Register")]
        public async Task Register([FromBody] CreateAccount createAccount)
        {
           await _registerService.RegisterAsync(createAccount);
        }
       

    }
}
