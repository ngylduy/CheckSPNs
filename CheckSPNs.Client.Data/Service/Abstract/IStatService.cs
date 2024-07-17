namespace CheckSPNs.Client.Data.Service.Abstract
{
    public interface IStatService
    {
        Task<T> GetPhoneNumberStat<T>(string token);
        Task<T> GetTopRepeportPhoneNumberStat<T>(string token);
        Task<T> GetSystemStat<T>(string token);
    }
}
