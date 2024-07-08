using CheckSPNs.API.Base;
using CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Commands.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : AppControllerBase
    {

        public UsersController(ISender sender) : base(sender)
        {
        }

        [HttpPost("/create-user")]
        public async Task<IActionResult> Create([FromBody] AddUserCommand command)
        {
            var response = await Sender.Send(command);
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }
    }
}
