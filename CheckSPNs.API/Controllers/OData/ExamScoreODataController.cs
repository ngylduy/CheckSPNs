using CheckSPNs.API.Base;
using CheckSPNs.Service.MongoDb.Abstract;
using Microsoft.AspNetCore.Mvc;
using MongoDB.AspNetCore.OData;

namespace CheckSPNs.API.Controllers.OData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamScoreODataController : OdataControllerBase
    {
        private readonly IExamScoreService _examScoreService;

        public ExamScoreODataController(IExamScoreService examScoreService)
        {
            _examScoreService = examScoreService;
        }

        [HttpGet]
        [MongoEnableQuery]
        public IActionResult Get()
        {
            var result = _examScoreService.GetExamScore();
            return Ok(result);
        }
    }
}
