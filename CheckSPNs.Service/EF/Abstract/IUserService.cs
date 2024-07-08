using CheckSPNs.Domain.Models.EF.Identity;

namespace CheckSPNs.Service.EF.Abstract;

public interface IUserService
{
    Task AddUserAsync(AppUsers user, string password, CancellationToken cancellationToken);
}