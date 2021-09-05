using ERP.Areas.Tenants.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ERP.Areas.Tenants.Data
{
    public class TenantsDbContext : DbContext
    {
        public TenantsDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<TenantsInfo> Tenants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Tenants;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
