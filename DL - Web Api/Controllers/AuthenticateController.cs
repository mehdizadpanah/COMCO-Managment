using DL___Web_Api.Migrations;
using DL___Web_Api.TokenAuthentication;
using Microsoft.AspNetCore.Mvc;
using SH.Data.ModelVM.Authentication;
using DL___Web_Api.Model.Models;
using DL___Web_Api.Data;

namespace DL___Web_Api.Controllers
{

    [Route("[controller]")]
    [ApiController]
    //[TokenAuthenticationFilter]
    public class AuthenticateController : ControllerBase
    {
        private ITokenManager tokenManager;
        private ComcoMContext _context;
        
        public AuthenticateController(ITokenManager tokenManager,ComcoMContext context)
        {
            this.tokenManager = tokenManager;
            _context = context;
        }

      
        [HttpPost]

        public async Task<IActionResult> Authenticate([FromBody] LoginRequestVM login)
        {
            
            if ( tokenManager.Authenticate(login.Username, login.Password))
            {
                var token = await tokenManager.NewToken(login.Username, login.IsRememberMe);
                var session = new Session();
                session.TokenID = token.Token;
                session.IP = HttpContext.Connection.RemoteIpAddress?.ToString(); 
                session.brInfo = HttpContext.Request.Headers["User-Agent"].ToString();
                session.ExpiryDate = token.ExpiryDate;
                session.UserName = token.UserName;
                _context.Sessions.Add(session); 
                await _context.SaveChangesAsync();  

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
