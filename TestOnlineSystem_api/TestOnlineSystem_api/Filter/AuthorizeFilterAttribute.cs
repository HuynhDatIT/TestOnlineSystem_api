using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;

namespace Mini_project_API.Filter
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeFilterAttribute : Attribute, IAuthorizationFilter
    {
        private string _role;

        public AuthorizeFilterAttribute(string role)
        {
            _role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.Items["Role"];
            if (user == null)
            {
                context.Result = new JsonResult(new
                { message = "Not login" })
                { StatusCode = StatusCodes.Status401Unauthorized };
            }
            else if(_role != user.ToString())
            {
                context.Result = new JsonResult(new
                { message = "UnAthorization" })
                { StatusCode = StatusCodes.Status401Unauthorized };
            }
           
        }
    }
}
