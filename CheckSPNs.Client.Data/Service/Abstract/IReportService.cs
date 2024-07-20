
namespace CheckSPNs.Client.Data.Service.Abstract
{
    public interface IReportService
    {
        Task<T> GetAllReport<T>(string token, int pageIndex = 1, int pageSize = 10);
    }
}
