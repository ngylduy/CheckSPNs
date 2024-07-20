using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Queries.Models
{
    public class GetListUserQuery : IRequest<Result<PagedResult<AppUsers>>>
    {
        public GetListUserQuery(int PageIndex, int PageSize)
        {
            this.PageIndex = PageIndex;
            this.PageSize = PageSize;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}
