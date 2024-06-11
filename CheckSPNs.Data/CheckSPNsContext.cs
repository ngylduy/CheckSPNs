using CheckSPNs.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckSPNs.Data
{
    public class CheckSPNsContext : IdentityDbContext<AppUsers, AppRoles, Guid>
    {
        public CheckSPNsContext(DbContextOptions<CheckSPNsContext> options) : base(options)
        {
        }

        #region DbSet
        //public DbSet<AppUsers> AppUsers { get; set; } = null!;
        public DbSet<PhoneNumbers> PhoneNumbers { get; set; } = null!;
        public DbSet<Reports> Reports { get; set; } = null!;
        public DbSet<TypeOfReports> TypeOfReports { get; set; } = null!;
        public DbSet<ViewLogs> ViewLogs { get; set; } = null!;
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
