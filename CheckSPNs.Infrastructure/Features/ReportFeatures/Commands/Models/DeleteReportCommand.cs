using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Commands.Models
{
    public class DeleteReportCommand : IRequest<Result>
    {
        public Guid Id { get; set; }

        public DeleteReportCommand(Guid id)
        {
            Id = id;
        }
    }
}
