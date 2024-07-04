using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models
{
    public class DeletePhoneNumberCommand : IRequest<Result>
    {
        public Guid Id { get; set; }

        public DeletePhoneNumberCommand(Guid id)
        {
            Id = id;
        }
    }
}
