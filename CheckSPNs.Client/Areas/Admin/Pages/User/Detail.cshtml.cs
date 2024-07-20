using CheckSPNs.Client.Data.Helpers;
using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain.DTO.Requests;
using CheckSPNs.Domain.DTO.Results;
using CheckSPNs.Domain.Models.EF.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CheckSPNs.Client.Areas.Admin.Pages.User
{
    public class DetailModel : PageModel
    {
        private readonly IUserService _userService;

        public DetailModel(IUserService userService)
        {
            _userService = userService;
        }

        public AppUsers AppUser { get; set; }

        public List<AppRoles> ListRole { get; set; }

        [BindProperty]
        public List<Guid> SelectedRoleId { get; set; }
        [BindProperty]
        public List<string> SelectedClaimType { get; set; }
        [BindProperty]
        public ManageUserRolesResult ManageUserRolesResult { get; set; }
        [BindProperty]
        public ManageUserClaimsResult ManageUserClaimsResult { get; set; }



        public async Task<IActionResult> OnGet(Guid id)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return NotFound();
                }

                var resultUser = await _userService.GetUserByIdAsync<Response<AppUsers>>(id, token);
                if (resultUser.isSuccess && resultUser.value is not null)
                {
                    AppUser = resultUser.value;

                    var listRole = await _userService.GetListRole<ResponseList<AppRoles>>(token);

                    var resultRole = await _userService.GetUserRole<Response<ManageUserRolesResult>>(resultUser.value.Id, token);

                    var resultClaim = await _userService.GetUserClaim<Response<ManageUserClaimsResult>>(resultUser.value.Id, token);


                    if (listRole.isSuccess && listRole.value is not null)
                    {
                        ListRole = listRole.value;
                    }

                    if (resultRole.isSuccess && resultRole.value is not null)
                    {
                        ManageUserRolesResult = resultRole.value;
                    }

                    if (resultClaim.isSuccess && resultClaim.value is not null)
                    {
                        ManageUserClaimsResult = resultClaim.value;
                    }

                    return Page();
                }
                return NotFound();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPost(Guid id)
        {
            var token = HttpContext.Session.GetString("AccessToken");
            if (token is not null)
            {
                if (!CheckService.IsAdmin(token))
                {
                    return NotFound();
                }
                if (SelectedRoleId is not null)
                {
                    var ListRoleAdd = new List<UserRoles>();
                    foreach (var item in SelectedRoleId)
                    {
                        var role = await _userService.GetRoleById<Response<UserRoles>>(token, item);
                        ListRoleAdd.Add(role.value);
                    }
                    UpdateUserRolesRequest request = new UpdateUserRolesRequest
                    {
                        UserId = id,
                        userRoles = ListRoleAdd
                    };
                    await _userService.UpdateUserRole<Response<UpdateUserRolesRequest>>(request, token);
                }
                if (SelectedClaimType is not null)
                {
                    var ListClaimAdd = new List<UserClaims>();
                    foreach (var item in SelectedClaimType)
                    {
                        ListClaimAdd.Add(new UserClaims
                        {
                            Type = item,
                            Value = true
                        });
                    }
                    UpdateUserClaimsRequest request = new UpdateUserClaimsRequest
                    {
                        UserId = id,
                        userClaims = ListClaimAdd
                    };
                    await _userService.UpdateUserClaim<Response<UpdateUserClaimsRequest>>(request, token);
                }

                //var result = await _userService.GetUserClaim<ManageUserClaimsResult>(id, token);
                //if (result.isSuccess && result.value is not null)
                //{
                //    ManageUserClaimsResult = result.value;
                //    return Page();
                //}

                return RedirectToPage("./Index");
            }

            return NotFound();
        }
    }
}
