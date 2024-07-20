using CheckSPNs.Client.Data.Helpers;
using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Admin.Pages.Report
{
    public class IndexModel : PageModel
    {
        private readonly IReportService _reportService;

        public IndexModel(IReportService reportService)
        {
            _reportService = reportService;
        }

        public DataPaged<Reports> ListReport { get; set; } = default!;

        public async Task<IActionResult> OnGet(int pageIndex = 1, int pageSize = 10)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return NotFound();
                }

                var result = await _reportService.GetAllReport<ResponsePaged<Reports>>(token, pageIndex, pageSize);
                if (result.isSuccess && result.value is not null)
                {
                    ListReport = result.value;
                    return Page();
                }
            }
            return NotFound();
        }
    }
}
