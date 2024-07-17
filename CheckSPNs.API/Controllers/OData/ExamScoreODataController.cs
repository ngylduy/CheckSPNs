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

            var positive = await _checkSPNsContext.PhoneNumbers
            .Where(x => x.PositiveReportsCount > x.NegativeReportsCount).CountAsync();

            var negative = await _checkSPNsContext.PhoneNumbers
            .Where(x => x.PositiveReportsCount < x.NegativeReportsCount).CountAsync();

            var neutral = await _checkSPNsContext.PhoneNumbers
            .Where(x => x.PositiveReportsCount == x.NegativeReportsCount).CountAsync();

            var total = await _checkSPNsContext.PhoneNumbers.CountAsync();

            return Ok(new
            {
                Positive = positive,
                Negative = negative,
                Neutral = neutral,
                PositivePercent = Math.Round(((double)positive / total) * 100, 2),
                NegativePercent = Math.Round(((double)negative / total) * 100, 2),
                NeutralPercent = Math.Round(((double)neutral / total) * 100, 2),
                Total = total
            });
        }

        [HttpGet("weekly")]
        public IActionResult GetWeeklyStatistics()
        {
            var today = DateTime.Today;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);

            var weeklyStats = _checkSPNsContext.Reports
                .Where(r => r.ReportDate >= startOfWeek)
                .GroupBy(r => r.ReportDate.Date)
                .Select(group => new
                {
                    Date = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return Ok(weeklyStats);
        }

        [HttpGet("monthly")]
        public IActionResult GetMonthlyStatistics()
        {
            var today = DateTime.Today;
            var startOfMonth = new DateTime(today.Year, today.Month, 1);

            var monthlyStats = _checkSPNsContext.Reports
                .Where(r => r.ReportDate >= startOfMonth)
                .GroupBy(r => r.ReportDate.Date)
                .Select(group => new
                {
                    Date = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return Ok(monthlyStats);
        }

        [HttpGet("lastMonth")]
        public IActionResult GetLastMonthStatistics()
        {
            var today = DateTime.Today;
            var startOfLastMonth = new DateTime(today.Year, today.Month - 1, 1);
            var endOfLastMonth = startOfLastMonth.AddMonths(1).AddDays(-1);

            var lastMonthStats = _checkSPNsContext.Reports
                .Where(r => r.ReportDate >= startOfLastMonth && r.ReportDate <= endOfLastMonth)
                .GroupBy(r => r.ReportDate.Date)
                .Select(group => new
                {
                    Date = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return Ok(lastMonthStats);
        }

        [HttpGet("last30Days")]
        public IActionResult GetLast30DaysStatistics()
        {
            var today = DateTime.Today;
            var startOf30DaysAgo = today.AddDays(-30);

            var last30DaysStats = _checkSPNsContext.Reports
                .Where(r => r.ReportDate >= startOf30DaysAgo)
                .GroupBy(r => r.ReportDate.Date)
                .Select(group => new
                {
                    Date = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return Ok(last30DaysStats);
        }

        [HttpGet("groupMonth")]
        public IActionResult GetByMonth()
        {
            var today = DateTime.Today;
            var startOf30DaysAgo = today.AddDays(-30);

            var monthStats = _checkSPNsContext.PhoneNumbers
                .GroupBy(r => r.DateAdded.Month)
                .Select(group => new
                {
                    Month = group.Key,
                    Count = group.Count()
                })
                .ToList();

            return Ok(monthStats);
        }

    }
}
