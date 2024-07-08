using CheckSPNs.Domain;
using CheckSPNs.Domain.Models.EF.Identity;
using System.Security.Claims;

namespace CheckSPNs.Service.EF.Abstract;

public interface ITokenService
{
    string CreateAccessToken(IEnumerable<Claim> claims);
    string CreateRefreshToken();
    ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    Task<JwtModel> GetJWTToken(AppUsers user);
    Task<JwtModel> GetRefreshToken(string email, string accessToken, string refreshToken);
}