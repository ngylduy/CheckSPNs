using CheckSPNs.Domain;

namespace CheckSPNs.Service.EF.Abstract
{
    public interface IEmailsService
    {
        Task SendEmailAsync(CancellationToken cancellationToken, EmailRequest emailRequest);
    }
}
