using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Service.EF.Abstract
{
    public interface ITypeOfReportService
    {
        Task<List<TypeOfReports>> GetListAsync();
        Task<TypeOfReports> GetByIDAsync(Guid id);
        Task EditAsync(TypeOfReports typeOfReports);
        Task DeleteAsync(TypeOfReports typeOfReports);
        Task<bool> IsTypeOfReportExit(string typeOfReport);
        Task<bool> IsTypeOfReportExitExcludeSelf(string typeOfReport, Guid id);
        Task AddAsync(TypeOfReports typeOfReports);
    }
}
