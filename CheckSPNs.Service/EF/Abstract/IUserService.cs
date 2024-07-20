using CheckSPNs.Domain.Models.EF.Identity;

namespace CheckSPNs.Service.EF.Abstract;

public interface IUserService
{
    Task AddUserAsync(AppUsers user, string password, CancellationToken cancellationToken);
    IQueryable<AppUsers> GetListUsers();
    Task<AppUsers> GetUserById(Guid id);
}