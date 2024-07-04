using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Commands.Models
{
    public class ReportPhoneNumberCommand : IRequest<Result>
    {
        public string PhoneNumber { get; set; }
    }
}
