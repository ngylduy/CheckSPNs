using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain.DTO.Requests;

namespace CheckSPNs.Client.Data.Service.Implementation;

public class UserService : BaseService, IUserService
{
    private readonly IHttpClientFactory _clientFactory;

    public UserService(IHttpClientFactory clientFactory) : base(clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public async Task<T> GetAllUsersAsync<T>(string token, int pageIndex, int pageSize)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.GET,
            Url = ApiBase.APIBaseUrl + $"/api/Users/list-users?pageIndex={pageIndex}&pageSize={pageSize}",
            AccessToken = token
        });
    }

    public async Task<T> GetUserByIdAsync<T>(Guid id, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.GET,
            Url = ApiBase.APIBaseUrl + "/api/Users/get-user/" + id,
            AccessToken = token
        });
    }

    public async Task<T> GetListRole<T>(string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.GET,
            Url = ApiBase.APIBaseUrl + "/api/Authorizations/Roles/List",
            AccessToken = token
        });
    }

    public async Task<T> GetRoleById<T>(string token, Guid id)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.GET,
            Url = ApiBase.APIBaseUrl + "/api/Authorizations/Roles/Get-By-Id/" + id,
            AccessToken = token
        });
    }

    public async Task<T> GetUserRole<T>(Guid id, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.GET,
            Url = ApiBase.APIBaseUrl + "/api/Authorizations/Roles/Manage-User-Role/" + id,
            AccessToken = token
        });
    }

    public async Task<T> UpdateUserRole<T>(UpdateUserRolesRequest userRoleDto, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.PUT,
            Data = userRoleDto,
            Url = ApiBase.APIBaseUrl + "/api/Authorizations/Roles/Update-User-Role",
            AccessToken = token
        });
    }

    public async Task<T> GetUserClaim<T>(Guid id, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.GET,
            Url = ApiBase.APIBaseUrl + "/api/Authorizations/Claims/Manage-User-Claim/" + id,
            AccessToken = token
        });
    }

    public async Task<T> UpdateUserClaim<T>(UpdateUserClaimsRequest userClaimDto, string token)
    {
        return await this.SendAsync<T>(new ApiRequest()
        {
            ApiType = ApiBase.APIType.PUT,
            Data = userClaimDto,
            Url = ApiBase.APIBaseUrl + "/api/Authorizations/Claims/Update-User-Claim",
            AccessToken = token
        });
    }
}

