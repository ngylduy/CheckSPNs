using CheckSPNs.API.Base;
using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Data.EF.Context;
using CheckSPNs.Service.MongoDb.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MongoDB.AspNetCore.OData;

namespace CheckSPNs.API.Controllers.OData
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamScoreODataController : OdataControllerBase
    {
        private readonly IExamScoreService _examScoreService;
        private readonly CheckSPNsContext _checkSPNsContext;
        private readonly IDapperHelper _dapperHelper;

        public ExamScoreODataController(IExamScoreService examScoreService,
            CheckSPNsContext checkSPNsContext,
            IDapperHelper dapperHelper)
        {
            _examScoreService = examScoreService;
            _checkSPNsContext = checkSPNsContext;
            _dapperHelper = dapperHelper;
        }

        [HttpGet]
        [MongoEnableQuery]
        public IActionResult Get()
        {
            var result = _examScoreService.GetExamScore();
            return Ok(result);
        }

        [HttpGet("/demo")]
        public async Task<IActionResult> GetDemo()
        {

            var phoneNumbersWithLatestReport = await _checkSPNsContext.PhoneNumbers
            .Select(pn => new
            {
                PhoneNumber = pn.PhoneNumber,
                LatestReport = pn.Reports.OrderByDescending(r => r.ReportDate).FirstOrDefault(),
                ReportCount = pn.Reports.Count
            })
            .Where(x => x.LatestReport != null).OrderByDescending(x => x.LatestReport.ReportDate).ToListAsync();


            //var result = await _dapperHelper.ExecuteSqlReturnListAsync<(string PhoneNumber, string LatestReport, int ReportCount)>("" +
            //    "SELECT " +
            //    "    pn.PhoneNumber," +
            //    "    (SELECT TOP 1 r.Comment " +
            //    "     FROM Reports r " +
            //    "     WHERE r.PhoneNumberId = pn.Id " +
            //    "     ORDER BY r.ReportDate DESC) AS LatestReport," +
            //    "    (SELECT COUNT(*) " +
            //    "     FROM Reports r " +
            //    "     WHERE r.PhoneNumberId = pn.Id) AS ReportCount" +
            //    "FROM " +
            //    "    PhoneNumbers pn" +
            //    "WHERE " +
            //    "    EXISTS (SELECT 1 " +
            //    "            FROM Reports r " +
            //    "            WHERE r.PhoneNumberId = pn.Id)" +
            //    "ORDER BY " +
            //    "    LatestReport DESC;");

            return Ok(phoneNumbersWithLatestReport);
        }
    }
}
