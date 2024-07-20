using CheckSPNs.Client.Data.Service.Abstract;

namespace CheckSPNs.Client.Data.Service.Implementation
{
    public class AuthorizationService : BaseService, IAuthorizationService
    {
        private readonly IHttpClientFactory _clientFactory;

        public AuthorizationService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = httpClient;
        }



    }
}
