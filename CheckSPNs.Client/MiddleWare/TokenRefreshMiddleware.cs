using CheckSPNs.Client.Data.Model;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Domain;
using System.IdentityModel.Tokens.Jwt;

namespace CheckSPNs.Client.MiddleWare
{
    public class TokenRefreshMiddleware : IMiddleware
    {
        private readonly IAuthService _authService;

        public TokenRefreshMiddleware(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Session != null) // Ensure session is available
            {
                var accessToken = context.Session.GetString("AccessToken");

                if (!string.IsNullOrEmpty(accessToken) && IsTokenExpired(accessToken))
                {
                    await RefreshToken(context);
                }
            }

            await next(context);
        }

        private bool IsTokenExpired(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            return jwtToken.ValidTo < DateTime.UtcNow;
        }

        private async Task RefreshToken(HttpContext context)
        {
            var accessToken = context.Session.GetString("AccessToken");
            var refreshToken = context.Request.Cookies["RefreshToken"];

            if (string.IsNullOrEmpty(refreshToken))
            {
                context.Session.Remove("AccessToken");

                context.Response.Cookies.Delete("RefreshToken", new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddMinutes(5)
                });

                context.Response.Redirect("/login");
                return;
            }

            var response = await _authService.RefreshToken<Response<JwtModel>>(accessToken, refreshToken);


            if (response.isSuccess && response.value != null)
            {
                var newAccessToken = Convert.ToString(response.value.AccessToken);
                var newRefreshToken = Convert.ToString(response.value.RefreshToken);

                context.Session.SetString("AccessToken", newAccessToken);

                context.Response.Cookies.Append("RefreshToken", newRefreshToken, new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    SameSite = SameSiteMode.Strict,
                    Expires = DateTime.Now.AddMinutes(5)
                });
            }
            else
            {
                context.Response.Redirect("/login");
            }
        }
    }

}
