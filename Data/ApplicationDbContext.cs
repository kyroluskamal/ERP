using ERP.Data.Identity;
using ERP.Models;
using ERP.Models.COC;
using ERP.Models.Employee;
using ERP.Models.Employee.Shifts;
using ERP.Models.Generals;
using ERP.Models.OrganizationalStructure;
using ERP.Models.TreasuriesAndBankAccount;
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
        //Employees datasets
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeeNote> EmployeeNotes { get; set; }
        public DbSet<EmployeeShifts> EmployeeShifts { get; set; }
        //Treasuries and Bank accounts dbsets
        public DbSet<Treasuries> Treasuries { get; set; }
        public DbSet<Treasury_description> Treasury_Descriptions { get; set; }
        public DbSet<BankAccounts> BankAccounts { get; set; }
        public DbSet<BankAccount_Description> BankAccount_Descriptions { get; set; }

        //COC dbsets
        public DbSet<COC> COCs { get; set; }
        public DbSet<Business_COC> Business_COCs { get; set; }
        public DbSet<Individual_COC> Individual_COCs { get; set; }
        public DbSet<COCAddress> COCAddresses { get; set; }
        public DbSet<COC_ContactList> COC_ContactList { get; set; }
        public DbSet<ClientNotes> ClientNotes { get; set; }
        public DbSet<ClientStatus> ClientStatuses { get; set; }

        //Generals dbsets
        public DbSet<Actions> Actions { get; set; }
        public DbSet<AutomaticReminders> AutomaticReminders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<EmailsTemplates> EmailsTemplates { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<WhenRemidersSent> WhenRemidersSents { get; set; }

        //Organizational structure
        public DbSet<Department> Departments { get; set; }
        public DbSet<Department_description> Department_Descriptions { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Designation_description> Designation_Descriptions { get; set; }
        public DbSet<EmployeeLevel> EmployeeLevels { get; set; }
        public DbSet<EmployeeLevel_desc> EmployeeLevel_descs { get; set; }
        public DbSet<EmployeeTypes_desc> EmployeeTypes_descs { get; set; }
        public DbSet<EmployeeTypes> EmployeeTypes { get; set; }

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

            builder.Entity<ConstactList_PerCOC>()
                .HasKey(p => new { p.COCId, p.COC_ContactListId }).IsClustered(); 
            builder.Entity<Category_PerClient>()
                .HasKey(p => new { p.COCId, p.COC_categoryId }).IsClustered();
        }
    }
}

