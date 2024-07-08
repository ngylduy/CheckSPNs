using CheckSPNs.Client.Data.Model;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text;
using System.Text.Json;

namespace CheckSPNs.Client.Pages.PhoneNumber
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string? number { get; set; }
        public PhoneNumbers phoneNumbers { get; set; } = default!;
        public async Task<IActionResult> OnGet(string? number)
        {
            if (number != null)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Add("Key", "Value");

                    using (HttpResponseMessage response = await httpClient.GetAsync("https://localhost:5000/api/PhoneNumbers/" + number))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            var list = Newtonsoft.Json.JsonConvert.DeserializeObject<Response<PhoneNumbers>>(apiResponse);
                            phoneNumbers = list.value;
                            if (phoneNumbers == null)
                            {
                                using (HttpResponseMessage submit = await httpClient.PostAsync(
                                    "https://localhost:5000/api/PhoneNumbers/",
                                    new StringContent(
                                        JsonSerializer.Serialize(new PhoneNumbers
                                        {
                                            PhoneNumber = number
                                        }),
                                        Encoding.UTF8,
                                        "application/json"
                                    )
                                ))
                                {
                                    if (submit.IsSuccessStatusCode)
                                    {
                                        return RedirectToAction("Index");
                                    }
                                }
                            }
                        }
                    }

                }
            }

            return Page();
        }
    }
}
