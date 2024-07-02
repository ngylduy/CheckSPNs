using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Data.EF.Context;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.EntityFrameworkCore;

namespace CheckSPNs.Data.EF.Implementations
{
    public class ReportRepository : Repository<Reports>, IReportRepository
    {
        private readonly CheckSPNsContext _context;

        public ReportRepository(CheckSPNsContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Reports>> GetListByPhoneNumber(Guid phoneNumberId)
        {
            var list = await _context.Reports.Where(x => x.PhoneNumberID.Equals(phoneNumberId)).ToListAsync();
            return list;
        }
    }
}
