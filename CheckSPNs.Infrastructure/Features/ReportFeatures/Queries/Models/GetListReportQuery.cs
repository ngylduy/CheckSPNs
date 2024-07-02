using CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Results;
using CheckSPNs.Service.Application.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.ReportFeatures.Queries.Models
{
    public class GetListReportQuery : IRequest<Result<PagedResult<GetListReportResponse>>>
    {
        public GetListReportQuery(int PageIndex, int PageSize)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
