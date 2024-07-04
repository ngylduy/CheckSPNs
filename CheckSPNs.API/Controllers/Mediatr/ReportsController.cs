using CheckSPNs.API.Base;
using CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Controllers.Mediatr
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : AppControllerBase
    {
        public ReportsController(ISender sender) : base(sender)
        {
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get(Guid Id)
        {
            var result = await Sender.Send(new GetListReportByPhoneNumberQuery(Id));
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> Get(int pageIndex = 1, int pageSize = 10)
        {
            var result = await Sender.Send(new GetListReportQuery(pageIndex, pageSize));
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddReportCommand command)
        {
            var result = await Sender.Send(command);
            if (result.IsFailure)
            {
                return HandlerFailure(result);
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EditReportCommand command)
        {
            var result = await Sender.Send(command);
            if (result.IsFailure)
            {
                return HandlerFailure(result);
            }
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await Sender.Send(new DeleteReportCommand(id));
            if (result.IsFailure)
            {
                return HandlerFailure(result);
            }
            return Ok(result);
        }
    }
}
