using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Data.EF.Abstract
{
    public interface IReportRepository : IRepository<Reports>
    {
        Task<List<Reports>> GetListByPhoneNumber(Guid phoneNumberId);
    }
}
