using CheckSPNs.Client.Data.Model;
using CheckSPNs.Domain.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IList<RecentReportPhoneNumber> ReportsList { get; set; } = default!;
        public IList<AggregatePrefixPhoneNumber> PrefixList { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Key", "Value");

                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5000/recent-report?pageIndex=1&pageSize=20"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var list = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponsePaged<RecentReportPhoneNumber>>(apiResponse);
                        ReportsList = list.value.items;
                    }
                }

                using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5000/prefix"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var list = Newtonsoft.Json.JsonConvert.DeserializeObject<ResponseList<AggregatePrefixPhoneNumber>>(apiResponse);
                        PrefixList = list.value;
                    }
                }

            }

            return Page();
        }
    }
}
