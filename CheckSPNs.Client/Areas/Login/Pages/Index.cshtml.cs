using CheckSPNs.Client.Data.Helpers;
using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Login.Pages
{

    [AllowAnonymous]
    public class IndexModel : PageModel
    {

        private readonly IAuthService _authService;

        public IndexModel(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult OnGet()
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return RedirectToPage("/Index", new { area = "" });
                }
                else
                {
                    return RedirectToPage("/Remote/Index", new { area = "Admin" });
                }
            }
            return Page();
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [BindProperty]
        public LoginModel loginModel { get; set; } = new LoginModel();

        public async Task<IActionResult> OnPost()
        {
            var response = await _authService.Login<Response<JwtModel>>(loginModel.Email, loginModel.Password);
            if (response.isSuccess && response.value != null)
            {
                var accessToken = Convert.ToString(response.value.AccessToken);
                var refreshToken = Convert.ToString(response.value.RefreshToken);
                HttpContext.Session.SetString("AccessToken", accessToken);

                Response.Cookies.Append("RefreshToken", refreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddMinutes(5)
                });

                return RedirectToAction("Index");
            }
            ViewData["Checked"] = "Your email or password are wrong!";
            return OnGet();
        }
    }
}
