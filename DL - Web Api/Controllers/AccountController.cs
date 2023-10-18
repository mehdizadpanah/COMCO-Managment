using DL___Web_Api.Filters;
using DL___Web_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace DL___Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        //[HttpGet]
        //public Boolean  Get(int id)
        //{
        //    return (_accountService.GetAccountById(id));
           
        //}
        [HttpGet]
        public Boolean Validate(string username,string password)
        {
            return (_accountService.ValidateUser(username,password));
        }
    }
}
