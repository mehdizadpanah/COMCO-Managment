using Microsoft.AspNetCore.Mvc;

namespace DL___Web_Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Sanam : ControllerBase
    {
        [HttpGet(Name = "GetSanam")]
        public String Get(string ali)
        {
            return ali + "Goft Sanam Fahmidi???";
        }
    }
};

    
