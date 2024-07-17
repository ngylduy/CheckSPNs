using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.StatsFeatures.Queries.Models
{
    public class GetPhoneNumberTopReportQuery : IRequest<Result<PagedResult<PhoneNumbers>>>
    {
        public GetPhoneNumberTopReportQuery(int PageIndex, int PageSize)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
