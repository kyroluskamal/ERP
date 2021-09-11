using ERP.Areas.Tenants.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace ERP.Areas.Tenants.Data
{
    public class TenantsDbContext : DbContext
    {
        public TenantsDbContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<TenantsInfo> Tenants { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Tenants;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TenantsInfo>()
                .HasIndex(u => u.Subdomain)
                .IsUnique();
            builder.Entity<TenantsInfo>()
                .HasIndex(u => u.ConnectionString)
                .IsUnique();
            builder.Entity<TenantsInfo>()
                .HasIndex(u => u.Username)
                .IsUnique();
            builder.Entity<TenantsInfo>()
                .HasIndex(u => u.Email)
                .IsUnique();
            base.OnModelCreating(builder);
        }
    }
}
