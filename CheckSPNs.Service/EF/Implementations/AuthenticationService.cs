using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.AspNetCore.Identity;

namespace CheckSPNs.Service.EF.Implementations;

public class AuthenticationService : IAuthenticationService
{
    private readonly UserManager<AppUsers> _userManager;

    public AuthenticationService(UserManager<AppUsers> userManager)
    {
        _userManager = userManager;
    }

    public async Task ConfirmEmail(Guid userId, string? code)
    {
        if (userId == null || code == null) throw new Exception();
        var user = await _userManager.FindByIdAsync(userId.ToString());
        var confirmEmail = await _userManager.ConfirmEmailAsync(user, code);
        if (!confirmEmail.Succeeded)
            throw new Exception();
    }
}
