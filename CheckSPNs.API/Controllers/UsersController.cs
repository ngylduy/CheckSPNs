using CheckSPNs.API.Base;
using CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Commands.Models;
using CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Queries.Models;
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

        [HttpGet("list-users")]
        public async Task<IActionResult> GetListUsers(int pageIndex = 1, int pageSize = 10)
        {
            var response = await Sender.Send(new GetListUserQuery(pageIndex, pageSize));
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }

        [HttpGet("get-user/{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            var response = await Sender.Send(new GetUserByIdQuery(id));
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }
    }
}
