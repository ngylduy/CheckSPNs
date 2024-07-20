using CheckSPNs.Client.Pages.Shared;
using Microsoft.AspNetCore.Authorization;

namespace CheckSPNs.Client.Pages;

[Authorize]
public class PrivacyModel : BaseModel
{
    private readonly ILogger<PrivacyModel> _logger;

    public PrivacyModel(ILogger<PrivacyModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
    }
}
