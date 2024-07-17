using CheckSPNs.Domain.Models.EF.Identity;

namespace CheckSPNs.Service.AuthServices.Interfaces
{
    public interface ICurrentUserService
    {
        public Task<AppUsers> GetUserAsync();
        public int GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
