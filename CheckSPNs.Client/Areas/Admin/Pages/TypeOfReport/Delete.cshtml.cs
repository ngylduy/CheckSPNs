using CheckSPNs.Client.Data.Helpers;
using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Admin.Pages.TypeOfReport
{
    public class DeleteModel : PageModel
    {

        private readonly ITypeOfReportService _typeOfReportService;

        public DeleteModel(ITypeOfReportService typeOfReportService)
        {
            _typeOfReportService = typeOfReportService;
        }

        public async Task<IActionResult> OnGet(Guid id)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return NotFound();
                }

                var result = await _typeOfReportService.DeleteTypeOfReport<Response<TypeOfReports>>(token, id);
                if (result.isSuccess)
                {
                    return RedirectToPage("./Index");
                }
            }
            return NotFound();
        }
    }
}
