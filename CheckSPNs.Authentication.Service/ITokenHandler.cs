using CheckSPNs.Domain;
using CheckSPNs.Domain.Models.EF.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace CheckSPNs.Authentication.Service;

public interface ITokenHandler
{
    /// <summary>
    /// Validate token
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    Task ValidateToken(TokenValidatedContext context);
    Task<string> CreateAccessToken(AppUsers user);
    Task<string> CreateRefreshToken(AppUsers user);
    Task<JwtModel> ValidateRefreshToken(string refreshToken);
}