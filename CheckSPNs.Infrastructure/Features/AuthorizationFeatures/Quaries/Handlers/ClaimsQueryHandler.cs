using CheckSPNs.Domain.DTO.Results;
using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Authorization.Quaries.Models;

namespace SchoolProject.Core.Features.Authorization.Quaries.Handlers
{
    public class ClaimsQueryHandler : IRequestHandler<ManageUserClaimsQuery, Result<ManageUserClaimsResult>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly UserManager<AppUsers> _userManager;
        public ClaimsQueryHandler(
                                  IAuthorizationService authorizationService,
                                  UserManager<AppUsers> userManager)
        {
            _authorizationService = authorizationService;
            _userManager = userManager;
        }
        public async Task<Result<ManageUserClaimsResult>> Handle(ManageUserClaimsQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var result = await _authorizationService.ManageUserClaimData(user);
            return Result.Success(result);
        }
    }
}
