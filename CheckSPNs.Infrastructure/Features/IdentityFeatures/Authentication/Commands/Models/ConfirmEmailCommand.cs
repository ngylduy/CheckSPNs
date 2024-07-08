using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Commands.Models
{
    public class ConfirmEmailCommand : IRequest<Result>
    {
        public Guid UserId { get; set; }
        public string Code { get; set; }
    }
}
