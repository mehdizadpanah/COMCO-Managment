using DL___Web_Api.Filters;
using DL___Web_Api.TokenAuthentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DL___Web_Api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    //[TokenAuthenticationFilter]
    public class AuthenticateController : ControllerBase
    {
        private ITokenManager tokenManager;
        
        public AuthenticateController(ITokenManager tokenManager)
        {
            this.tokenManager = tokenManager;
        }
        [HttpGet]
        public IActionResult Authenticate(string user,string pwd)
        {
            if (tokenManager.Authenticate(user,pwd)) 
            {
                return Ok(new { Token = tokenManager.NewToken() });
            }
            else
            {
                ModelState.AddModelError("Unauthorized", "You are not Unauthorized.");
                return Unauthorized(ModelState);
            }
        }
    }
}
