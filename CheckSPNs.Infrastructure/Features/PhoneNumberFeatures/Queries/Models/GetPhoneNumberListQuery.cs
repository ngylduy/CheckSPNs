using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.PhoneNumberFeatures.Queries.Models
{
    public class GetPhoneNumberListQuery : IRequest<Result<PagedResult<PhoneNumbers>>>
    {
        public GetPhoneNumberListQuery(int PageIndex, int PageSize)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
