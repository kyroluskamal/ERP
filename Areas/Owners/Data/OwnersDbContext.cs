using ERP.Areas.Owners.Models;
using ERP.Areas.Owners.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP.Areas.Owners.Data
{
    public class OwnersDbContext : IdentityDbContext<Owner, OwnerRole, string>
    {
        public OwnersDbContext(DbContextOptions<OwnersDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Owners;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Owner>().Property(e => e.Id).ValueGeneratedOnAdd();
        //}
    }
}
