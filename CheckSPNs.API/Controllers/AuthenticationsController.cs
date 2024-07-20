using CheckSPNs.API.Base;
using CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Commands.Models;
using CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Queries.Models;
using CheckSPNs.Service.EF.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : AppControllerBase
    {
        public AuthenticationsController(ISender sender, ITokenService tokenService) : base(sender)
        {
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromBody] LoginQuery query)
        {
            var result = await Sender.Send(query);
            if (result.IsFailure)
            {
                return HandlerFailure(result);
            }
            return Ok(result);
        }

        [HttpPost("/refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] TokenQuery query)
        {
            var result = await Sender.Send(query);
            if (result.IsFailure)
            {
                return HandlerFailure(result);
            }
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("/confirm-email")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] ConfirmEmailCommand command)
        {
            var response = await Sender.Send(command);
            return Ok(response);
        }

    }
}
