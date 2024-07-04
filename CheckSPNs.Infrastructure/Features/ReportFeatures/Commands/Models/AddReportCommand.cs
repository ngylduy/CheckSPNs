using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models
{
    public class AddReportCommand : IRequest<Result>
    {
        public string PhoneNumber { get; set; }
        public string Comment { get; set; }
    }
}
