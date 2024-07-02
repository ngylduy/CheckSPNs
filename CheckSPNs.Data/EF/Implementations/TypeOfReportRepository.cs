using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Data.EF.Context;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Data.EF.Implementations
{
    public class TypeOfReportRepository : Repository<TypeOfReports>, ITypeOfReportRepository
    {
        private readonly CheckSPNsContext _context;
        public TypeOfReportRepository(CheckSPNsContext context) : base(context)
        {
            _context = context;
        }
    }
}
