using DL___Web_Api.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;
using SH.Data.ModelVM.Authentication;

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

      
        [HttpPost]

        public async Task<IActionResult> Authenticate([FromBody] LoginRequestVM login)
        {
            var ip = HttpContext.Connection.RemoteIpAddress?.ToString();
            var brInfo = HttpContext.Request.Headers["User-Agent"].ToString();
            if ( tokenManager.Authenticate(login.Username, login.Password))
            {
                var token = await tokenManager.NewToken(login.Username, login.IsRememberMe);
                return Ok(token);
            }
            else
            {
                ModelState.AddModelError("Unauthorized", "You are not Unauthorized.");
                return Unauthorized(ModelState);
            }
        }
    }
}
