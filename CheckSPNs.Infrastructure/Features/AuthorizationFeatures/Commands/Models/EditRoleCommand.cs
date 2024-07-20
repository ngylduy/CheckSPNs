using CheckSPNs.Domain.DTO.Requests;
using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class EditRoleCommand : EditRoleRequest, IRequest<Result>
    {

    }
}
