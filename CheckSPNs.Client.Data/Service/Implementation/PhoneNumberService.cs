using CheckSPNs.Client.Data.Service.Abstract;

namespace CheckSPNs.Client.Data.Service.Implementation
{
    public class PhoneNumberService : BaseService, IPhoneNumberService
    {
        private readonly IHttpClientFactory _clientFactory;

        public PhoneNumberService(IHttpClientFactory clientFactory) : base(clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<T> GetAllPhoneNumbersAsync<T>(string token, int pageIndex = 1, int pageSize = 10)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.GET,
                Url = ApiBase.APIBaseUrl + $"/api/PhoneNumbers?pageIndex={pageIndex}&pageSize={pageSize}",
                AccessToken = token
            });
        }

        public async Task<T> GetPhoneNumberDetailAsync<T>(string phoneNumber)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.GET,
                Url = ApiBase.APIBaseUrl + $"/api/PhoneNumbers/{phoneNumber}"
            });
        }
    }
}
