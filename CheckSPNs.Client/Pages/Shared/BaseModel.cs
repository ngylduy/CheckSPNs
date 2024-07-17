using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Pages.Shared
{
    public class BaseModel : PageModel
    {
        public IList<TypeOfReports> typeOfReportList { get; set; } = default!;
    }
}
