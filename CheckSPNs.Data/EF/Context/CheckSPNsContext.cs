using CheckSPNs.Domain.Models.EF.CheckPhoneNumber;
using CheckSPNs.Domain.Models.EF.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CheckSPNs.Data.EF.Context
{
    public class CheckSPNsContext : IdentityDbContext<AppUsers, AppRoles, Guid>
    {

        private readonly IConfiguration _configuration;
        private readonly IServiceProvider _serviceProvider;

        public CheckSPNsContext(DbContextOptions<CheckSPNsContext> options,
                                    IConfiguration configuration,
                                    IServiceProvider serviceProvider) : base(options)
        {
            _configuration = configuration;
            _serviceProvider = serviceProvider;
        }

        #region DbSet
        //public DbSet<AppUsers> AppUsers { get; set; } = null!;
        public DbSet<PhoneNumbers> PhoneNumbers { get; set; } = null!;
        public DbSet<Reports> Reports { get; set; } = null!;
        public DbSet<TypeOfReports> TypeOfReports { get; set; } = null!;
        public DbSet<PhoneNumbersTypeOfReports> PhoneNumbersTypeOfReports { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRole");
            modelBuilder.Entity<PhoneNumbersTypeOfReports>()
                        .HasKey(bc => new { bc.PhoneNumbersId, bc.TypeOfReportsId });
            SeedData(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            string username = _configuration["DefaultUser:Username"];
            string email = _configuration["DefaultUser:Email"];
            string defaultRole = _configuration["DefaultUser:Role"];
            string password = _configuration["DefaultUser:Password"];

            using var scope = _serviceProvider.CreateScope();
            var passwordHasherService = scope.ServiceProvider.GetService<PasswordHasher<AppUsers>>();

            var roles = _configuration.GetSection("DefaultRole");

            if (roles.Exists())
            {
                foreach (var role in roles.GetChildren())
                {
                    Guid roleId = Guid.NewGuid();

                    modelBuilder.Entity<AppRoles>().HasData(new AppRoles
                    {
                        Id = roleId,
                        Name = role.Value,
                        NormalizedName = role.Value.ToUpper(),
                    });

                    if (role.Value == defaultRole)
                    {
                        defaultRole = roleId.ToString();
                    }
                }
            }

            Guid userId = Guid.NewGuid();

            modelBuilder.Entity<AppUsers>().HasData(
            new AppUsers
            {
                Id = userId,
                FirstName = "Admin",
                LastName = "Website",
                Dob = DateTime.Now,
                PictureUser = "default",
                Sex = "Male",
                DateCreated = DateTime.Now,
                UserName = username.ToLower(),
                NormalizedUserName = username.ToUpper(),
                Email = email,
                NormalizedEmail = email.ToUpper(),
                AccessFailedCount = 0,
                PasswordHash = passwordHasherService.HashPassword(new AppUsers
                {
                    UserName = username.ToLower(),
                    NormalizedUserName = username.ToUpper(),
                    Email = email,
                    NormalizedEmail = email.ToUpper()
                }, password)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = new Guid(defaultRole),
                UserId = userId,
            });
        }
    }
}
