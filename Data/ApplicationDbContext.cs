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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, string>
    {
        //public IHttpContextAccessor _accessor;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>()
                   .HasIndex(u => u.Email)
                   .IsUnique();
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();
            builder.Entity<ApplicationUser>()
                .HasIndex(u => u.Id)
                .IsUnique();
            base.OnModelCreating(builder);
            //builder.Entity<ApplicationUser>(i =>
            //{
            //    i.ToTable("AspNetUsers");
            //    i.HasKey(x => x.Id).IsClustered(true);
            //}).UseIdentityColumns(1, 1);
            //builder.Entity<IdentityRole>(i =>
            //{
            //    i.ToTable("AspNetRoles");
            //    i.HasKey(x => x.Id);
            //});
            //builder.Entity<IdentityUserRole<string>>(i =>
            //{
            //    i.ToTable("AspNetUserRoles");
            //    i.HasKey(x => new { x.RoleId, x.UserId });
            //});
            //builder.Entity<IdentityUserLogin<string>>(i =>
            //{
            //    i.ToTable("AspNetUserLogins");
            //    i.HasKey(x => new { x.ProviderKey, x.LoginProvider });
            //});
            //builder.Entity<IdentityRoleClaim<string>>(i =>
            //{
            //    i.ToTable("AspNetRoleClaims");
            //    i.HasKey(x => x.Id);
            //});
            //builder.Entity<IdentityUserClaim<string>>(i =>
            //{
            //    i.ToTable("AspNetUserClaims");
            //    i.HasKey(x => x.Id);
            //});
            //builder.Entity<IdentityUserToken<string>>(i =>
            //{
            //    i.ToTable("AspNetUserTokens");
            //    i.HasKey(x => x.UserId);
            //});
        }
    }
}

