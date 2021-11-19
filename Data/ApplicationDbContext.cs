using ERP.Data.Identity;
using ERP.Models;
using ERP.Models.Attendance;
using ERP.Models.Attendance.AttendenceSettings;
using ERP.Models.Bookings;
using ERP.Models.Branches;
using ERP.Models.Checks;
using ERP.Models.COC;
using ERP.Models.CreditNotes;
using ERP.Models.CRMSystem;
using ERP.Models.CutomFields;
using ERP.Models.Employee;
using ERP.Models.Employee.Shifts;
using ERP.Models.Estimates;
using ERP.Models.Generals;
using ERP.Models.Insurance;
using ERP.Models.Inventory;
using ERP.Models.Items;
using ERP.Models.Membership;
using ERP.Models.NumberingSystem;
using ERP.Models.OrganizationalStructure;
using ERP.Models.Payroll;
using ERP.Models.PointsAndCredits;
using ERP.Models.PointsAndCredits.Settings;
using ERP.Models.PriceLists;
using ERP.Models.Purchases;
using ERP.Models.Purchases.PurphaseRefund;
using ERP.Models.Sales;
using ERP.Models.Sales.SalesCommissions;
using ERP.Models.Sales.Settings;
using ERP.Models.Service;
using ERP.Models.Subscription;
using ERP.Models.Supplier;
using ERP.Models.SystemsInErp;
using ERP.Models.TreasuriesAndBankAccount;
using ERP.Models.WorkOrder;
using ERP.Models.WorkOrder.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ERP.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationUserRole, int, IdentityUserClaim<int>, ApplicationUserUserRoles,
    IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        //Employees datasets
        #region Employees datasets
        public DbSet<Employees> Employees { get; set; }
        public DbSet<EmployeeNote> EmployeeNotes { get; set; }
        public DbSet<EmployeeShifts> EmployeeShifts { get; set; }
        public DbSet<Employees_customFields> Employees_customFields { get; set; }
        #endregion

        //Treasuries and Bank accounts dbsets
        #region Treasuries and Bank accounts dbsets
        public DbSet<Treasuries> Treasuries { get; set; }
        public DbSet<Treasury_description> Treasury_Descriptions { get; set; }
        public DbSet<BankAccounts> BankAccounts { get; set; }
        public DbSet<BankAccount_Description> BankAccount_Descriptions { get; set; }
        #endregion

        //COC dbsets
        #region COC dbsets
        public DbSet<COC> COCs { get; set; }
        public DbSet<Business_COC> Business_COCs { get; set; }
        public DbSet<Individual_COC> Individual_COCs { get; set; }
        public DbSet<COCAddress> COCAddresses { get; set; }
        public DbSet<COC_ContactList> COC_ContactList { get; set; }
        public DbSet<ClientNotes> ClientNotes { get; set; }
        public DbSet<ClientStatus> ClientStatuses { get; set; }
        public DbSet<COC_CustomFields> COC_CustomFields { get; set; }
        #endregion

        //Generals dbsets
        #region Generals dbsets
        public DbSet<Actions> Actions { get; set; }
        public DbSet<AutomaticReminders> AutomaticReminders { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<EmailsTemplates> EmailsTemplates { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<WhenRemidersSent> WhenRemidersSents { get; set; }
        public DbSet<PaymentMethods> PaymentMethods { get; set; }
        #endregion

        //Organizational structure
        #region Organizational structure
        public DbSet<Department> Departments { get; set; }
        public DbSet<Department_description> Department_Descriptions { get; set; }
        public DbSet<Designation> Designations { get; set; }
        public DbSet<Designation_description> Designation_Descriptions { get; set; }
        public DbSet<EmployeeLevel> EmployeeLevels { get; set; }
        public DbSet<EmployeeLevel_desc> EmployeeLevel_descs { get; set; }
        public DbSet<EmployeeTypes_desc> EmployeeTypes_descs { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        #endregion

        //Items
        #region Items
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
        public DbSet<Items_CustomFields> Items_CustomFields { get; set; }
        #endregion

        //Services Dbsets
        #region Services Dbsets
        public DbSet<Services> Services { get; set; }
        public DbSet<Service_CustomFields> Service_CustomFields { get; set; }
        public DbSet<ServiceDescription> ServiceDescriptions { get; set; }
        public DbSet<ServiceMainCategory> ServiceMainCategories { get; set; }
        public DbSet<ServiceNotes> ServiceNotes { get; set; }
        public DbSet<ServiceSubCategory> ServiceSubCategories { get; set; }
        public DbSet<ServiceTaxSettings> ServiceTaxSettings { get; set; }
        #endregion

        //Custom Fields
        #region Custom Fields
        public DbSet<Field_Choices> Field_Choices { get; set; }
        public DbSet<Fields_layout> Fields_layouts { get; set; }
        public DbSet<Fields_Per_Service> Fields_Per_Service { get; set; }
        public DbSet<Fields_Properties> Fields_Properties { get; set; }
        public DbSet<Fields_validation_Foreach_Service> Fields_validation_Foreach_Services { get; set; }
        public DbSet<FieldsInSystem> FieldsInSystem { get; set; }
        public DbSet<MinAndMaxDate> MinAndMaxDate { get; set; }
        public DbSet<MinAndMaxNumbers> MinAndMaxNumbers { get; set; }
        #endregion

        //Attendance
        #region Attendance
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
        #endregion

        //Attendance settings
        #region Attendance settings
        public DbSet<AttendanceFlag> AttendanceFlags { get; set; }
        public DbSet<AttendanceSettings> AttendanceSettings { get; set; }
        public DbSet<DaysOff_HolidayLists> DaysOff_HolidayLists { get; set; }
        public DbSet<HolidayLists> HolidayLists { get; set; }
        public DbSet<VacationPolicy_Type> VacationPolicy_Types { get; set; }
        public DbSet<VacationsPolicy_LeavePolicy> VacationsPolicy_LeavePolicies { get; set; }
        public DbSet<VacationsType_LeaveType> VacationsType_LeaveTypes { get; set; }
        #endregion

        //Branches
        #region Branches
        public DbSet<BusinessBranches> BusinessBranches { get; set; }
        public DbSet<BranchesSettings> BranchesSettings { get; set; }
        public DbSet<BranchesAddress> BranchesAddresses { get; set; }
        #endregion

        //Systems In ERP
        public DbSet<SystemsInERP> SystemsInERP { get; set; }

        //Inventories
        #region Inventories
        public DbSet<Addition_NoExpire> Addition_NoExpires { get; set; }
        public DbSet<Addition_WithExpire> Addition_WithExpire { get; set; }
        public DbSet<Inbound_Invent_Requisitions> Inbound_Invent_Requisitions { get; set; }
        public DbSet<InboundNotes> InboundNotes { get; set; }
        public DbSet<Inventories> Inventories { get; set; }
        public DbSet<InventoryAddress> InventoryAddresses { get; set; }
        public DbSet<Items_NoEpire> Items_NoEpires { get; set; }
        public DbSet<Items_withEpire> Items_withEpires { get; set; }
        public DbSet<Outbound_Invent_Requisitions> Outbound_Invent_Requisitions { get; set; }
        public DbSet<OutboundNotes> OutboundNotes { get; set; }
        public DbSet<TransferBetweenInvent> TransferBetweenInvents { get; set; }
        public DbSet<TransferBetweenInvent_notes> TransferBetweenInvent_notes { get; set; }
        public DbSet<Withdraw_NoExpire> Withdraw_NoExpires { get; set; }
        public DbSet<Withdraw_WithExpire> Withdraw_WithExpires { get; set; }
        #endregion

        //PriceLists
        #region PriceLists
        public DbSet<PriceList> PriceLists { get; set; }
        public DbSet<PriceList_items> PriceList_Items { get; set; }
        public DbSet<PriceList_Services> priceList_Services { get; set; }
        #endregion

        //Checks
        #region Checks
        public DbSet<CheckBook> CheckBooks { get; set; }
        public DbSet<CheckBook_Notes> CheckBook_Notes { get; set; }
        public DbSet<PayableCheck> PayableChecks { get; set; }
        public DbSet<PayableCheck_Attachments> PayableCheck_Attachments { get; set; }
        public DbSet<PayableCheck_Description> PayableCheck_Descriptions { get; set; }
        public DbSet<ReceivableCheck> ReceivableChecks { get; set; }
        public DbSet<ReceivableCheck_Attachments> ReceivableCheck_Attachments { get; set; }
        public DbSet<ReceivableCheck_Description> ReceivableCheck_Descriptions { get; set; }
        public DbSet<ReceivableCheck_Endorsement> ReceivableCheck_Endorsements { get; set; }
        #endregion

        //Estimates
        #region Estimates
        public DbSet<Estimate> Estimates { get; set; }
        public DbSet<EstimatesAttachments> EstimatesAttachments { get; set; }
        public DbSet<EstimatesShippingFees> EstimatesShippingFees { get; set; }
        public DbSet<EstimatesNotes> EstimatesNotes { get; set; }
        public DbSet<Estimates_Client> Estimates_Clients { get; set; }
        public DbSet<Estimates_Items> Estimates_Items { get; set; }
        public DbSet<Estimates_Services> Estimates_Services { get; set; }
        public DbSet<EstimatesStatus> EstimatesStatuses { get; set; }
        #endregion

        //NumberingSystem
        #region NumberingSystem
        public DbSet<NumberingSettings> NumberingSettings { get; set; }
        public DbSet<NumberSettings_Prefixes> NumberSettings_Prefixes { get; set; }
        #endregion

        //WorkOrders
        #region WorkOrders
        public DbSet<WorkOrders> WorkOrders { get; set; }
        public DbSet<WorkOrders_Attachments> WorkOrders_Attachments { get; set; }
        public DbSet<WorkOrders_Description> WorkOrders_Descriptions { get; set; }
        public DbSet<WorkOrdersClients> WorkOrdersClients { get; set; }
        public DbSet<WorkOrdersEmployees> WorkOrdersEmployees { get; set; }
        public DbSet<WorkOrdersActions> WorkOrdersActions { get; set; }
        public DbSet<WorkOrderStatus> WorkOrderStatuses { get; set; }
        #endregion

        //Suppliers
        #region Suppliers
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<SupplierAddresses> SupplierAddresses { get; set; }
        public DbSet<Supplier_notes> Supplier_notes { get; set; }
        public DbSet<Supplier_CustomFields> Supplier_CustomFields { get; set; }
        public DbSet<Supplier_ContactList> Supplier_ContactLists { get; set; }
        #endregion

        //Purchases
        #region Purchases
        public DbSet<Purchase_invoices> Purchase_invoices { get; set; }
        public DbSet<Purchases_discount> Purchases_discounts { get; set; }
        public DbSet<Purchases_paymentTerms> Purchases_paymentTerms { get; set; }
        public DbSet<Purchases_shippingFees> Purchases_shippingFees { get; set; }
        public DbSet<Purchase_Attachments> Purchase_Attachments { get; set; }
        public DbSet<Purchases_Deposits> Purchases_Deposits { get; set; }
        public DbSet<PurchasePaymentMethods> PurchasePaymentMethods { get; set; }
        public DbSet<Purchase_Payments> Purchase_Payments { get; set; }
        public DbSet<PurchaseStatus> PurchaseStatuses { get; set; }
        public DbSet<Items_In_PurchaseInvoice> Items_In_PurchaseInvoices { get; set; }
        public DbSet<PurchasesInvoice_Services> PurchasesInvoice_Services { get; set; }
        //PurchasesFunds
        public DbSet<Purchase_RefundRequests> Purchase_RefundRequests { get; set; }
        public DbSet<Items_in_Refund> Items_in_Refunds { get; set; }
        public DbSet<Refunds_Notes> Refunds_Notes { get; set; }
        public DbSet<Purchase_RefundedServices> Purchase_RefundedServices { get; set; }
        public DbSet<Refunds_Attachments> Refunds_Attachments { get; set; }
        public DbSet<Refunds_items_ShippingFees> Refunds_items_ShippingFees { get; set; }
        public DbSet<RefundsStatus> RefundsStatuses { get; set; }
        #endregion

        //CRP System
        #region CRM System
        public DbSet<Appointments> Appointments { get; set; }
        public DbSet<BookingSettings_AssignedEmployee> Appointments_AssignedEmployees { get; set; }
        public DbSet<Appointments_Notes> Appointments_Notes { get; set; }
        public DbSet<Appointments_Actions> Appointments_Actions { get; set; }
        #endregion

        //Insurance
        #region Insurance
        public DbSet<InsuranceAgent> InsuranceAgents { get; set; }
        public DbSet<Insurance_description> Insurance_descriptions { get; set; }
        public DbSet<Insurance_Attachments> Insurance_Attachments { get; set; }
        #endregion

        //Bookings
        #region Bookings
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Booking_Services> Booking_Services { get; set; }
        public DbSet<Booking_Clients> Booking_Clients { get; set; }
        public DbSet<Booking_settings> Booking_settings { get; set; }
        public DbSet<BookingSettings_AssignedEmployee> BookingSettings_AssignedEmployees { get; set; }
        #endregion

        //Points&Credits
        #region Points&Credits
        public DbSet<Packages> Packages { get; set; }
        public DbSet<Packages_Description> Packages_Descriptions { get; set; }
        public DbSet<CreditUsage> CreditUsages { get; set; }
        public DbSet<CreditUsage_description> CreditUsage_descriptions { get; set; }
        public DbSet<Packages_CreditType> Packages_CreditType { get; set; }
        public DbSet<CreditCharge> CreditCharges { get; set; }
        public DbSet<CreditCharge_description> CreditCharge_descriptions { get; set; }
        //Settings
        public DbSet<CreditTypes> CreditTypes { get; set; }
        public DbSet<CreditTypeDescriptions> CreditTypeDescriptions { get; set; }
        #endregion

        //Membership
        #region Membership
        public DbSet<Memberships> Memberships { get; set; }
        public DbSet<MembershipDescription> MembershipDescriptions { get; set; }
        #endregion

        //Subscriptions
        #region Subscriptions
        public DbSet<Subscriptions> Subscriptions { get; set; }
        public DbSet<SubscriptionAttachments> SubscriptionAttachments { get; set; }
        public DbSet<Subscription_Terms> Subscription_Terms { get; set; }
        public DbSet<Subscription_Notes> Subscription_Notes { get; set; }
        public DbSet<Subscription_Invoices> Subscription_Invoices { get; set; }
        public DbSet<Subscription_AutomaticReminders> Subscription_AutomaticReminders { get; set; }
        #endregion

        //Payroll
        #region Payroll
        public DbSet<Payslips> Payslips { get; set; }
        public DbSet<SalaryComponents> SallaryComponents { get; set; }
        public DbSet<SalaryStructures> SalaryStructures { get; set; }
        public DbSet<SalaryEarning> SalaryEarnings { get; set; }
        public DbSet<SalaryDetuction> SalaryDetuction { get; set; }
        public DbSet<SalaryComponentsFormula> SalaryComponentsFormulas { get; set; }
        public DbSet<SalaryComponentsAmount> SalaryComponentsAmounts { get; set; }
        public DbSet<SalaryStructures_earns> SalaryStructures_earns { get; set; }
        public DbSet<SalaryStructures_Deduction> SalaryStructures_Deduction { get; set; }
        public DbSet<Loans> Loans { get; set; }
        public DbSet<LoanNotes> LoanNotes { get; set; }
        public DbSet<Payslips_Earns> Payslips_Earns { get; set; }
        public DbSet<Payslips_Deduction> Payslips_Deductions { get; set; }
        public DbSet<Contracts> Contracts { get; set; }
        public DbSet<Contracts_earns> Contracts_earns { get; set; }
        public DbSet<Contracts_Deduction> Contracts_Deductions { get; set; }
        public DbSet<Contract_Per_Emp> Contract_Per_Emps { get; set; }
        public DbSet<ContractEndDate> ContractEndDates { get; set; }
        public DbSet<ContractsAttachments> ContractsAttachments { get; set; }
        public DbSet<ContractDuration> ContractDurations { get; set; }
        #endregion

        //CreditNote
        #region CreditNote
        public DbSet<CreditNote> CreditNotes { get; set; }
        public DbSet<CreditNote_Notes> CreditNote_Notes { get; set; }
        public DbSet<CreditNote_Attachments> CreditNote_Attachments { get; set; }
        public DbSet<CreditNtotes_Client> CreditNtotes_Client { get; set; }
        public DbSet<CreditNote_Items> CreditNote_Items { get; set; }
        public DbSet<CreditNote_Services> CreditNote_Services { get; set; }
        #endregion

        //Sales
        public DbSet<SalesInvoices> SalesInvoices { get; set; }
        public DbSet<ShippingDetails> ShippingDetails { get; set; }
        public DbSet<SalesInvoicesStatus> SalesInvoicesStatuses { get; set; }
        public DbSet<Status_For_EachInvoice> Statuses_For_EachInvoice { get; set; }
        public DbSet<SalesInvoicePayments> SalesInvoicePayments { get; set; }
        public DbSet<SalesInvoicePayments> SalesInvoice_PaymentStatuses { get; set; }
        public DbSet<SalesInvoicePayments_Notes> SalesInvoicePayments_Notes { get; set; }
        public DbSet<SalesInvoicePayments_Details> SalesInvoicePayments_Details { get; set; }
        public DbSet<SalesInvoicePayments_Attachments> SalesInvoicePayments_Attachments { get; set; }
        public DbSet<SalesInvoices_Attachments> SalesInvoices_Attachments { get; set; }
        public DbSet<SalesInvoice_TotalDsicount> SalesInvoice_TotalDsicounts { get; set; }
        public DbSet<SalesTerms> TermsAndConditions { get; set; }
        public DbSet<Terms_Per_Invoice> Terms_Per_Invoice { get; set; }
        public DbSet<SalesInvoice_AutomaticReminders> SalesInvoice_AutomaticReminders { get; set; }
        public DbSet<ServicesInSalesInvices> ServicesInSalesInvices { get; set; }
        public DbSet<DiscountsPerService> DiscountsPerService { get; set; }
        public DbSet<TaxPerService_PerInvoice> TaxPerService_PerInvoices { get; set; }
        public DbSet<ItemsInSalesInvoices> ItemsInSalesInvoices { get; set; }
        public DbSet<TaxPer_Item_PerInvoice> TaxPer_Item_PerInvoice { get; set; }
        public DbSet<RefundedItems> RefundedItems { get; set; }
        public DbSet<RefundedServices> RefundedServices { get; set; }
        public DbSet<DiscountsPerItem> DiscountsPerItems { get; set; }
        //Settings
        public DbSet<SalesInvoices_CustomFields> SalesSettings { get; set; }
        public DbSet<ShippingOptions> ShippingOptions { get; set; }
        public DbSet<OtherSettings> OtherSettings { get; set; }
        //Sales Commissions
        public DbSet<Commissions> Commissions { get; set; }
        public DbSet<CommissionsNotes> CommissionsNotes { get; set; }
        public DbSet<Commissions_Per_employee> Commissions_Per_employee { get; set; }
        public DbSet<Commissions_Services> Commissions_Services { get; set; }
        public DbSet<Commissions_SerCat> Commissions_SerCat { get; set; }
        public DbSet<Commissions_items> Commissions_items { get; set; }
        public DbSet<Commissions_ItemCat> Commissions_ItemCats { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Units>().Property(x => x.ConversionRate)
                .HasComputedColumnSql("[NumberInWholeSale] * [NumberInRetailSale]");
            builder.Entity<Units>().HasIndex(x => x.WholeSaleUnit).IsUnique();
            builder.Entity<ItemMainCategory>().HasIndex(x => x.Name).IsUnique();
            builder.Entity<Units>().HasIndex(x => x.WholeSaleUnit).IsUnique();
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

            builder.Entity<Employees_In_Branch>()
                .HasKey(p => new { p.EmployeeId, p.BranchId });
        }
    }
}

