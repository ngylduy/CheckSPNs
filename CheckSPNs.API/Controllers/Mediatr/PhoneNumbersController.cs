using CheckSPNs.API.Base;
using CheckSPNs.Domain.Exceptions;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models;
using MediatR;
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
        public async Task<IActionResult> Get()
        {
            var response = await Sender.Send(new GetPhoneNumberListQuery());
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
        public async Task<IActionResult> AddOverallReport([FromQuery] AddOverallReportPhoneNumberCommand command)
        {
            var response = await Sender.Send(command);
            if (response.IsFailure)
            {
                return HandlerFailure(response);
            }
            return Ok(response);
        }

        [HttpPost("/add-type-of-report")]
        public async Task<IActionResult> AddTypeOfReport([FromQuery] AddPhoneNumberTypeOfReportCommand command)
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
                throw new PhoneNumberNotFoundException(id);
            }
            return Ok(response);
        }
    }
}
