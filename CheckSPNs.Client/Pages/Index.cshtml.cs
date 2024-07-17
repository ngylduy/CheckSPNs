using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Pages.Shared;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.Client.Pages
{
    public class IndexModel : BaseModel
    {
        private readonly HttpClient _httpClient;

        public IndexModel()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Key", "Value");
        }

        public IList<RecentReportPhoneNumber> ReportsList { get; set; } = default!;
        public IList<AggregatePrefixPhoneNumber> PrefixList { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {

            using (HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5000/recent-report?pageIndex=1&pageSize=20"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var list = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsePaged<RecentReportPhoneNumber>>(apiResponse);
                    ReportsList = list.value.items;
                }
            }

            using (HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:5000/prefix"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var list = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseList<AggregatePrefixPhoneNumber>>(apiResponse);
                    PrefixList = list.value;
                }
            }
            typeOfReportList = await GetTypeOfReportsAsync();
            return Page();
        }

        private async Task<IList<TypeOfReports>> GetTypeOfReportsAsync()
        {
            using var response = await _httpClient.GetAsync("https://localhost:5000/api/TypeOfReports");
            response.EnsureSuccessStatusCode();
            var apiResponse = await response.Content.ReadAsStringAsync();
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseList<TypeOfReports>>(apiResponse);
            return list?.value ?? new List<TypeOfReports>(); // Return empty list if null
        }
    }
}
