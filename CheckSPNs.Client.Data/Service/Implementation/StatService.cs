using CheckSPNs.Client.Data.Service.Abstract;

namespace CheckSPNs.Client.Data.Service.Implementation
{
    public class StatService : BaseService, IStatService
    {
        private readonly IHttpClientFactory _clientFactory;

        public StatService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetPhoneNumberStat<T>(string token)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.GET,
                Url = ApiBase.APIBaseUrl + "/api/Stats/stat-phone-number-by-status",
                AccessToken = token
            });
            return result;
        }

        public async Task<T> GetTopRepeportPhoneNumberStat<T>(string token)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.GET,
                Url = ApiBase.APIBaseUrl + "/api/Stats/top-report?pageIndex=1&pageSize=10",
                AccessToken = token
            });
            return result;
        }

        public async Task<T> GetSystemStat<T>(string token)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.GET,
                Url = ApiBase.APIBaseUrl + "/api/Stats/system-stat",
                AccessToken = token
            });
            return result;
        }
    }
}
