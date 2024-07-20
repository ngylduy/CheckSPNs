using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;
using SchoolProject.Core.Features.Authorization.Commands.Models;
namespace SchoolProject.Core.Features.Authorization.Commands.Handlers;

public class RoleCommandHandler :
    IRequestHandler<AddRoleCommand, Result>,
    IRequestHandler<EditRoleCommand, Result>,
    IRequestHandler<DeleteRoleCommand, Result>,
    IRequestHandler<UpdateUserRolesCommand, Result>
{
    private readonly IAuthorizationService _authorizationService;

    public RoleCommandHandler(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    public async Task<Result> Handle(AddRoleCommand request, CancellationToken cancellationToken)
    {
        await _authorizationService.AddRoleAsync(request.RoleName);
        return Result.Success();
    }

    public async Task<Result> Handle(EditRoleCommand request, CancellationToken cancellationToken)
    {
        await _authorizationService.EditRoleAsync(request);
        return Result.Success();
    }

    public async Task<Result> Handle(DeleteRoleCommand request, CancellationToken cancellationToken)
    {
        _authorizationService.DeleteRoleAsync(request.Id);
        return Result.Success();
    }

    public async Task<Result> Handle(UpdateUserRolesCommand request, CancellationToken cancellationToken)
    {
        await _authorizationService.UpdateUserRoles(request);
        return Result.Success();
    }
}
