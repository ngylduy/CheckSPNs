using CheckSPNs.Client.Data.Service.Abstract;

namespace CheckSPNs.Client.Data.Service.Implementation;

public class AuthService : BaseService, IAuthService
{
    private readonly IHttpClientFactory _clientFactory;

    public AuthService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> Login<T>(string email, string password)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.POST,
            Data = new { email, password },
            Url = ApiBase.APIBaseUrl + "/api/Authentications/login"
        });
    }

    public async Task<T> RefreshToken<T>(string accessToken, string refreshToken)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.POST,
            Data = new
            {
                accessToken,
                refreshToken
            },
            Url = ApiBase.APIBaseUrl + "/refresh-token"
        });
    }
}

