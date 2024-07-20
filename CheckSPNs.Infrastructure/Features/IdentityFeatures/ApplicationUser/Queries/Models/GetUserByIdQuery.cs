using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Queries.Models
{
    public class GetUserByIdQuery : IRequest<Result<AppUsers>>
    {

        public GetUserByIdQuery(Guid id)
        {
            this.Id = id;
        }
        public Guid Id { get; set; }
    }
}
