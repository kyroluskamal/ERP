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
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public IHttpContextAccessor _accessor;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<ApplicationUser>(i => {
        //        i.ToTable("Users");
        //        i.HasKey(x => x.Id).IsClustered(true);
        //    }).UseIdentityColumns(1,1);
        //    builder.Entity<ApplicationUserRole>(i => {
        //        i.ToTable("Role");
        //        i.HasKey(x => x.Id);
        //    });
        //    builder.Entity<IdentityUserRole<string>>(i => {
        //        i.ToTable("UserRole");
        //        i.HasKey(x => new { x.RoleId, x.UserId });
        //    });
        //    builder.Entity<IdentityUserLogin<string>>(i => {
        //        i.ToTable("UserLogin");
        //        i.HasKey(x => new { x.ProviderKey, x.LoginProvider });
        //    });
        //    builder.Entity<IdentityRoleClaim<string>>(i => {
        //        i.ToTable("RoleClaims");
        //        i.HasKey(x => x.Id);
        //    });
        //    builder.Entity<IdentityUserClaim<string>>(i => {
        //        i.ToTable("UserClaims");
        //        i.HasKey(x => x.Id);
        //    });
        //    builder.Entity<IdentityUserToken<string>>(i => {
        //        i.ToTable("UserToken");
        //        i.HasKey(x => x.UserId);
        //    });
        //}
    }
}

