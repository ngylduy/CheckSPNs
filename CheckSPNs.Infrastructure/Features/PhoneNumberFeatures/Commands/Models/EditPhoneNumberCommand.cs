using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models
{
    public class EditPhoneNumberCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
    }
}
