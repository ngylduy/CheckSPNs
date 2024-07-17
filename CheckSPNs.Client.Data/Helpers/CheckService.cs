using CheckSPNs.Domain.Helpers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CheckSPNs.Client.Data.Helpers;

public static class CheckService
{
    public static bool IsAdmin(string token)
    {
        if (token == null)
        {
            return false;
        }
        else
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var role = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
            if (role == "Admin")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    public static bool IsUser(string token)
    {
        if (token == null)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public static int GetUserId(string token)
    {
        if (token == null)
        {
            return 0;
        }
        else
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = handler.ReadJwtToken(token);
            var userIdClaim = jwtSecurityToken.Claims.FirstOrDefault(c => c.Type == nameof(UserClaimModel))?.Value;

            int userId;
            if (int.TryParse(userIdClaim, out userId))
            {
                return userId;
            }
            else
            {
                return 0;
            }

        }
    }
}

