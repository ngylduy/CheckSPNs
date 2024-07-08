using CheckSPNs.Domain.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CheckSPNs.Infrastructure.Configuration;

public static class ConfigurationTokenBear
{
    public static void RegisterTokenBear(this IServiceCollection services, IConfiguration configuration)
    {

        JwtOption jwtOption = new JwtOption();
        MailSettings mailSettings = new MailSettings();

        configuration.GetSection(nameof(JwtOption)).Bind(jwtOption);
        configuration.GetSection(nameof(MailSettings)).Bind(mailSettings);

        services.Configure<MailSettings>(configuration.GetSection(nameof(MailSettings)));
        services.Configure<JwtOption>(configuration.GetSection(nameof(JwtOption)));

        services.AddSingleton(jwtOption);
        services.AddSingleton(mailSettings);

        services.AddAuthentication(options =>
        {
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.SaveToken = true; //Save token to AuthenticationProperties

            var key = Encoding.UTF8.GetBytes(jwtOption.SecretKey);

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, //True on production
                ValidateIssuer = false, //True on production
                ValidateLifetime = true,
                ValidAudience = jwtOption.Audience,
                ValidIssuer = jwtOption.Issuer,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ClockSkew = TimeSpan.Zero
            };

            options.Events = new JwtBearerEvents()
            {
                OnAuthenticationFailed = context =>
                {
                    if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                    {
                        context.Response.Headers.Add("IS-TOKEN-EXPIRED", "true");
                    }
                    // Record log
                    return Task.CompletedTask;
                }
            };
        });

        services.AddAuthorization();
    }
}
