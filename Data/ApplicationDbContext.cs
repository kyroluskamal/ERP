using ERP.Data.Identity;
using ERP.Models;
using ERP.Models.Attendance;
using ERP.Models.Attendance.AttendenceSettings;
using ERP.Models.COC;
using ERP.Models.CutomFields;
using ERP.Models.Employee;
using ERP.Models.Employee.Shifts;
using ERP.Models.Generals;
using ERP.Models.Items;
using ERP.Models.OrganizationalStructure;
using ERP.Models.SystemsInErp;
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
        public DbSet<Employees_customFields> Employees_customFields { get; set; }

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
        public DbSet<EmployeeType> EmployeeTypes { get; set; }

        //Items
        public DbSet<Brands> Brands { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Item_Units> Item_Units { get; set; }
        public DbSet<ItemBrands> ItemBrands { get; set; }
        public DbSet<ItemDescription> ItemDescriptions { get; set; }
        public DbSet<ItemMainCategory> ItemMainCategories { get; set; }
        public DbSet<ItemNotes> ItemNotes { get; set; }
        public DbSet<ItemSubCategory> ItemSubCategories { get; set; }
        public DbSet<ItemsVariant_RetailPrice> ItemsVariant_RetailPrices { get; set; }
        public DbSet<ItemVariant_WholeSalePrice> ItemVariant_WholeSalePrices { get; set; }
        public DbSet<ItemVariants> ItemVariants { get; set; }
        public DbSet<ItemTaxSettings> ItemTaxSettings { get; set; }
        public DbSet<Units> Units { get; set; }
        public DbSet<Item_Per_Subcategory> Item_Per_Subcategories { get; set; }

        //Custom Fields
        public DbSet<Field_Choices> Field_Choices { get; set; }
        public DbSet<Fields_layout> Fields_layouts { get; set; }
        public DbSet<Fields_Per_Service> Fields_Per_Service { get; set; }
        public DbSet<Fields_Properties> Fields_Properties { get; set; }
        public DbSet<Fields_validation_Foreach_Service> Fields_validation_Foreach_Services { get; set; }
        public DbSet<FieldsInSystem> FieldsInSystem { get; set; }
        public DbSet<MinAndMaxDate> MinAndMaxDate { get; set; }
        public DbSet<MinAndMaxNumbers> MinAndMaxNumbers { get; set; }

        //Attendance
        public DbSet<AttendanceDaysPerEmp> AttendanceDaysPerEmps { get; set; }
        public DbSet<AttendancePermission> AttendancePermissions { get; set; }
        public DbSet<AttendancePermission_DelayPermissions> AttendancePermission_DelayPermissions { get; set; }
        public DbSet<AttendancePermission_notes> AttendancePermission_notes { get; set; }
        public DbSet<AttendancePermission_VacationPerm> AttendancePermission_VacationPerms { get; set; }
        public DbSet<AttendanceSheet> AttendanceSheets { get; set; }
        public DbSet<ManualAttendanceEachDay> ManualAttendanceEachDays { get; set; }
        public DbSet<ManualAttendanceEachDay_notes> ManualAttendanceEachDay_notes { get; set; }
        public DbSet<ManualAttandanceEachDay_PresentStatus> ManualAttandanceEachDay_PresentStatuses { get; set; }
        public DbSet<ManualAttendanceEachDay_VacationStatus> ManualAttendanceEachDay_VacationStatus { get; set; }
        //Attendance settings
        public DbSet<AttendanceFlag> AttendanceFlags { get; set; }
        public DbSet<AttendanceSettings> AttendanceSettings { get; set; }
        public DbSet<DaysOff_HolidayLists> DaysOff_HolidayLists { get; set; }
        public DbSet<HolidayLists> HolidayLists { get; set; }
        public DbSet<VacationPolicy_Type> VacationPolicy_Types { get; set; }
        public DbSet<VacationsPolicy_LeavePolicy> VacationsPolicy_LeavePolicies { get; set; }
        public DbSet<VacationsType_LeaveType> VacationsType_LeaveTypes { get; set; }

        //Systems In ERP
        public DbSet<SystemsInERP> SystemsInERP { get; set; }

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

