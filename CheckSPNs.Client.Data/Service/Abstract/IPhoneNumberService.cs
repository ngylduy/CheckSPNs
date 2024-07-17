namespace CheckSPNs.Client.Data.Service.Abstract
{
    public interface IPhoneNumberService
    {
        Task<T> GetAllPhoneNumbersAsync<T>(string token, int pageIndex = 1, int pageSize = 10);
    }
}
