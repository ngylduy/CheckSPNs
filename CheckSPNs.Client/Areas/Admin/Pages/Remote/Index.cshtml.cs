using CheckSPNs.Client.Data.Helpers;
using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.ViewModel.Stats;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Admin.Pages.Remote
{
    public class IndexModel : PageModel
    {
        private readonly IStatService _statService;

        public IndexModel(IStatService statService)
        {
            _statService = statService;
        }

        [BindProperty]
        public PhoneNumberStatByStatus PhoneNumberStats { get; set; } = default!;

        [BindProperty]
        public IList<PhoneNumbers> ListViewPhoneNumber { get; set; } = default!;

        [BindProperty]
        public SystemStat SystemStats { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            var token = HttpContext.Session.GetString("token");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return NotFound();
                }

                var result = await _statService.GetPhoneNumberStat<Response<PhoneNumberStatByStatus>>(token);
                var listPhoneNumber = await _statService.GetTopRepeportPhoneNumberStat<ResponsePaged<PhoneNumbers>>(token);
                var systemStat = await _statService.GetSystemStat<Response<SystemStat>>(token);
                if (result.isSuccess && result.value is not null)
                {
                    PhoneNumberStats = result.value;
                }
                if (listPhoneNumber.isSuccess && listPhoneNumber.value is not null)
                {
                    ListViewPhoneNumber = listPhoneNumber.value.items;
                }
                if (systemStat.isSuccess && systemStat.value is not null)
                {
                    SystemStats = systemStat.value;
                }

                return Page();
            }
            return NotFound();
        }
    }
}
