using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Pages.Search
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet(string? phoneNumber)
        {
            if (!long.TryParse(phoneNumber, out _))
            {
                return NotFound();
            }
            return Redirect($"/phonenumber/{phoneNumber}");
        }
    }
}
