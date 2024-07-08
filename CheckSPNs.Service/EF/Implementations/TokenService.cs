using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Domain;
using CheckSPNs.Domain.Helpers;
using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CheckSPNs.Service.EF.Implementations;

public class TokenService : ITokenService
{
    private readonly JwtOption _jwtOption;
    private readonly UserManager<AppUsers> _userManager;
    private readonly IUnitOfWork _unitOfWork;

    public TokenService(IConfiguration configuration, UserManager<AppUsers> userManager, IUnitOfWork unitOfWork, JwtOption jwtOption)
    {
        _jwtOption = jwtOption;
        _userManager = userManager;
        _unitOfWork = unitOfWork;
    }

    public string CreateAccessToken(IEnumerable<Claim> claims)
    {
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.SecretKey));
        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOption = new JwtSecurityToken(
            issuer: _jwtOption.Issuer,
            audience: _jwtOption.Audience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(_jwtOption.ExpireMin),
            signingCredentials: signinCredentials
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
        return tokenString;
    }

    public string CreateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }

    public async Task<JwtModel> GetJWTToken(AppUsers user)
    {
        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.NameIdentifier,user.UserName),
            new Claim(ClaimTypes.Email,user.Email),
        };
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var userClaims = await _userManager.GetClaimsAsync(user);
        claims.AddRange(userClaims);

        var accessToken = CreateAccessToken(claims);
        var refreshToken = CreateRefreshToken();

        await _unitOfWork.RepositoryUserRefreshToken.InsertAsync(new UserRefreshToken
        {
            AddedTime = DateTime.Now,
            ExpiryDate = DateTime.Now.AddMinutes(5),
            IsUsed = true,
            IsRevoked = false,
            RefreshToken = refreshToken,
            Token = accessToken,
            UserId = user.Id
        });

        await _unitOfWork.CommitAsync();

        var response = new JwtModel
        {
            AccessToken = accessToken,
            RefreshToken = refreshToken,
            RefreshTokenExpiryTime = DateTime.Now.AddMinutes(5)
        };
        return response;
    }

    public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var key = Encoding.UTF8.GetBytes(_jwtOption.SecretKey);
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = false,
            ValidateLifetime = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ClockSkew = TimeSpan.Zero
        };
        var tokenHandler = new JwtSecurityTokenHandler();
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);
        JwtSecurityToken jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken is null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCulture))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;

    }

    public async Task<JwtModel> GetRefreshToken(string email, string accessToken, string refreshToken)
    {
        var user = await _userManager.FindByEmailAsync(email);

        var userRefreshToken = await _unitOfWork.RepositoryUserRefreshToken.GetTableNoTracking()
                                         .FirstOrDefaultAsync(x => x.Token == accessToken &&
                                                              x.RefreshToken == refreshToken &&
                                                              x.UserId.Equals(user.Id));

        if (userRefreshToken is null)
        {
            throw new Exception("Invalid token");
        }
        if (userRefreshToken.ExpiryDate < DateTime.Now)
        {
            userRefreshToken.IsRevoked = true;
            userRefreshToken.IsUsed = false;
            _unitOfWork.RepositoryUserRefreshToken.Update(userRefreshToken);
            await _unitOfWork.CommitAsync();
            throw new Exception("RefreshToken Is Expired");
        }

        var roles = await _userManager.GetRolesAsync(user);
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name,user.UserName),
            new Claim(ClaimTypes.NameIdentifier,user.UserName),
            new Claim(ClaimTypes.Email,user.Email),
        };
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        var userClaims = await _userManager.GetClaimsAsync(user);
        claims.AddRange(userClaims);

        var newAccessToken = CreateAccessToken(claims);
        var newRefreshToken = CreateRefreshToken();

        await _unitOfWork.RepositoryUserRefreshToken.InsertAsync(new UserRefreshToken
        {
            AddedTime = DateTime.Now,
            ExpiryDate = DateTime.Now.AddMinutes(5),
            IsUsed = true,
            IsRevoked = false,
            RefreshToken = newRefreshToken,
            Token = accessToken,
            UserId = user.Id
        });

        await _unitOfWork.CommitAsync();

        var response = new JwtModel();
        response.AccessToken = newAccessToken;
        response.RefreshToken = newRefreshToken;
        response.RefreshTokenExpiryTime = userRefreshToken.ExpiryDate;

        return response;
    }
}
