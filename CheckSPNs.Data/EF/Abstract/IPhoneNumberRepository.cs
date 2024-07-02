using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Data.EF.Abstract
{
    public interface IPhoneNumberRepository : IRepository<PhoneNumbers>
    {
        Task<PhoneNumbers> GetInfoByPhoneNumber(string phoneNumber);
    }
}
