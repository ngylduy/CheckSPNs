using CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Commands.Models;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : IRequestHandler<ConfirmEmailCommand, Result>
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthenticationCommandHandler(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public async Task<Result> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
        {
            await _authenticationService.ConfirmEmail(request.UserId, request.Code);

            return Result.Success();
        }
    }
}
