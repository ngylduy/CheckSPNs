
namespace CheckSPNs.Client.Data.Service.Abstract
{
    public interface ITypeOfReportService
    {
        Task<T> CreateNew<T>(string token, string typeOfReport);
        Task<T> DeleteTypeOfReport<T>(string token, Guid id);
        Task<T> GetList<T>(string token);
        Task<T> UpdateTypeOfReport<T>(string token, Guid id, string typeOfReport);
    }
}
