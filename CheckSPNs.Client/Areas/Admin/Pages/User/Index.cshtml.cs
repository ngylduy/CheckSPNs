using CheckSPNs.Client.Data.Helpers;
using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain.Models.EF.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Admin.Pages.User
{
    public class IndexModel : PageModel
    {
        private readonly IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }

        public IList<AppUsers> ListUser { get; set; } = default!;

        public async Task<IActionResult> OnGet(int pageIndex = 1, int pageSize = 10)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return NotFound();
                }

                var result = await _userService.GetAllUsersAsync<ResponsePaged<AppUsers>>(token, pageIndex, pageSize);
                if (result.isSuccess && result.value is not null)
                {
                    ListUser = result.value.items;
                    return Page();
                }
            }
            return NotFound();
        }
    }
}
