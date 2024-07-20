using CheckSPNs.Domain.DTO.Results;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace SchoolProject.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserClaimsQuery : IRequest<Result<ManageUserClaimsResult>>
    {
        public Guid UserId { get; set; }
    }
}
