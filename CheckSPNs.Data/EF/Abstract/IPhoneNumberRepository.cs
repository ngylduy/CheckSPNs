using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.ViewModel;

namespace CheckSPNs.Data.EF.Abstract
{
    public interface IPhoneNumberRepository : IRepository<PhoneNumbers>
    {
        Task<PhoneNumbers> GetInfoByPhoneNumber(string phoneNumber);
        Task<List<RecentReportPhoneNumber>> GetRecentReportPhoneNumbers();
    }
}
