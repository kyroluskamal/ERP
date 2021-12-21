using ERP.Areas.Owners.Models;
using ERP.Areas.Owners.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP.Areas.Owners.Data
{
    public class OwnersDbContext : IdentityDbContext<Owner, OwnerRole, int, IdentityUserClaim<int>, OwnerUserRole,
    IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public OwnersDbContext(DbContextOptions<OwnersDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Owners;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Owner>()
                   .HasIndex(u => u.Email)
                   .IsUnique();
            modelBuilder.Entity<Owner>()
                .HasIndex(u => u.PhoneNumber)
                .IsUnique();
            modelBuilder.Entity<Owner>()
                .HasIndex(u => u.Id)
                .IsUnique();
            modelBuilder.Entity<Owner>()
                .HasMany(x => x.UserRole)
                .WithOne(x => x.Owner)
                .HasForeignKey(x => x.UserId).IsRequired();
            modelBuilder.Entity<OwnerRole>()
                .HasMany(x => x.UserRole)
                .WithOne(x => x.Role)
                .HasForeignKey(x => x.RoleId).IsRequired();
            modelBuilder.Entity<Country>()
               .HasOne(x => x.Currency)
               .WithOne(x => x.Country)
               .HasForeignKey<Currency>(x => x.CountryId);
            modelBuilder.Entity<OwnerUserRole>().HasKey(p => new { p.UserId, p.RoleId });

            modelBuilder.Entity<OwnerRole>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<Owner>()
                .HasKey(o => o.Id);
            modelBuilder.Entity<OwnerRole>()
                .Property(o => o.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Owner>()
                .Property(o => o.Id).ValueGeneratedOnAdd();
        }
    }
}
