using CheckSPNs.Domain;
using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Queries.Models;
using CheckSPNs.Infrastructure.Shared;
using CheckSPNs.Service.EF.Abstract;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using static CheckSPNs.Domain.Exceptions.AppUserException;

namespace CheckSPNs.Infrastructure.Features.IdentityFeatures.Authentication.Queries.Handlers
{
    public class AuthenticationQueryHandler : IRequestHandler<LoginQuery, Result<JwtModel>>,
        IRequestHandler<TokenQuery, Result<JwtModel>>
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUsers> _userManager;
        private readonly SignInManager<AppUsers> _signInManager;

        public AuthenticationQueryHandler(ITokenService tokenService, UserManager<AppUsers> userManager, SignInManager<AppUsers> signInManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<Result<JwtModel>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            //Check user
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user is null)
            {
                throw new UserNotFoundException(request.Email);
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
            {
                throw new UserNotFoundException(request.Email);
            }

            if (!user.EmailConfirmed)
            {
                throw new UserNotFoundException(request.Email);
            }

            //Jwt generate

            var response = await _tokenService.GetJWTToken(user);

            return Result.Success(response);
        }

        public async Task<Result<JwtModel>> Handle(TokenQuery request, CancellationToken cancellationToken)
        {
            var principal = _tokenService.GetPrincipalFromExpiredToken(request.AccessToken);


            var email = principal.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email).Value;

            var response = await _tokenService.GetRefreshToken(email, request.AccessToken, request.RefreshToken);

            return Result.Success(response);
        }
    }
}
