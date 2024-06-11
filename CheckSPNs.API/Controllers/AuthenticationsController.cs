using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        [HttpGet("login")]
        public IActionResult Get()
        {
            return Ok("Hello World");
        }

    }
}
