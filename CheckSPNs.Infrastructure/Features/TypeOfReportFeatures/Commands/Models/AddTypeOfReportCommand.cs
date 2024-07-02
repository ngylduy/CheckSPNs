using CheckSPNs.Infrastructure.Bases;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Commands.Models;

public class AddTypeOfReportCommand : IRequest<Response<string>>
{
    public string TypeOfReport { get; set; }
}
