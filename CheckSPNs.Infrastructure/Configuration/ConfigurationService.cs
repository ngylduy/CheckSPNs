using CheckSPNs.Authentication.Service;
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
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            service.AddIdentity<AppUsers, AppRoles>()
                .AddEntityFrameworkStores<CheckSPNsContext>()
                .AddDefaultTokenProviders();
        }

        public static void RegisterMongoDb(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoDatabaseOptions>(
                builder.Configuration.GetSection(nameof(MongoDatabaseOptions))
            );
        }

        public static void RegisterDI(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            service.AddSingleton<IDistributedCacheService, DistributedCacheService>();

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<ITokenHandler, TokenHandler>();
            service.AddScoped<IExamScoreService, ExamScoreService>();

            service.AddScoped<ITypeOfReportService, TypeOfReportService>();
            service.AddScoped<IPhoneNumberService, PhoneNumberService>();
            service.AddScoped<IReportService, ReportService>();

            service.AddScoped<PasswordHasher<AppUsers>>();

            service.AddScoped<ICSVHelper, CSVHelper>();

            //MongoDb
            service.AddScoped<MongoDatabaseOptions>();
            service.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
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
