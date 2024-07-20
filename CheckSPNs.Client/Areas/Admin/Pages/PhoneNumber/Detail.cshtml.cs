using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Admin.Pages.PhoneNumber
{
    public class DetailModel : PageModel
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public DetailModel(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }

        [BindProperty]
        public PhoneNumbers PhoneNumber { get; set; } = default!;

        public async Task<IActionResult> OnGet(string number)
        {
            if (number is null)
            {
                return NotFound();
            }
            var result = await _phoneNumberService.GetPhoneNumberDetailAsync<Response<PhoneNumbers>>(number);
            if (result.isSuccess && result.value is not null)
            {
                PhoneNumber = result.value;
                return Page();
            }
            return NotFound();
        }
    }
}
