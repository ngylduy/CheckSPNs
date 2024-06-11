using CheckSPNs.Data;
using CheckSPNs.Data.Abstract;
using CheckSPNs.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public static void RegisterDI(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        }
    }
}
