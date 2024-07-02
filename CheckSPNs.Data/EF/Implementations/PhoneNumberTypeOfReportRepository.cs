using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Data.EF.Context;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Data.EF.Implementations
{
    public class PhoneNumberTypeOfReportRepository : Repository<PhoneNumbersTypeOfReports>, IPhoneNumberTypeOfReportRepository
    {
        private readonly CheckSPNsContext _context;

        public PhoneNumberTypeOfReportRepository(CheckSPNsContext context) : base(context)
        {
            _context = context;
        }

        public bool GetByPhoneNumberAndTypeOfReportAsync(Guid phoneNumberId, Guid typeOfReportId)
        {
            return _context.PhoneNumbersTypeOfReports.Any(x => x.PhoneNumbersId.Equals(phoneNumberId) && x.TypeOfReportsId.Equals(typeOfReportId));
        }
    }
}
