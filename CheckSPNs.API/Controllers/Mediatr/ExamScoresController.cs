using CheckSPNs.API.Base;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Commands.Models;
using CheckSPNs.Infrastructure.Features.ExamScoreFeatures.Queries.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Controllers.Mediatr
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamScoresController : AppControllerBase
    {
        public ExamScoresController(ISender sender) : base(sender)
        {
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetScoreById(string id)
        {
            var result = await Sender.Send(new GetExamScoreByIDQuery(id));
            return Ok(result);
        }

        [HttpPost("import")]
        public async Task<IActionResult> ImportCsv(IFormFile file)
        {
            var result = await Sender.Send(new ImportFileScoreCommand(file));
            return Ok(result);
        }

        [HttpPost("import-province")]
        public async Task<IActionResult> ImportProvince(IFormFile file)
        {
            var result = await Sender.Send(new ImportFileProvinceCommand(file));
            return Ok(result);
        }
    }
}
