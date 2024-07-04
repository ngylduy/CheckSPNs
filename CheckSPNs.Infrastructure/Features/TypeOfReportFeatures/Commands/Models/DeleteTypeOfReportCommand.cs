using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;

public class DeleteTypeOfReportCommand : IRequest<Result>
{
    public Guid Id { get; set; }

    public DeleteTypeOfReportCommand(Guid id)
    {
        Id = id;
    }
}
