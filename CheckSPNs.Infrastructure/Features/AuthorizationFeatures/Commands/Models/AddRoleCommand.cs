using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class AddRoleCommand : IRequest<Result>
    {
        public string RoleName { get; set; }
    }
}
