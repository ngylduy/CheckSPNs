using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;

public class EditTypeOfReportCommand : IRequest<Result>
{
    public Guid Id { get; set; }
    public string TypeOfReport { get; set; }
}
