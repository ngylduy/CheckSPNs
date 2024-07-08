using AutoMapper;
using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Commands.Models;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.ApplicationUser.Commands.Handlers
{
    public class ApplicationUserHandler : IRequestHandler<AddUserCommand, Result>
    {

        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public ApplicationUserHandler(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<AppUsers>(request);
            await _userService.AddUserAsync(user, request.Password, cancellationToken);

            return Result.Success();
        }
    }
}
