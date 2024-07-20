using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Queries.Models;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Queries.Handlers
{
    public class ApplicationUserQueryHandler : IRequestHandler<GetListUserQuery, Result<PagedResult<AppUsers>>>,
        IRequestHandler<GetUserByIdQuery, Result<AppUsers>>
    {
        private readonly IUserService _userService;

        public ApplicationUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Result<PagedResult<AppUsers>>> Handle(GetListUserQuery request, CancellationToken cancellationToken)
        {
            var result = _userService.GetListUsers();
            var pageResult = await PagedResult<AppUsers>.CreateAsync(result, request.PageIndex, request.PageSize);
            return Result.Success(pageResult);
        }

        public async Task<Result<AppUsers>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _userService.GetUserById(request.Id);
            return Result.Success(result);
        }
    }
}
