using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models
{
    public class EditReportCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public string Comment { get; set; }
    }
}
