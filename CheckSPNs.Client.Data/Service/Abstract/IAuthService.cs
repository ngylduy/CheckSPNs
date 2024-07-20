namespace CheckSPNs.Client.Data.Service.Abstract;

public interface IAuthService
{
    Task<T> Login<T>(string email, string password);
    Task<T> RefreshToken<T>(string accessToken, string refreshToken);
}

