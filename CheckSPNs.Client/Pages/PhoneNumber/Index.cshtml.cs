using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Pages.Shared;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.Client.Pages.PhoneNumber
{
    public class IndexModel : BaseModel
    {

        private readonly HttpClient _httpClient;

        public IndexModel()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("Key", "Value");
        }


        public PhoneNumbers phoneNumbers { get; set; } = default!;
        public IList<TypeOfReports> listTypeOfReports { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string number)
        {
            if (!long.TryParse(number, out _))
            {
                return NotFound();
            }
            if (!string.IsNullOrWhiteSpace(number))
            {
                phoneNumbers = await GetPhoneNumberDetailsAsync(number);

                if (phoneNumbers == null)
                {
                    var newPhoneNumber = new PhoneNumbers { PhoneNumber = number };

                    using var submitResponse = await _httpClient.PostAsJsonAsync(
                        "https://localhost:5000/api/phonenumbers/",
                        newPhoneNumber
                    );

                    if (!submitResponse.IsSuccessStatusCode)
                    {
                        // handle error gracefully (log, display error message)
                    }
                }
                listTypeOfReports = await GetTypeOfReportsAsync();
                typeOfReportList = listTypeOfReports;
            }

            return Page();
        }

        [BindProperty]
        public int reportEnum { get; set; } = -1;
        [BindProperty]
        public AddNewReport addNewReport { get; set; } = null;

        public async Task<IActionResult> OnPostAsync(string number)
        {
            if (reportEnum != -1)
            {
                var reportData = new { phoneNumber = number, reportEnum = reportEnum };

                using var submit = await _httpClient.PostAsJsonAsync(
                    "https://localhost:5000/add-report-status", reportData
                );

                if (submit.IsSuccessStatusCode)
                {
                    return RedirectToPage();
                }

            }
            if (ModelState.IsValid)
            {
                if (addNewReport.TypeOfReport != Guid.Empty)
                {
                    var addTypeOfReport = new { phoneNumber = number, typeOfReportsId = addNewReport.TypeOfReport };

                    using var submit = await _httpClient.PostAsJsonAsync(
                        "https://localhost:5000/add-type-of-report", addTypeOfReport
                    );
                }

                var addComment = new { phoneNumber = number, comment = addNewReport.Comment };

                using var submitComment = await _httpClient.PostAsJsonAsync(
                    "https://localhost:5000/api/Reports", addComment
                );

            }
            return RedirectToPage();
        }

        private async Task<PhoneNumbers?> GetPhoneNumberDetailsAsync(string number)
        {
            using var response = await _httpClient.GetAsync($"https://localhost:5000/api/PhoneNumbers/{number}");
            response.EnsureSuccessStatusCode(); // Throw exception if not successful
            var apiResponse = await response.Content.ReadAsStringAsync();
            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<PhoneNumbers>>(apiResponse);
            return list?.value;
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
