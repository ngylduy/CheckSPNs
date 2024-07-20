using CheckSPNs.Client.Data;
using CheckSPNs.Client.Data.Service.Abstract;
using CheckSPNs.Client.Data.Service.Implementation;
using CheckSPNs.Client.MiddleWare;
using CheckSPNs.Domain.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace CheckSPNs.Client
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddSession();

            ApiBase.APIBaseUrl = builder.Configuration["ServiceUrls:BaseUrlAPI"];

            // Add services to the container.
            builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute(
                        "/Privacy",
                        "/chinh-sach.html"
                    );
                    options.Conventions.AddAreaPageRoute(
                        areaName: "Product",
                        pageName: "/Detail",
                        route: "/sanpham/{nameproduct?}"
                    );
                }
            );

            builder.Services.Configure<RouteOptions>(options =>
            {
                options.LowercaseUrls = true;
                options.LowercaseQueryStrings = true;
            });

            builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");

            builder.Services.AddHttpClient();
            builder.Services.AddHttpContextAccessor();

            JwtOption jwtOption = new JwtOption();
            builder.Configuration.GetSection(nameof(JwtOption)).Bind(jwtOption);
            builder.Services.Configure<JwtOption>(builder.Configuration.GetSection(nameof(JwtOption)));

            builder.Services.AddAuthentication(options =>
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

            builder.Services.AddAuthorization(option =>
            {
                option.AddPolicy("AllowViewStat", policy =>
                {
                    policy.RequireClaim("View Stat", "True");
                });
                option.AddPolicy("AllowDelete", policy =>
                {
                    policy.RequireClaim("Delete", "True");
                });
                option.AddPolicy("AllowEdit", policy =>
                {
                    policy.RequireClaim("Edit", "True");
                });
            });

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IStatService, StatService>();
            builder.Services.AddScoped<IPhoneNumberService, PhoneNumberService>();
            builder.Services.AddScoped<ITypeOfReportService, TypeOfReportService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IReportService, ReportService>();

            builder.Services.AddScoped<TokenRefreshMiddleware>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseSession();

            app.Use(async (context, next) =>
            {
                var token = context.Session.GetString("AccessToken");
                if (!string.IsNullOrEmpty(token))
                {
                    context.Request.Headers.Add("Authorization", $"Bearer {token}");
                }
                await next();
            });

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<TokenRefreshMiddleware>();

            //app.UseStatusCodePages("text/html", "<h1>Error! Status Code {0}</h1>");
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            //app.UseStatusCodePages(context =>
            //{
            //    var response = context.HttpContext.Response;
            //    if (response.StatusCode == 401 || response.StatusCode == 403)
            //    {
            //        response.Redirect("/errors/401");
            //    }
            //    return System.Threading.Tasks.Task.CompletedTask;
            //});

            app.MapRazorPages();

            app.Run();
        }
    }
}