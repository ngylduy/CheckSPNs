using CheckSPNs.Domain.ViewModel;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models
{
    public class GetRecentReportPhoneNumberByTypeQuery : IRequest<Result<PagedResult<RecentReportPhoneNumberByType>>>
    {
        public GetRecentReportPhoneNumberByTypeQuery(int PageIndex, int PageSize, Guid TypeOfReport)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
            this.TypeOfReport = TypeOfReport;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public Guid TypeOfReport { get; set; }
    }
}
