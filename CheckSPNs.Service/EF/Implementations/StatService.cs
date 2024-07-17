using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.ViewModel.Stats;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CheckSPNs.Service.EF.Implementations
{
    public class StatService : IStatService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StatService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public PhoneNumberStatByStatus PhoneNumberStatByStatus()
        {
            var table = _unitOfWork.PhoneNumberRepository.GetTableNoTracking();

            var positive = table.Where(x => x.PositiveReportsCount > x.NegativeReportsCount).Count();
            var negative = table.Where(x => x.PositiveReportsCount < x.NegativeReportsCount).Count();
            var neutral = table.Where(x => x.PositiveReportsCount == x.NegativeReportsCount).Count();
            var total = table.Count();

            return new PhoneNumberStatByStatus
            {
                Negative = negative,
                Neutral = neutral,
                Positive = positive,
                NegativePercent = Math.Round(((double)negative / total) * 100, 2),
                NeutralPercent = Math.Round(((double)neutral / total) * 100, 2),
                PositivePercent = Math.Round(((double)positive / total) * 100, 2),
                Total = total
            };

        }

        public async Task<List<ReportStatByTime>> PhoneNumberStatByTime(DateTime from, DateTime to)
        {
            var stat = await _unitOfWork.ReportRepository.GetTableNoTracking()
                .Where(r => r.ReportDate >= from && r.ReportDate <= to)
                .GroupBy(r => r.ReportDate.Date)
                .Select(group => new ReportStatByTime
                {
                    ReportDate = group.Key,
                    Count = group.Count()
                })
                .ToListAsync();

            return stat;
        }

        public IQueryable<PhoneNumbers> PhoneNumberTopReport()
        {
            var stat = _unitOfWork.PhoneNumberRepository.GetTableNoTracking()
                .OrderByDescending(x => x.TimesReported);
            return stat;
        }

        public IQueryable<PhoneNumbers> PhoneNumberTopView()
        {
            var stat = _unitOfWork.PhoneNumberRepository.GetTableNoTracking()
                .OrderByDescending(x => x.Views);
            return stat;
        }

        public SystemStat GetSystemStat()
        {
            var table = _unitOfWork.PhoneNumberRepository.GetTableNoTracking();

            var totalPhoneNumbers = table.Count();
            var totalReport = table.Sum(x => x.TimesReported);
            var totalViews = table.Sum(x => x.Views);

            return new SystemStat
            {
                TotalPhoneNumbers = totalPhoneNumbers,
                TotalReport = totalReport,
                TotalViews = totalViews
            };
        }
    }
}
