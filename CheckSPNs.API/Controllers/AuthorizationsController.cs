using CheckSPNs.API.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Core.Features.Authorization.Commands.Models;
using SchoolProject.Core.Features.Authorization.Quaries.Models;

namespace CheckSPNs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationsController : AppControllerBase
    {
        public AuthorizationsController(ISender sender) : base(sender)
        {
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("Roles/Create")]
        public async Task<IActionResult> Create([FromForm] AddRoleCommand command)
        {
            var response = await Sender.Send(command);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Roles/Update")]
        public async Task<IActionResult> Edit([FromForm] EditRoleCommand command)
        {
            var response = await Sender.Send(command);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Roles/Delete/{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var response = await Sender.Send(new DeleteRoleCommand(id));
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Roles/List")]
        public async Task<IActionResult> GetRoleList()
        {
            var response = await Sender.Send(new GetRolesListQuery());
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Roles/Get-By-Id/{id}")]
        public async Task<IActionResult> GetRoleById([FromRoute] Guid id)
        {
            var response = await Sender.Send(new GetRoleByIdQuery() { Id = id });
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Roles/Manage-User-Role/{userId}")]
        public async Task<IActionResult> ManageUserRoles([FromRoute] Guid userId)
        {
            var response = await Sender.Send(new ManageUserRolesQuery() { UserId = userId });
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Roles/Update-User-Role")]
        public async Task<IActionResult> UpdateUserRoles([FromBody] UpdateUserRolesCommand command)
        {
            var response = await Sender.Send(command);
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Claims/Manage-User-Claim/{userId}")]
        public async Task<IActionResult> ManageUserClaims([FromRoute] Guid userId)
        {
            var response = await Sender.Send(new ManageUserClaimsQuery() { UserId = userId });
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("Claims/Update-User-Claim")]
        public async Task<IActionResult> UpdateUserClaims([FromBody] UpdateUserClaimsCommand command)
        {
            var response = await Sender.Send(command);
            return Ok(response);
        }
    }
}
