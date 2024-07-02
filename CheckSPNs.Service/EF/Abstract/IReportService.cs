using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Service.EF.Abstract
{
    public interface IReportService
    {
        Task AddReport(string report, string phoneNumber);
        Task<List<Reports>> GetListByPhoneNumberId(Guid phoneNumberId);
        IQueryable<Reports> GetReportsQuerable();
    }
}
