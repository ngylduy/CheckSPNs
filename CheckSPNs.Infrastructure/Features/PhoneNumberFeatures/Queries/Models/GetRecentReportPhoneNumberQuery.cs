using CheckSPNs.Domain.ViewModel;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models
{
    public class GetRecentReportPhoneNumberQuery : IRequest<Result<PagedResult<RecentReportPhoneNumber>>>
    {
        public GetRecentReportPhoneNumberQuery(int PageIndex, int PageSize)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
