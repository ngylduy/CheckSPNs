using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;

public class AddTypeOfReportCommand : IRequest<Result>
{
    public string TypeOfReport { get; set; }
}
