namespace CheckSPNs.Service.EF.Abstract
{
    public interface IAuthenticationService
    {
        Task ConfirmEmail(Guid userId, string? code);
    }
}
