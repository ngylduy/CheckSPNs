namespace CheckSPNs.Client.Data.Service.Abstract;

public interface IBaseService
{
    Task<T> SendAsync<T>(ApiRequest apiRequest);
}

