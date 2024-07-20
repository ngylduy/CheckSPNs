using CheckSPNs.Infrastructure.Shared;
using MediatR;
using SchoolProject.Core.Features.Authorization.Quaries.Results;

namespace SchoolProject.Core.Features.Authorization.Quaries.Models
{
    public class GetRolesListQuery : IRequest<Result<List<GetRolesListResult>>>
    {
    }
}
