using CheckSPNs.Client.Data.Service.Abstract;

namespace CheckSPNs.Client.Data.Service.Implementation
{
    public class ReportService : BaseService, IReportService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ReportService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> GetAllReport<T>(string token, int pageIndex = 1, int pageSize = 10)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.GET,
                Url = ApiBase.APIBaseUrl + $"/api/Reports?pageIndex={pageIndex}&pageSize={pageSize}",
                AccessToken = token
            });
        }
    }
}
