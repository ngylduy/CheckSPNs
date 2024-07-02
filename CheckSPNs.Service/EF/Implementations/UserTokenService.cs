using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Service.EF.Abstract;

namespace CheckSPNs.Service.EF.Implementations
{
    public class UserTokenService : IUserTokenService
    {
        IRepository<UserTokens> _userTokenRepository;

        public UserTokenService(IRepository<UserTokens> userTokenRepository)
        {
            _userTokenRepository = userTokenRepository;
        }

        public async Task SaveToken(UserTokens userToken)
        {
            await _userTokenRepository.InsertAsync(userToken);
            await _userTokenRepository.CommitAsync();
        }

        public async Task<UserTokens> CheckRefreshToken(string code)
        {
            return await _userTokenRepository.GetSingleByConditionAsync(x => x.CodeRefreshToken == code);
        }

    }
}
