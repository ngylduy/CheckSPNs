using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Data.EF.Context;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;

namespace CheckSPNs.Data.EF.Implementations
{
    public class PhoneNumberRepository : Repository<PhoneNumbers>, IPhoneNumberRepository
    {
        private readonly CheckSPNsContext _context;

        public PhoneNumberRepository(CheckSPNsContext context) : base(context)
        {
            _context = context;
        }

        public Task<PhoneNumbers> GetInfoByPhoneNumber(string phoneNumber)
        {
            return _context.Set<PhoneNumbers>().Include(p => p.Reports).FirstOrDefaultAsync(x => x.PhoneNumber.Equals(phoneNumber));
        }

        public async Task<List<RecentReportPhoneNumber>> GetRecentReportPhoneNumbers()
        {
            return await _context.Set<PhoneNumbers>().Include(p => p.Reports).Select(x => new RecentReportPhoneNumber
            {
                Id = x.Id,
                PhoneNumber = x.PhoneNumber,
                DateAdded = x.DateAdded,
                TimesReported = x.TimesReported,
                Reports = x.Reports.OrderByDescending(r => r.ReportDate).FirstOrDefault()
            }).Where(x => x.Reports != null).OrderByDescending(x => x.Reports.ReportDate).ToListAsync();
        }
    }
}
