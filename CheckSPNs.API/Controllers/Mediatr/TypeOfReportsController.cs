using CheckSPNs.API.Base;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Models;
using MediatR;
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

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTypeOfReportCommand command)
        {
            var response = await Sender.Send(command);
            return Ok(response);
        }

    }
}
