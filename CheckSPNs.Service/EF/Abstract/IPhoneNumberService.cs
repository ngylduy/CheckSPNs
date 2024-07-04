using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.Models.EF.Enums;
using CheckSPNs.Domain.ViewModel;

namespace CheckSPNs.Service.EF.Abstract
{
    public interface IPhoneNumberService
    {
        Task AddAsync(string phoneNumber);
        Task AddTypeReport(string phoneNumber, Guid typeOfReport);
        Task<List<AggregatePrefixPhoneNumber>> AggregateByPrefix();
        Task<PhoneNumbers> GetInfoByPhoneNumber(string phoneNumber);
        Task<List<PhoneNumbers>> GetListAsync();
        Task<PhoneNumbers> GetPhoneNumberByIdAsync(Guid id);
        Task UpdateOverallReport(PhoneNumberOverallReportEnum phoneNumberOverallReport, string phoneNumber);


        Task EditAsync(PhoneNumbers phoneNumbers);
        Task DeleteAsync(PhoneNumbers phoneNumbers);
    }
}
