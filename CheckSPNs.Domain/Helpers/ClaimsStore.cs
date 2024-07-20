using System.Security.Claims;

namespace CheckSPNs.Domain.Helpers
{
    public static class ClaimsStore
    {
        public static List<Claim> claims = new()
        {
            new Claim("Delete","false"),
            new Claim("Edit","false"),
            new Claim("View Stat","false")
        };
    }
}
