using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;

namespace CheckSPNs.Service.EF.Abstract;

public interface IUserTokenService
{
    Task<UserTokens> CheckRefreshToken(string code);
    Task SaveToken(UserTokens userToken);
}