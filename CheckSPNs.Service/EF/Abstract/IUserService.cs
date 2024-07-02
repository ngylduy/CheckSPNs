using CheckSPNs.Domain.Models.EF.Identity;

namespace CheckSPNs.Service.EF.Abstract;

public interface IUserService
{
    Task<AppUsers> CheckLogin(string username, string password);
}