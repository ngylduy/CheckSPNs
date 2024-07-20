using CheckSPNs.Client.Data.Service.Abstract;

namespace CheckSPNs.Client.Data.Service.Implementation
{
    public class TypeOfReportService : BaseService, ITypeOfReportService
    {
        private readonly IHttpClientFactory _clientFactory;

        public TypeOfReportService(IHttpClientFactory httpClient) : base(httpClient)
        {
            _clientFactory = httpClient;
        }

        public async Task<T> GetList<T>(string token)
        {
            var result = await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.GET,
                Url = ApiBase.APIBaseUrl + "/api/TypeOfReports",
                AccessToken = token
            });
            return result;
        }

        public async Task<T> CreateNew<T>(string token, string typeOfReport)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.POST,
                Data = new
                {
                    typeOfReport
                },
                Url = ApiBase.APIBaseUrl + "/api/TypeOfReports",
                AccessToken = token
            });
        }

        public async Task<T> DeleteTypeOfReport<T>(string token, Guid id)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.DELETE,
                Url = ApiBase.APIBaseUrl + "/api/TypeOfReports/" + id,
                AccessToken = token
            });
        }

        public async Task<T> UpdateTypeOfReport<T>(string token, Guid id, string typeOfReport)
        {
            return await this.SendAsync<T>(new ApiRequest()
            {
                ApiType = ApiBase.APIType.PUT,
                Data = new
                {
                    id,
                    typeOfReport
                },
                Url = ApiBase.APIBaseUrl + "/api/TypeOfReports",
                AccessToken = token
            });
        }
    }
}
