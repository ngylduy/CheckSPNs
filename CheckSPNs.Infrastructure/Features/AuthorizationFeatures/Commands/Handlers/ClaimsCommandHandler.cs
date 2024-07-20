using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;
using SchoolProject.Core.Features.Authorization.Commands.Models;

namespace SchoolProject.Core.Features.Authorization.Commands.Handlers
{
    public class ClaimsCommandHandler : IRequestHandler<UpdateUserClaimsCommand, Result>
    {
        private readonly IAuthorizationService _authorizationService;

        public ClaimsCommandHandler(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }
        public async Task<Result> Handle(UpdateUserClaimsCommand request, CancellationToken cancellationToken)
        {
            await _authorizationService.UpdateUserClaims(request);
            return Result.Success();
        }
    }
}
