using ERP.Areas.Tenants.Models;
using ERP.Areas.Tenants.Services;
using ERP.Data.Identity;
using ERP.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ERP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, int, IdentityUserClaim<int>, ApplicationUserUserRoles,
    IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
                   .HasIndex(u => u.Email)
                   .IsUnique();
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Id)
                .IsUnique();
            builder.Entity<ApplicationUserRole>()
                .HasKey(o => o.Id);
            builder.Entity<ApplicationUserRole>()
                .Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Entity<ApplicationUser>()
                .HasMany(x => x.UserRole)
                .WithOne(x => x.AppUser)
                .HasForeignKey(x => x.UserId).IsRequired();
            builder.Entity<ApplicationUserRole>()
                .HasMany(x => x.UserRole)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId).IsRequired();

            builder.Entity<ApplicationUserUserRoles>().HasKey(p => new { p.UserId, p.RoleId });

            builder.Entity<ApplicationUserRole>()
                .HasKey(o => o.Id);
            builder.Entity<ApplicationUser>()
                .HasKey(o => o.Id);
            builder.Entity<ApplicationUserRole>()
                .Property(o => o.Id).ValueGeneratedOnAdd();
            builder.Entity<ApplicationUser>()
                .Property(o => o.Id).ValueGeneratedOnAdd();
        }
    }
}

