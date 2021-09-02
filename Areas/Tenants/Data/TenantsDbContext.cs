using ERP.Areas.Tenants.Models;
using Microsoft.EntityFrameworkCore;

namespace ERP.Areas.Tenants.Data
{
    public class TenantsDbContext : DbContext
    {
        public TenantsDbContext()
        {
            Database.EnsureCreatedAsync();
        }

        public DbSet<TenantsInfo> Tenants;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Tenants;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
