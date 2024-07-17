using CheckSPNs.API.Base;
using CheckSPNs.Infrastructure.Features.StatsFeatures.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Controllers.Mediatr
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatsController : AppControllerBase
    {
        public StatsController(ISender sender) : base(sender)
        {
        }

        [HttpGet("stat-phone-number-by-status")]
        public async Task<IActionResult> Get()
        {
            var result = await Sender.Send(new GetPhoneNumberStatByStatusQuery());
            return Ok(result);
        }

        [HttpGet("stat-report-by-time")]
        public async Task<IActionResult> Get([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var result = await Sender.Send(new GetReportStatByTimeQuery(from, to));
            return Ok(result);
        }

        [HttpGet("top-view")]
        public async Task<IActionResult> GetTopView(int pageIndex = 1, int pageSize = 10)
        {
            var result = await Sender.Send(new GetPhoneNumberTopViewQuery(pageIndex, pageSize));
            return Ok(result);
        }

        [HttpGet("top-report")]
        public async Task<IActionResult> GetTopReport(int pageIndex = 1, int pageSize = 10)
        {
            var result = await Sender.Send(new GetPhoneNumberTopReportQuery(pageIndex, pageSize));
            return Ok(result);
        }

        [HttpGet("system-stat")]
        public async Task<IActionResult> GetSystemStat()
        {
            var result = await Sender.Send(new GetSystemStatQuery());
            return Ok(result);
        }
    }
}
