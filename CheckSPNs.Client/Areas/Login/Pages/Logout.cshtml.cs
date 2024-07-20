using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Login.Pages
{
    [AllowAnonymous]
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            HttpContext.Session.Remove("AccessToken");

            Response.Cookies.Delete("RefreshToken", new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.Now.AddMinutes(5)
            });

            return RedirectToPage("/Index", new { area = "" });
        }
    }
}
