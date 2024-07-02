using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Data.EF.Abstract
{
    public interface IPhoneNumberTypeOfReportRepository : IRepository<PhoneNumbersTypeOfReports>
    {
        public bool GetByPhoneNumberAndTypeOfReportAsync(Guid phoneNumberId, Guid typeOfReportId);
    }
}
