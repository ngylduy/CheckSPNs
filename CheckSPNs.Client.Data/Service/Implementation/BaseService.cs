using CheckSPNs.Client.Data.Service.Abstract;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace CheckSPNs.Client.Data.Service.Implementation;

public class BaseService : IBaseService
{
    public IHttpClientFactory httpClient { get; set; }

    public BaseService(IHttpClientFactory httpClient)
    {
        this.httpClient = httpClient;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }

    public async Task<T> SendAsync<T>(ApiRequest apiRequest)
    {
        try
        {
            var client = httpClient.CreateClient();
            HttpRequestMessage message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            client.DefaultRequestHeaders.Clear();
            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                    Encoding.UTF8, "application/json");
            }

            if (!string.IsNullOrEmpty(apiRequest.AccessToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccessToken);
            }

            switch (apiRequest.ApiType)
            {
                case ApiBase.APIType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case ApiBase.APIType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case ApiBase.APIType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            HttpResponseMessage apiResponse = await client.SendAsync(message);

            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
            return apiResponseDto;

        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}

