using CheckSPNs.Domain.DTO.Results;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace SchoolProject.Core.Features.Authorization.Quaries.Models
{
    public class ManageUserRolesQuery : IRequest<Result<ManageUserRolesResult>>
    {
        public Guid UserId { get; set; }
    }
}
