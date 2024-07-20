using CheckSPNs.Domain.DTO.Requests;
using CheckSPNs.Domain.DTO.Results;
using CheckSPNs.Domain.Models.EF.Identity;

namespace CheckSPNs.Service.EF.Abstract
{
    public interface IAuthorizationService
    {
        Task AddRoleAsync(string roleName);
        Task<bool> IsRoleExistByName(string roleName);
        Task EditRoleAsync(EditRoleRequest request);
        Task DeleteRoleAsync(Guid roleId);
        Task<bool> IsRoleExistById(Guid roleId);
        Task<List<AppRoles>> GetRolesList();
        Task<AppRoles> GetRoleById(Guid id);
        Task<ManageUserRolesResult> ManageUserRolesData(AppUsers user);
        Task UpdateUserRoles(UpdateUserRolesRequest request);
        Task<ManageUserClaimsResult> ManageUserClaimData(AppUsers user);
        Task UpdateUserClaims(UpdateUserClaimsRequest request);
    }
}
