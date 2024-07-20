using CheckSPNs.Domain.DTO.Requests;

namespace CheckSPNs.Client.Data.Service.Abstract;

public interface IUserService
{
    Task<T> GetAllUsersAsync<T>(string token, int pageIndex, int pageSize);
    Task<T> GetListRole<T>(string token);
    Task<T> GetRoleById<T>(string token, Guid id);
    Task<T> GetUserByIdAsync<T>(Guid id, string token);
    Task<T> GetUserClaim<T>(Guid id, string token);
    Task<T> GetUserRole<T>(Guid id, string token);
    Task<T> UpdateUserClaim<T>(UpdateUserClaimsRequest userClaimDto, string token);
    Task<T> UpdateUserRole<T>(UpdateUserRolesRequest userRoleDto, string token);
    //Task<T> CreateUserAsync<T>(UserDTO userDto, string token);
    //Task<T> UpdateUserAsync<T>(UserDTO userDto, string token);
    //Task<T> UpdatePasswordAsync<T>(UserDTO userDto, string token);
    //Task<T> DeleteUserAsync<T>(int id, string token);
}

