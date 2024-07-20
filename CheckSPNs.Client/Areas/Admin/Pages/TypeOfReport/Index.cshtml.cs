using CheckSPNs.Client.Data.Helpers;
using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Admin.Pages.TypeOfReport
{
    public class IndexModel : PageModel
    {
        private readonly ITypeOfReportService _typeOfReportService;

        public IndexModel(ITypeOfReportService typeOfReportService)
        {
            _typeOfReportService = typeOfReportService;
        }

        [BindProperty]
        public IList<TypeOfReports> ListTypeOfReport { get; set; } = default!;

        [BindProperty]
        public string TypeOfReportName { get; set; } = default!;

        public async Task<IActionResult> OnGet()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return NotFound();
                }

                var result = await _typeOfReportService.GetList<ResponseList<TypeOfReports>>(token);
                if (result.isSuccess && result.value is not null)
                {
                    ListTypeOfReport = result.value;
                }

                return Page();
            }
            return NotFound();

        }

        public async Task<IActionResult> OnPost()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return NotFound();
                }

                var result = await _typeOfReportService.CreateNew<Response<TypeOfReports>>(token, TypeOfReportName);
                if (result.isSuccess)
                {
                    return RedirectToPage();
                }
            }
            return NotFound();
        }
    }
}
