using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Service.EF.Abstract
{
    public interface ITypeOfReportService
    {
        public Task<List<TypeOfReports>> GetListAsync();
        public Task<TypeOfReports> GetByIDAsync(Guid id);
        public Task<string> AddAsync(TypeOfReports typeOfReports);
        public string EditAsync(TypeOfReports typeOfReports);
        public string DeleteAsync(TypeOfReports typeOfReports);
    }
}
