using CheckSPNs.API.Base;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Controllers.Mediatr
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneNumbersController : AppControllerBase
    {
        public PhoneNumbersController(ISender sender) : base(sender)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get(int pageIndex = 1, int pageSize = 10)
        {
            var response = await Sender.Send(new GetPhoneNumberListQuery(pageIndex, pageSize));
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ReportPhoneNumberCommand command)
        {
            var response = await Sender.Send(command);
            //if (response.IsFailure)
            //{
            //    return HandlerFailure(response);
            //}
            return Ok(response);
        }

        [HttpPost("/add-report-status")]
        public async Task<IActionResult> AddOverallReport([FromBody] AddOverallReportPhoneNumberCommand command)
        {
            var response = await Sender.Send(command);
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }

        [HttpPost("/add-type-of-report")]
        public async Task<IActionResult> AddTypeOfReport([FromBody] AddPhoneNumberTypeOfReportCommand command)
        {
            var response = await Sender.Send(command);
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }

        [HttpGet("/prefix")]
        public async Task<IActionResult> GetPrefix()
        {
            var response = await Sender.Send(new GetPhoneNumberPrefixQuery());
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] EditPhoneNumberCommand command)
        {
            var response = await Sender.Send(command);
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await Sender.Send(new DeletePhoneNumberCommand(id));
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }

        [HttpGet("/recent-report")]
        public async Task<IActionResult> GetRecentReport(int pageIndex = 1, int pageSize = 10)
        {
            var response = await Sender.Send(new GetRecentReportPhoneNumberQuery(pageIndex, pageSize));
            return Ok(response);
        }

        [HttpGet("/recent-report-by-type")]
        public async Task<IActionResult> GetRecentReportByType(Guid typeOfReport, int pageIndex = 1, int pageSize = 10)
        {
            var response = await Sender.Send(
                new GetRecentReportPhoneNumberByTypeQuery(pageIndex, pageSize, typeOfReport)
            );
            return Ok(response);
        }

        [HttpGet("{number}")]
        public async Task<IActionResult> GetInfoByPhoneNumber(string number)
        {
            var response = await Sender.Send(new GetPhoneNumberQuery(number));
            return Ok(response);
        }
    }
}
