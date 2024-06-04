using Azure.Identity;
using DL___Web_Api.Filters;
using DL___Web_Api.Model.ViewModels;
using DL___Web_Api.TokenAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace DL___Web_Api.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    //[TokenAuthenticationFilter]
    public class AuthenticateController : ControllerBase
    {
        private ITokenManager tokenManager;
        
        public AuthenticateController(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }

        //public IActionResult Authenticate(string user,string pwd)
        //{
        //    if (tokenManager.Authenticate(user,pwd)) 
        //    {
        //        return Ok(new { Token = tokenManager.NewToken() });
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("Unauthorized", "You are not Unauthorized.");
        //        return Unauthorized(ModelState);
        //    }
        //}
        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginVM login)
        {

            if( tokenManager.Authenticate(login.Username, login.Password))
            {
                return Ok(new { Token = tokenManager.NewToken(login.Username,login.IsRememberMe) });
            }
            else
            {
                ModelState.AddModelError("Unauthorized", "You are not Unauthorized.");
                return Unauthorized(ModelState);
            }
        }
    }
}
