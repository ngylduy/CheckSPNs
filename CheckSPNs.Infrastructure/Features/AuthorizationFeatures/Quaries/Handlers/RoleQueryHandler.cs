using AutoMapper;
using CheckSPNs.Domain.DTO.Results;
using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Core.Features.Authorization.Quaries.Models;
using SchoolProject.Core.Features.Authorization.Quaries.Results;

namespace SchoolProject.Core.Features.Authorization.Quaries.Handlers
{
    public class RoleQueryHandler :
       IRequestHandler<GetRolesListQuery, Result<List<GetRolesListResult>>>,
       IRequestHandler<GetRoleByIdQuery, Result<GetRoleByIdResult>>,
       IRequestHandler<ManageUserRolesQuery, Result<ManageUserRolesResult>>
    {
        private readonly IAuthorizationService _authorizationService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUsers> _userManager;

        public RoleQueryHandler(
                                IAuthorizationService authorizationService,
                                IMapper mapper,
                                UserManager<AppUsers> userManager)
        {
            _authorizationService = authorizationService;
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<Result<List<GetRolesListResult>>> Handle(GetRolesListQuery request, CancellationToken cancellationToken)
        {
            var roles = await _authorizationService.GetRolesList();
            var result = _mapper.Map<List<GetRolesListResult>>(roles);
            return Result.Success(result);
        }

        public async Task<Result<GetRoleByIdResult>> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
        {
            var role = await _authorizationService.GetRoleById(request.Id);
            var result = _mapper.Map<GetRoleByIdResult>(role);
            return Result.Success(result);
        }

        public async Task<Result<ManageUserRolesResult>> Handle(ManageUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            var result = await _authorizationService.ManageUserRolesData(user);
            return Result.Success(result);
        }
    }
}
