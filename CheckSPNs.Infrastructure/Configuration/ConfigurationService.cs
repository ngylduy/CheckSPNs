using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Data.EF.Context;
using CheckSPNs.Data.EF.Implementations;
using CheckSPNs.Data.MongoDb.Abstract;
using CheckSPNs.Data.MongoDb.Context;
using CheckSPNs.Data.MongoDb.Implementations;
using CheckSPNs.Domain.Models.EF.Identity;
using CheckSPNs.Infrastructure.Behaviors;
using CheckSPNs.Infrastructure.Mapping;
using CheckSPNs.Service.Cache;
using CheckSPNs.Service.CSV;
using CheckSPNs.Service.EF.Abstract;
using CheckSPNs.Service.EF.Implementations;
using CheckSPNs.Service.MongoDb.Abstract;
using CheckSPNs.Service.MongoDb.Implementations;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace CheckSPNs.Infrastructure.Configuration
{
    public static class ConfigurationService
    {
        public static void RegisterContextDb(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<CheckSPNsContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    options => options.MigrationsAssembly(typeof(CheckSPNsContext).Assembly.FullName)
            ));

            service.AddIdentity<AppUsers, AppRoles>(option =>
            {
                // Password settings.
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequiredLength = 6;
                option.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                option.Lockout.MaxFailedAccessAttempts = 5;
                option.Lockout.AllowedForNewUsers = true;

                // User settings.
                option.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                option.User.RequireUniqueEmail = true;
                option.SignIn.RequireConfirmedEmail = true;

            }).AddEntityFrameworkStores<CheckSPNsContext>().AddDefaultTokenProviders();

            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CheckSPNs Project", Version = "v1" });
                c.EnableAnnotations();
                c.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 12345abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = JwtBearerDefaults.AuthenticationScheme
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtBearerDefaults.AuthenticationScheme
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void RegisterMongoDb(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoDatabaseOptions>(
                builder.Configuration.GetSection(nameof(MongoDatabaseOptions))
            );
        }

        public static void RegisterDI(this IServiceCollection service)
        {
            service.AddScoped<PasswordHasher<AppUsers>>();
            service.AddScoped<PasswordValidator<AppUsers>>();

            service.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            service.AddTransient<IUrlHelper>(x =>
            {
                var actionContext = x.GetRequiredService<IActionContextAccessor>().ActionContext;
                var factory = x.GetRequiredService<IUrlHelperFactory>();
                return factory.GetUrlHelper(actionContext);
            });

            //Repository
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped<IDapperHelper, DapperHelper>();
            service.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            //Service cache
            service.AddSingleton<IDistributedCacheService, DistributedCacheService>();

            //Service identity
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IAuthenticationService, AuthenticationService>();
            service.AddScoped<IAuthorizationService, AuthorizationService>();
            service.AddScoped<ITokenService, TokenService>();

            //Service email
            service.AddScoped<IEmailsService, EmailsService>();

            //Service ExamScore
            service.AddScoped<IExamScoreService, ExamScoreService>();

            //Service check PhoneNumber
            service.AddScoped<ITypeOfReportService, TypeOfReportService>();
            service.AddScoped<IPhoneNumberService, PhoneNumberService>();
            service.AddScoped<IReportService, ReportService>();

            service.AddScoped<IStatService, StatService>();

            //Service CSV
            service.AddScoped<ICSVHelper, CSVHelper>();

            //MongoDb
            service.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            service.AddScoped<MongoDatabaseOptions>();
            service.AddScoped<IMongoContext, MongoContext>();
            service.AddScoped<IExamScoreService, ExamScoreService>();
        }

        public static void AddCoreDependencies(this IServiceCollection service)
        {
            //Configuration Of Mediator
            service.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(AssemblyReference.Assembly));

            //service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationDefaultBehavior<,>));

            service.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>));

            //Configuration Of FluentValidation
            service.AddValidatorsFromAssembly(Infrastructure.AssemblyReference.Assembly, includeInternalTypes: true);

            //Configuration Of Automapper
            service.AddAutoMapper(typeof(AutoMapperConfig).Assembly);
        }
    }
}
