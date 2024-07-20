using CheckSPNs.API.Base;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Controllers.Mediatr
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypeOfReportsController : AppControllerBase
    {
        public TypeOfReportsController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await Sender.Send(new GetTypeOfReportListQuery());
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTypeOfReportCommand command)
        {
            var response = await Sender.Send(command);
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EditTypeOfReportCommand command)
        {
            var response = await Sender.Send(command);
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await Sender.Send(new DeleteTypeOfReportCommand(id));
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }

    }
}
