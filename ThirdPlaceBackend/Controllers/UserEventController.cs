using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ThirdPlaceBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserEventController : ControllerBase
    {
        [HttpGet]
        public String HelloWorld()
        {
            return "Hello world";
        }
    }
}
