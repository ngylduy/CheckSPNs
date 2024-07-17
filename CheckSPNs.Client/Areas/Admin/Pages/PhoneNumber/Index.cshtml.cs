using CheckSPNs.Client.Data.Helpers;
using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Admin.Pages.PhoneNumber
{
    public class IndexModel : PageModel
    {
        private readonly IPhoneNumberService _phoneNumberService;

        public IndexModel(IPhoneNumberService phoneNumberService)
        {
            _phoneNumberService = phoneNumberService;
        }

        [BindProperty]
        public DataPaged<PhoneNumbers> ListPhoneNumber { get; set; } = default!;

        public async Task<IActionResult> OnGet(int pageIndex = 1, int pageSize = 10)
        {
            var token = HttpContext.Session.GetString("token");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return NotFound();
                }

                var result = await _phoneNumberService.GetAllPhoneNumbersAsync<ResponsePaged<PhoneNumbers>>(token, pageIndex, pageSize);
                if (result.isSuccess && result.value is not null)
                {
                    ListPhoneNumber = result.value;
                    return Page();
                }
            }
            return NotFound();

        }
    }
}
