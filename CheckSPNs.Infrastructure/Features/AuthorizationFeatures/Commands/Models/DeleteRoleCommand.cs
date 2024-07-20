using CheckSPNs.Infrastructure.Shared;
using MediatR;

namespace SchoolProject.Core.Features.Authorization.Commands.Models
{
    public class DeleteRoleCommand : IRequest<Result>
    {
        public Guid Id { get; set; }
        public DeleteRoleCommand(Guid id)
        {
            Id = id;
        }
    }
}
