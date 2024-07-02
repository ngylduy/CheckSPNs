using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Service.Cache;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.AspNetCore.Identity;

namespace CheckSPNs.Service.EF.Implementations
{
    public class UserService : IUserService
    {
        UserManager<AppUsers> _userManager;
        IDistributedCacheService _distributedCacheService;

        public UserService(UserManager<AppUsers> userManager, IDistributedCacheService distributedCacheService)
        {
            _userManager = userManager;
            _distributedCacheService = distributedCacheService;
        }

        public async Task<AppUsers> CheckLogin(string username, string password)
        {
            //AppUsers resultCache = await _distributedCacheService.Get<AppUsers>($"cache_user_{username}");

            //if (resultCache != null)
            //{
            //    return resultCache;
            //}

            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
            {
                return default;
            }

            var hasExist = await _userManager.CheckPasswordAsync(user, password);

            if (!hasExist)
            {
                return default;
            }
            if (string.IsNullOrEmpty(user.SecurityStamp))
            {
                await _userManager.UpdateSecurityStampAsync(user);
            }

            //await _distributedCacheService.Set($"cache_user_{username}", user);

            return user;
        }
    }
}
