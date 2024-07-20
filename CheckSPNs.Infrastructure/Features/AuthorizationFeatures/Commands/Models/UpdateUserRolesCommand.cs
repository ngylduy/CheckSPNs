using CheckSPNs.Domain.DTO.Requests;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class UpdateUserRolesCommand : UpdateUserRolesRequest, IRequest<Result>
    {
    }
}
