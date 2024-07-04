using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Results;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Models
{
    public class GetTypeOfReportListQuery : IRequest<Result<List<GetTypeOfReportListResponse>>>
    {
    }
}
