using CheckSPNs.Infrastructure.Bases;
using CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Results;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.TypeOfReportFeatures.Queries.Models
{
    public class GetTypeOfReportListQuery : IRequest<Response<List<GetTypeOfReportListResponse>>>
    {
    }
}
