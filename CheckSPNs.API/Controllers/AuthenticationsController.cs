using CheckSPNs.API.ViewModel;
using CheckSPNs.Authentication.Service;
using CheckSPNs.Domain;
using CheckSPNs.Service.EF.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CheckSPNs.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationsController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenHandler _tokenHandler;

        public AuthenticationsController(IUserService userService, ITokenHandler tokenHandler)
        {
            _userService = userService;
            _tokenHandler = tokenHandler;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Get([FromBody] AccountVM accountVM)
        {
            //throw new System.ArgumentNullException();

            var user = await _userService.CheckLogin(accountVM.Username, accountVM.Password);

            if (user is null)
            {
                return Unauthorized();
            }

            if (!user.EmailConfirmed)
            {
                return BadRequest("Your account is inactive");
            }

            string accessToken = await _tokenHandler.CreateAccessToken(user);
            string refreshToken = await _tokenHandler.CreateRefreshToken(user);

            return Ok(new JwtModel
            {
                AccessToken = accessToken,
                RefreshToken = new RefreshToken
                {
                    UserName = user.UserName,
                    TokenString = refreshToken
                }
            });
        }

    }
}
