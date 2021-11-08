using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations.ApplicationDb
{
    public partial class ApplicationDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsClientOrStaffOrBoth = table.Column<byte>(type: "tinyint", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceFlags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Conditions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceFlags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnableSecondryShift = table.Column<bool>(type: "bit", nullable: false),
                    FiscalYearStartMonth = table.Column<byte>(type: "tinyint", nullable: false),
                    FiscalYearStartDay = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankAccounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountNo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Booking_settings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingTimeDivider = table.Column<int>(type: "int", nullable: false),
                    IsAssignedToStaff = table.Column<bool>(type: "bit", nullable: false),
                    IsOnlyOneService = table.Column<bool>(type: "bit", nullable: false),
                    BookingPaymentSettings = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeSpan>(type: "Time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "Time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BusinessBranches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Terlephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WorkingHours = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessBranches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COC_category",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COC_category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "COC_ContactList",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COC_ContactList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CreditTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditTypeName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AllowDecimal = table.Column<bool>(type: "bit", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Currencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Currencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DesignationName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmailsTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemplateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemplateContent = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailsTemplates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLevels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeLevelName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShifts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StandardOrAdvanced = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShifts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeTypeName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FieldsInSystem",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldsInSystem", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HolidayLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItemMainCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemMainCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DefaultInventoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    HasExpire = table.Column<bool>(type: "bit", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    HasSpecialOffer = table.Column<bool>(type: "bit", nullable: false),
                    HasNote = table.Column<bool>(type: "bit", nullable: false),
                    ItemSKU = table.Column<int>(type: "int", nullable: false),
                    AddByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OtherSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Disable_Edit_PerItem_InInvoice = table.Column<bool>(type: "bit", nullable: false),
                    DisableEstimateModule = table.Column<bool>(type: "bit", nullable: false),
                    IsManualInvoiceNumber = table.Column<bool>(type: "bit", nullable: false),
                    EnableInvoiceManualStatus = table.Column<bool>(type: "bit", nullable: false),
                    EnableEstimateManualStatus = table.Column<bool>(type: "bit", nullable: false),
                    AutoPayFromBalance = table.Column<bool>(type: "bit", nullable: false),
                    EnableMaximumDiscount = table.Column<bool>(type: "bit", nullable: false),
                    MaximumDiscount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Packages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    PackageType = table.Column<bool>(type: "bit", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Period = table.Column<int>(type: "int", nullable: false),
                    PeriodType = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayableChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CheckNo = table.Column<int>(type: "int", nullable: false),
                    ReceivedFromAccountId = table.Column<int>(type: "int", nullable: false),
                    NameOnCheck = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableChecks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PriceLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PurchasePaymentMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasePaymentMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReceivableChecks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CheckNo = table.Column<int>(type: "int", nullable: false),
                    ReceivedFromAccountId = table.Column<int>(type: "int", nullable: false),
                    CollectAccountId = table.Column<int>(type: "int", nullable: false),
                    NameOnCheck = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    IsEndorsed = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivableChecks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalaryStructures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PayrollFrequency = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryStructures", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoice_PaymentStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoice_PaymentStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoicesStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoicesStatuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SallaryComponents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DetuctionOrEarning = table.Column<bool>(type: "bit", nullable: false),
                    AmountOrFormula = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SallaryComponents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceMainCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceMainCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OpenedOrClosed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SystemsInERP",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SystemsInERP", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Percent = table.Column<byte>(type: "tinyint", nullable: false),
                    InclusiveOrExclusive = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxSettings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TermsAndConditions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Condtions = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TermsAndConditions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treasuries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasuries", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WholeSaleUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    RetailUnit = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    NumberInWholeSale = table.Column<short>(type: "smallint", nullable: false),
                    NumberInRetailSale = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationsPolicy_LeavePolicies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationsPolicy_LeavePolicies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VacationsType_LeaveTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxDaysAllowedPerYear = table.Column<short>(type: "smallint", nullable: false),
                    MaximumContinuousDaysApplicable = table.Column<byte>(type: "tinyint", nullable: false),
                    ApplicableAfter_HowManyDays = table.Column<byte>(type: "tinyint", nullable: false),
                    IsNeedPermission = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationsType_LeaveTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WhenRemidersSents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WhenOption = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WhenRemidersSents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BankAccount_Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BankAccountsId = table.Column<int>(type: "int", nullable: true),
                    BankAccountId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccount_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankAccount_Descriptions_BankAccounts_BankAccountsId",
                        column: x => x.BankAccountsId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BranchesAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchesAddresses_BusinessBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BusinessBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BranchesSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsCostCentersShared = table.Column<bool>(type: "bit", nullable: false),
                    IsClientShared = table.Column<bool>(type: "bit", nullable: false),
                    IsProducShared = table.Column<bool>(type: "bit", nullable: false),
                    IsSupplierShared = table.Column<bool>(type: "bit", nullable: false),
                    SpcifyAccountbranches = table.Column<bool>(type: "bit", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BranchesSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BranchesSettings_BusinessBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BusinessBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditTypeDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditTypeDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditTypeDescriptions_CreditTypes_CreditTypesId",
                        column: x => x.CreditTypesId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckBooks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckBookNo = table.Column<int>(type: "int", nullable: false),
                    FirstSerial = table.Column<int>(type: "int", nullable: false),
                    LastSerial = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true),
                    BankAccountsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBooks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckBooks_BankAccounts_BankAccountsId",
                        column: x => x.BankAccountsId,
                        principalTable: "BankAccounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckBooks_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientType = table.Column<bool>(type: "bit", nullable: false),
                    CreditLimit = table.Column<int>(type: "int", nullable: false),
                    CreditPeriodLimit = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "Money", nullable: false),
                    BalanceStartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    HasEstimates = table.Column<bool>(type: "bit", nullable: false),
                    HasCategory = table.Column<bool>(type: "bit", nullable: false),
                    HasNote = table.Column<bool>(type: "bit", nullable: false),
                    HasCustomFields = table.Column<bool>(type: "bit", nullable: false),
                    NationalId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileImage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    InvoicingMethod = table.Column<byte>(type: "tinyint", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCs_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCs_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COCs_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PayrollFrequency = table.Column<byte>(type: "tinyint", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasPymentTerms = table.Column<bool>(type: "bit", nullable: false),
                    HasDiscount = table.Column<bool>(type: "bit", nullable: false),
                    HasShippingFees = table.Column<bool>(type: "bit", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    IsRecieved = table.Column<bool>(type: "bit", nullable: false),
                    IsPartiallyPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsAlreadyPaid = table.Column<bool>(type: "bit", nullable: false),
                    ServiceOrItem = table.Column<bool>(type: "bit", nullable: false),
                    HasDeposits = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_invoices_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_RefundRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "Date", nullable: false),
                    RefundDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ServiceOrItem = table.Column<bool>(type: "bit", nullable: false),
                    HasPymentTerms = table.Column<bool>(type: "bit", nullable: false),
                    HasShippingFees = table.Column<bool>(type: "bit", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    TotalMoneyIsRefunded = table.Column<decimal>(type: "Money", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_RefundRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_RefundRequests_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    FinishDate = table.Column<DateTime>(type: "Date", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    HasCustomFields = table.Column<bool>(type: "bit", nullable: false),
                    HasCustomAttachments = table.Column<bool>(type: "bit", nullable: false),
                    IsItAssignedToEmp = table.Column<bool>(type: "bit", nullable: false),
                    Budget = table.Column<decimal>(type: "Money", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Designation_Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DesignationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designation_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Designation_Descriptions_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditNoteNumner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    IsConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ServiceOrItem = table.Column<bool>(type: "bit", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false),
                    TotalAmount = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EmailsTemplatesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditNotes_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditNotes_EmailsTemplates_EmailsTemplatesId",
                        column: x => x.EmailsTemplatesId,
                        principalTable: "EmailsTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeLevel_descs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployessLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeLevel_descs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeLevel_descs_EmployeeLevels_EmployessLevelId",
                        column: x => x.EmployessLevelId,
                        principalTable: "EmployeeLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShiftsTimeDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnDutyTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OffDutyTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BeginningIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndingIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    BeginningOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndingOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    LateTime = table.Column<byte>(type: "tinyint", maxLength: 3, nullable: false),
                    DaysOfWeeks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShiftId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftsTimeDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShiftsTimeDetails_EmployeeShifts_ShiftId",
                        column: x => x.ShiftId,
                        principalTable: "EmployeeShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTypes_descs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeeTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes_descs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeTypes_descs_EmployeeTypes_EmployeeTypesId",
                        column: x => x.EmployeeTypesId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DaysOff_HolidayLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    HolidayListsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaysOff_HolidayLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DaysOff_HolidayLists_HolidayLists_HolidayListsId",
                        column: x => x.HolidayListsId,
                        principalTable: "HolidayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ItemMainCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemSubCategories_ItemMainCategories_ItemMainCategoryId",
                        column: x => x.ItemMainCategoryId,
                        principalTable: "ItemMainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemBrands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    BrandsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemBrands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemBrands_Brands_BrandsId",
                        column: x => x.BrandsId,
                        principalTable: "Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemBrands_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemDescriptions_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemNotes_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemVariants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NotifyLessThan = table.Column<short>(type: "smallint", nullable: false),
                    LastPurchasePrice = table.Column<decimal>(type: "Money", nullable: false),
                    TotalAmountInAllInvetroies = table.Column<short>(type: "smallint", nullable: false),
                    ProfitMargin = table.Column<short>(type: "smallint", nullable: false),
                    ProfitMarginType = table.Column<byte>(type: "tinyint", nullable: false),
                    Barcode = table.Column<int>(type: "int", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    HasWholeSalePrice = table.Column<bool>(type: "bit", nullable: false),
                    HasRetailPrice = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVariants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVariants_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages_CreditType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreditAmount = table.Column<int>(type: "int", nullable: false),
                    CreditTypesId = table.Column<int>(type: "int", nullable: false),
                    PackagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages_CreditType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_CreditType_CreditTypes_CreditTypesId",
                        column: x => x.CreditTypesId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Packages_CreditType_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Packages_Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PackagesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Packages_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Packages_Descriptions_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayableCheck_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PayableCheckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableCheck_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayableCheck_Attachments_PayableChecks_PayableCheckId",
                        column: x => x.PayableCheckId,
                        principalTable: "PayableChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PayableCheck_Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PayableCheckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayableCheck_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PayableCheck_Descriptions_PayableChecks_PayableCheckId",
                        column: x => x.PayableCheckId,
                        principalTable: "PayableChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivableCheck_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    ReceivableCheckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivableCheck_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivableCheck_Attachments_ReceivableChecks_ReceivableCheckId",
                        column: x => x.ReceivableCheckId,
                        principalTable: "ReceivableChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivableCheck_Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivableCheckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivableCheck_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivableCheck_Descriptions_ReceivableChecks_ReceivableCheckId",
                        column: x => x.ReceivableCheckId,
                        principalTable: "ReceivableChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReceivableCheck_Endorsements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndorsedName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReceivableCheckId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivableCheck_Endorsements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReceivableCheck_Endorsements_ReceivableChecks_ReceivableCheckId",
                        column: x => x.ReceivableCheckId,
                        principalTable: "ReceivableChecks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryComponentsAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    SalaryComponentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryComponentsAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryComponentsAmounts_SallaryComponents_SalaryComponentsId",
                        column: x => x.SalaryComponentsId,
                        principalTable: "SallaryComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryComponentsFormulas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Formula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalaryComponentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryComponentsFormulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryComponentsFormulas_SallaryComponents_SalaryComponentsId",
                        column: x => x.SalaryComponentsId,
                        principalTable: "SallaryComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryDetuction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryComponentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryDetuction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryDetuction_SallaryComponents_SalaryComponentsId",
                        column: x => x.SalaryComponentsId,
                        principalTable: "SallaryComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryEarnings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryComponentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryEarnings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryEarnings_SallaryComponents_SalaryComponentsId",
                        column: x => x.SalaryComponentsId,
                        principalTable: "SallaryComponents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceSubCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    ServiceMainCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceSubCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceSubCategories_ServiceMainCategories_ServiceMainCategoryId",
                        column: x => x.ServiceMainCategoryId,
                        principalTable: "ServiceMainCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields_Per_Service",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FieldsInSystemId = table.Column<int>(type: "int", nullable: false),
                    SystemsInERPId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields_Per_Service", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Per_Service_FieldsInSystem_FieldsInSystemId",
                        column: x => x.FieldsInSystemId,
                        principalTable: "FieldsInSystem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Fields_Per_Service_SystemsInERP_SystemsInERPId",
                        column: x => x.SystemsInERPId,
                        principalTable: "SystemsInERP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumberingSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberingStyle = table.Column<byte>(type: "tinyint", nullable: false),
                    MinimumNubmerOfdigits = table.Column<byte>(type: "tinyint", nullable: false),
                    HasPrefix = table.Column<bool>(type: "bit", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false),
                    StartNumbering = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SystemsInERPId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberingSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumberingSettings_SystemsInERP_SystemsInERPId",
                        column: x => x.SystemsInERPId,
                        principalTable: "SystemsInERP",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemTaxSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    TaxSettingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTaxSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTaxSettings_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTaxSettings_TaxSettings_TaxSettingsId",
                        column: x => x.TaxSettingsId,
                        principalTable: "TaxSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShippingOptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Fees = table.Column<decimal>(type: "Money", nullable: false),
                    TaxSettingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingOptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingOptions_TaxSettings_TaxSettingsId",
                        column: x => x.TaxSettingsId,
                        principalTable: "TaxSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Treasury_Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TreasuriesId = table.Column<int>(type: "int", nullable: true),
                    TreasuryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treasury_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treasury_Descriptions_Treasuries_TreasuriesId",
                        column: x => x.TreasuriesId,
                        principalTable: "Treasuries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item_Units",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    UnitsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Units", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Units_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Units_Units_UnitsId",
                        column: x => x.UnitsId,
                        principalTable: "Units",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonalEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JoinDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ProfileIMage = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HasCustomFields = table.Column<bool>(type: "bit", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: true),
                    DepartmentId = table.Column<int>(type: "int", nullable: true),
                    DesignationId = table.Column<int>(type: "int", nullable: true),
                    EmployeeLevelId = table.Column<int>(type: "int", nullable: true),
                    EmployeeTypeId = table.Column<int>(type: "int", nullable: true),
                    HolidayListsId = table.Column<int>(type: "int", nullable: false),
                    VacationsPolicy_LeavePolicyId = table.Column<int>(type: "int", nullable: false),
                    EmployeeShiftsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_Designations_DesignationId",
                        column: x => x.DesignationId,
                        principalTable: "Designations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeLevels_EmployeeLevelId",
                        column: x => x.EmployeeLevelId,
                        principalTable: "EmployeeLevels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeShifts_EmployeeShiftsId",
                        column: x => x.EmployeeShiftsId,
                        principalTable: "EmployeeShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_EmployeeTypes_EmployeeTypeId",
                        column: x => x.EmployeeTypeId,
                        principalTable: "EmployeeTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Employees_HolidayLists_HolidayListsId",
                        column: x => x.HolidayListsId,
                        principalTable: "HolidayLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_VacationsPolicy_LeavePolicies_VacationsPolicy_LeavePolicyId",
                        column: x => x.VacationsPolicy_LeavePolicyId,
                        principalTable: "VacationsPolicy_LeavePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VacationPolicy_Types",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacationsPolicy_LeavePolicyId = table.Column<int>(type: "int", nullable: false),
                    VacationsType_LeaveTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VacationPolicy_Types", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VacationPolicy_Types_VacationsPolicy_LeavePolicies_VacationsPolicy_LeavePolicyId",
                        column: x => x.VacationsPolicy_LeavePolicyId,
                        principalTable: "VacationsPolicy_LeavePolicies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VacationPolicy_Types_VacationsType_LeaveTypes_VacationsType_LeaveTypeId",
                        column: x => x.VacationsType_LeaveTypeId,
                        principalTable: "VacationsType_LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutomaticReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmailTemplateId = table.Column<int>(type: "int", nullable: false),
                    WhenOptionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutomaticReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutomaticReminders_EmailsTemplates_EmailTemplateId",
                        column: x => x.EmailTemplateId,
                        principalTable: "EmailsTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutomaticReminders_WhenRemidersSents_WhenOptionId",
                        column: x => x.WhenOptionId,
                        principalTable: "WhenRemidersSents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckBook_Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckBookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckBook_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckBook_Notes_CheckBooks_CheckBookId",
                        column: x => x.CheckBookId,
                        principalTable: "CheckBooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateCreated = table.Column<DateTime>(type: "Date", nullable: false),
                    AppointmentDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    IsSharedWithClient = table.Column<bool>(type: "bit", nullable: false),
                    IsRepeated = table.Column<bool>(type: "bit", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    IsAssignedToStaff = table.Column<bool>(type: "bit", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Clients_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Clients_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Business_COCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxRecordId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business_COCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Business_COCs_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Category_PerClient",
                columns: table => new
                {
                    COCId = table.Column<int>(type: "int", nullable: false),
                    COC_categoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category_PerClient", x => new { x.COCId, x.COC_categoryId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_Category_PerClient_COC_category_COC_categoryId",
                        column: x => x.COC_categoryId,
                        principalTable: "COC_category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Category_PerClient_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    COCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientNotes_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(7)", maxLength: 7, nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClientStatuses_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "COCAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COCAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COCAddresses_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ConstactList_PerCOC",
                columns: table => new
                {
                    COCId = table.Column<int>(type: "int", nullable: false),
                    COC_ContactListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConstactList_PerCOC", x => new { x.COCId, x.COC_ContactListId })
                        .Annotation("SqlServer:Clustered", true);
                    table.ForeignKey(
                        name: "FK_ConstactList_PerCOC_COC_ContactList_COC_ContactListId",
                        column: x => x.COC_ContactListId,
                        principalTable: "COC_ContactList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConstactList_PerCOC_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCharges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CreditAmount = table.Column<int>(type: "int", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false),
                    CreditTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCharges", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCharges_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditCharges_CreditTypes_CreditTypesId",
                        column: x => x.CreditTypesId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditUsages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsageDate = table.Column<DateTime>(type: "Date", nullable: false),
                    UsedAmount = table.Column<int>(type: "int", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false),
                    CreditTypesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditUsages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditUsages_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditUsages_CreditTypes_CreditTypesId",
                        column: x => x.CreditTypesId,
                        principalTable: "CreditTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Individual_COCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "Date", nullable: false),
                    Gender = table.Column<byte>(type: "tinyint", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Individual_COCs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Individual_COCs_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceBumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentToClientMethod = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "Date", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "Date", nullable: false),
                    PaymentDue = table.Column<short>(type: "smallint", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    HasSubscription = table.Column<bool>(type: "bit", nullable: false),
                    HasDiscount = table.Column<bool>(type: "bit", nullable: false),
                    HasCustomFields = table.Column<bool>(type: "bit", nullable: false),
                    HasShippingDetails = table.Column<bool>(type: "bit", nullable: false),
                    TotalValue = table.Column<decimal>(type: "Money", nullable: false),
                    ServiceOrItem = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy_UserId = table.Column<int>(type: "int", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_AspNetUsers_CreatedBy_UserId",
                        column: x => x.CreatedBy_UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    GenerateEvery = table.Column<byte>(type: "tinyint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Occurrences = table.Column<int>(type: "int", nullable: false),
                    IssueInvoiceBefore = table.Column<int>(type: "int", nullable: false),
                    PaymentTerms = table.Column<int>(type: "int", nullable: false),
                    DisplayDateFromAndTo = table.Column<bool>(type: "bit", nullable: false),
                    EnableAutomaticPayment = table.Column<bool>(type: "bit", nullable: false),
                    SendViaEmail = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false),
                    HasTerms = table.Column<bool>(type: "bit", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscriptions_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscriptions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Purchase_invoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Attachments_Purchase_invoices_Purchase_invoicesId",
                        column: x => x.Purchase_invoicesId,
                        principalTable: "Purchase_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_Payments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PurchasePaymentMethodsId = table.Column<int>(type: "int", nullable: false),
                    Purchase_invoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_Payments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_Payments_Purchase_invoices_Purchase_invoicesId",
                        column: x => x.Purchase_invoicesId,
                        principalTable: "Purchase_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_Payments_PurchasePaymentMethods_PurchasePaymentMethodsId",
                        column: x => x.PurchasePaymentMethodsId,
                        principalTable: "PurchasePaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases_Deposits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepositsValue = table.Column<int>(type: "int", nullable: false),
                    DepositsType = table.Column<int>(type: "int", nullable: false),
                    Purchase_invoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases_Deposits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_Deposits_Purchase_invoices_Purchase_invoicesId",
                        column: x => x.Purchase_invoicesId,
                        principalTable: "Purchase_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases_discounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiscountValue = table.Column<int>(type: "int", nullable: false),
                    DiscountType = table.Column<int>(type: "int", nullable: false),
                    Purchase_invoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases_discounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_discounts_Purchase_invoices_Purchase_invoicesId",
                        column: x => x.Purchase_invoicesId,
                        principalTable: "Purchase_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases_paymentTerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<int>(type: "int", nullable: false),
                    Purchase_invoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases_paymentTerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_paymentTerms_Purchase_invoices_Purchase_invoicesId",
                        column: x => x.Purchase_invoicesId,
                        principalTable: "Purchase_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases_shippingFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingFees = table.Column<int>(type: "int", nullable: false),
                    Purchase_invoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases_shippingFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_shippingFees_Purchase_invoices_Purchase_invoicesId",
                        column: x => x.Purchase_invoicesId,
                        principalTable: "Purchase_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchaseStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Purchase_invoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchaseStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchaseStatuses_Purchase_invoices_Purchase_invoicesId",
                        column: x => x.Purchase_invoicesId,
                        principalTable: "Purchase_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refunds_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Purchase_RefundRequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refunds_Attachments_Purchase_RefundRequests_Purchase_RefundRequestsId",
                        column: x => x.Purchase_RefundRequestsId,
                        principalTable: "Purchase_RefundRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refunds_items_ShippingFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingFees = table.Column<int>(type: "int", nullable: false),
                    Purchase_RefundRequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds_items_ShippingFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refunds_items_ShippingFees_Purchase_RefundRequests_Purchase_RefundRequestsId",
                        column: x => x.Purchase_RefundRequestsId,
                        principalTable: "Purchase_RefundRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Refunds_Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purchase_RefundRequestsId = table.Column<int>(type: "int", nullable: true),
                    Purchase_RefundRequestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Refunds_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Refunds_Notes_Purchase_RefundRequests_Purchase_RefundRequestsId",
                        column: x => x.Purchase_RefundRequestsId,
                        principalTable: "Purchase_RefundRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefundsStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Purchase_RefundRequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundsStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundsStatuses_Purchase_RefundRequests_Purchase_RefundRequestsId",
                        column: x => x.Purchase_RefundRequestsId,
                        principalTable: "Purchase_RefundRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    WorkOrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Attachments_WorkOrders_WorkOrdersId",
                        column: x => x.WorkOrdersId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrders_Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrders_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrders_Descriptions_WorkOrders_WorkOrdersId",
                        column: x => x.WorkOrdersId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrdersActions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ActionName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WorkOrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrdersActions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrdersActions_WorkOrders_WorkOrdersId",
                        column: x => x.WorkOrdersId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrdersClients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrdersId = table.Column<int>(type: "int", nullable: false),
                    COCid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrdersClients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrdersClients_COCs_COCid",
                        column: x => x.COCid,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrdersClients_WorkOrders_WorkOrdersId",
                        column: x => x.WorkOrdersId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrderStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    WorkOrdersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrderStatuses_WorkOrders_WorkOrdersId",
                        column: x => x.WorkOrdersId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditNote_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CreditNoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNote_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditNote_Attachments_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditNote_Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditNoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNote_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditNote_Notes_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditNtotes_Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    COCId = table.Column<int>(type: "int", nullable: false),
                    CreditNoteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNtotes_Client", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditNtotes_Client_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditNtotes_Client_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Item_Per_Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemSubCategoryId = table.Column<int>(type: "int", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Item_Per_Subcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Item_Per_Subcategories_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Item_Per_Subcategories_ItemSubCategories_ItemSubCategoryId",
                        column: x => x.ItemSubCategoryId,
                        principalTable: "ItemSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CreditNote_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemPrice = table.Column<decimal>(type: "Money", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false),
                    CreditNoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNote_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditNote_Items_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditNote_Items_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsVariant_RetailPrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RetailPrice = table.Column<decimal>(type: "Money", nullable: false),
                    MinRetailPrice = table.Column<decimal>(type: "Money", nullable: false),
                    DiscountAmount = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountType = table.Column<byte>(type: "tinyint", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsVariant_RetailPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsVariant_RetailPrices_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemVariant_WholeSalePrices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WholeSalePrice = table.Column<decimal>(type: "Money", nullable: false),
                    MinWholeSalePrice = table.Column<decimal>(type: "Money", nullable: false),
                    DiscountAmount = table.Column<byte>(type: "tinyint", nullable: false),
                    DiscountType = table.Column<byte>(type: "tinyint", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemVariant_WholeSalePrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemVariant_WholeSalePrices_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceList_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceList_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceList_Items_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PriceList_Items_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferBetweenInvents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    ToInventoryId = table.Column<int>(type: "int", nullable: false),
                    FromInventoryId = table.Column<int>(type: "int", nullable: false),
                    AmountTransfered = table.Column<int>(type: "int", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferBetweenInvents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferBetweenInvents_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts_Deductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractsId = table.Column<int>(type: "int", nullable: false),
                    SalaryDetuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts_Deductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Deductions_Contracts_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_Deductions_SalaryDetuction_SalaryDetuctionId",
                        column: x => x.SalaryDetuctionId,
                        principalTable: "SalaryDetuction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryStructures_Deduction",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryStructuresId = table.Column<int>(type: "int", nullable: false),
                    SalaryDetuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryStructures_Deduction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryStructures_Deduction_SalaryDetuction_SalaryDetuctionId",
                        column: x => x.SalaryDetuctionId,
                        principalTable: "SalaryDetuction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryStructures_Deduction_SalaryStructures_SalaryStructuresId",
                        column: x => x.SalaryStructuresId,
                        principalTable: "SalaryStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contracts_earns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContractsId = table.Column<int>(type: "int", nullable: false),
                    SalaryEarningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts_earns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_earns_Contracts_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contracts_earns_SalaryEarnings_SalaryEarningId",
                        column: x => x.SalaryEarningId,
                        principalTable: "SalaryEarnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalaryStructures_earns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryStructuresId = table.Column<int>(type: "int", nullable: false),
                    SalaryEarningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryStructures_earns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryStructures_earns_SalaryEarnings_SalaryEarningId",
                        column: x => x.SalaryEarningId,
                        principalTable: "SalaryEarnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalaryStructures_earns_SalaryStructures_SalaryStructuresId",
                        column: x => x.SalaryStructuresId,
                        principalTable: "SalaryStructures",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    HasSpecialOffer = table.Column<bool>(type: "bit", nullable: false),
                    HasNote = table.Column<bool>(type: "bit", nullable: false),
                    AddByUser = table.Column<int>(type: "int", nullable: false),
                    ServiceSubCategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_ServiceSubCategories_ServiceSubCategoryId",
                        column: x => x.ServiceSubCategoryId,
                        principalTable: "ServiceSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COC_CustomFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false),
                    Fields_Per_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COC_CustomFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_COC_CustomFields_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_COC_CustomFields_Fields_Per_Service_Fields_Per_ServiceId",
                        column: x => x.Fields_Per_ServiceId,
                        principalTable: "Fields_Per_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields_validation_Foreach_Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsRequired = table.Column<byte>(type: "tinyint", nullable: false),
                    IsUnique = table.Column<byte>(type: "tinyint", nullable: false),
                    FilterByThisField = table.Column<byte>(type: "tinyint", nullable: false),
                    ListByThisField = table.Column<byte>(type: "tinyint", nullable: false),
                    HasMinAndMaxNumber = table.Column<bool>(type: "bit", nullable: false),
                    HasMinAndMaxDate = table.Column<bool>(type: "bit", nullable: false),
                    Fields_Per_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields_validation_Foreach_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_validation_Foreach_Services_Fields_Per_Service_Fields_Per_ServiceId",
                        column: x => x.Fields_Per_ServiceId,
                        principalTable: "Fields_Per_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items_CustomFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    Fields_Per_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_CustomFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_CustomFields_Fields_Per_Service_Fields_Per_ServiceId",
                        column: x => x.Fields_Per_ServiceId,
                        principalTable: "Fields_Per_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_CustomFields_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NumberSettings_Prefixes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prefix = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Mode = table.Column<byte>(type: "tinyint", nullable: false),
                    NextNumberPerPrefix = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    NumberingSettingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NumberSettings_Prefixes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NumberSettings_Prefixes_NumberingSettings_NumberingSettingsId",
                        column: x => x.NumberingSettingsId,
                        principalTable: "NumberingSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendancePermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionType = table.Column<byte>(type: "tinyint", nullable: false),
                    ApplicationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendancePermissions_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceSheets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalWorkingDays = table.Column<short>(type: "smallint", nullable: false),
                    Total_Present_Days = table.Column<short>(type: "smallint", nullable: false),
                    Total_Delays_Days = table.Column<short>(type: "smallint", nullable: false),
                    Total_MinDelays = table.Column<short>(type: "smallint", nullable: false),
                    Expected_WorkingHours = table.Column<short>(type: "smallint", nullable: false),
                    Total_Absence_Days = table.Column<short>(type: "smallint", nullable: false),
                    Total_SignIn_Only = table.Column<short>(type: "smallint", nullable: false),
                    Total_SignOut_Only = table.Column<short>(type: "smallint", nullable: false),
                    Total_EarlyLeave_Days = table.Column<short>(type: "smallint", nullable: false),
                    Total_EarlyLeave_Min = table.Column<short>(type: "smallint", nullable: false),
                    Actual_WorkingHours = table.Column<short>(type: "smallint", nullable: false),
                    Total_Vacations = table.Column<short>(type: "smallint", nullable: false),
                    IsApproved = table.Column<bool>(type: "bit", nullable: false),
                    FiscalYearStartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceSheets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceSheets_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingSettings_AssignedEmployee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    Booking_settingsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingSettings_AssignedEmployee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BookingSettings_AssignedEmployee_Booking_settings_Booking_settingsId",
                        column: x => x.Booking_settingsId,
                        principalTable: "Booking_settings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingSettings_AssignedEmployee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    TargetType = table.Column<bool>(type: "bit", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    ForCatOrItemOrService = table.Column<byte>(type: "tinyint", nullable: false),
                    CommissionPeriod = table.Column<byte>(type: "tinyint", nullable: false),
                    CalculationType = table.Column<byte>(type: "tinyint", nullable: false),
                    Percent = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "Date", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    AddedBy_EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_Employees_AddedBy_EmpId",
                        column: x => x.AddedBy_EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contract_Per_Emps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JoinDate = table.Column<DateTime>(type: "Date", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ContractSignDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndOfTestPeriodDate = table.Column<DateTime>(type: "Date", nullable: false),
                    DurationOrEndDate = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false),
                    ContractsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contract_Per_Emps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contract_Per_Emps_Contracts_ContractsId",
                        column: x => x.ContractsId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Contract_Per_Emps_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PermanentOrPresent = table.Column<bool>(type: "bit", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeAddress_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeNotes_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees_customFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    Fields_Per_ServiceId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_customFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_customFields_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_customFields_Fields_Per_Service_Fields_Per_ServiceId",
                        column: x => x.Fields_Per_ServiceId,
                        principalTable: "Fields_Per_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employees_In_Branch",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_In_Branch", x => new { x.EmployeeId, x.BranchId });
                    table.ForeignKey(
                        name: "FK_Employees_In_Branch_BusinessBranches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "BusinessBranches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_In_Branch_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estimates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    IsForClient = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    HashShippingFees = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HashNotes = table.Column<bool>(type: "bit", nullable: false),
                    IsForCategory = table.Column<bool>(type: "bit", nullable: false),
                    IsForSubCatategory = table.Column<bool>(type: "bit", nullable: false),
                    DaysToExpire = table.Column<byte>(type: "tinyint", nullable: false),
                    EstimateFor = table.Column<byte>(type: "tinyint", nullable: false),
                    AddBy_empId = table.Column<int>(type: "int", nullable: true),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    EmailsTemplatesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimates_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estimates_EmailsTemplates_EmailsTemplatesId",
                        column: x => x.EmailsTemplatesId,
                        principalTable: "EmailsTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estimates_Employees_AddBy_empId",
                        column: x => x.AddBy_empId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InsuranceAgents",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachments = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy_EmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsuranceAgents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsuranceAgents_Employees_AddedBy_EmployeesId",
                        column: x => x.AddedBy_EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsMainInventory = table.Column<bool>(type: "bit", nullable: false),
                    AddedBy_EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventories_Employees_AddedBy_EmpId",
                        column: x => x.AddedBy_EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Loans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ApplicationDate = table.Column<DateTime>(type: "Date", nullable: false),
                    InstallmentStartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    InstallmentAmount = table.Column<decimal>(type: "Money", nullable: false),
                    IsPaidFromPaySlip = table.Column<bool>(type: "bit", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    InstallmentCount = table.Column<byte>(type: "tinyint", nullable: false),
                    PeriodOfInstallment = table.Column<byte>(type: "tinyint", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    TreasuriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Loans_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Loans_Treasuries_TreasuriesId",
                        column: x => x.TreasuriesId,
                        principalTable: "Treasuries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManualAttendanceEachDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceDate = table.Column<DateTime>(type: "Date", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualAttendanceEachDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualAttendanceEachDays_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PaperImages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaperImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PaperImages_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payslips",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostingDate = table.Column<DateTime>(type: "Date", nullable: false),
                    StartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    GrossPay = table.Column<decimal>(type: "Money", nullable: false),
                    TotalDeduction = table.Column<decimal>(type: "Money", nullable: false),
                    NetPay = table.Column<decimal>(type: "Money", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payslips_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payslips_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoicePayments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    HasDetails = table.Column<bool>(type: "bit", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    HasAttachment = table.Column<bool>(type: "bit", nullable: false),
                    CollectedBy_EmpId = table.Column<int>(type: "int", nullable: false),
                    PaymentStatusId = table.Column<int>(type: "int", nullable: false),
                    PaymentMethodsId = table.Column<int>(type: "int", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoicePayments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePayments_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePayments_Employees_CollectedBy_EmpId",
                        column: x => x.CollectedBy_EmpId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePayments_PaymentMethods_PaymentMethodsId",
                        column: x => x.PaymentMethodsId,
                        principalTable: "PaymentMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePayments_SalesInvoice_PaymentStatus_PaymentStatusId",
                        column: x => x.PaymentStatusId,
                        principalTable: "SalesInvoice_PaymentStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaxID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CR = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "Date", nullable: false),
                    OpeningBalance = table.Column<decimal>(type: "Money", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Suppliers_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkOrdersEmployees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WorkOrdersId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrdersEmployees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkOrdersEmployees_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkOrdersEmployees_WorkOrders_WorkOrdersId",
                        column: x => x.WorkOrdersId,
                        principalTable: "WorkOrders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments_Actions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Actions = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    AppointmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments_Actions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Actions_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Appointments_Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AppointmentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Appointments_Notes_Appointments_AppointmentsId",
                        column: x => x.AppointmentsId,
                        principalTable: "Appointments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditCharge_descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditChargeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditCharge_descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditCharge_descriptions_CreditCharges_CreditChargeId",
                        column: x => x.CreditChargeId,
                        principalTable: "CreditCharges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditUsage_descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditUsageId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditUsage_descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditUsage_descriptions_CreditUsages_CreditUsageId",
                        column: x => x.CreditUsageId,
                        principalTable: "CreditUsages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JoinDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ToleranceDays = table.Column<int>(type: "int", nullable: false),
                    HasDescription = table.Column<bool>(type: "bit", nullable: false),
                    COCId = table.Column<int>(type: "int", nullable: false),
                    PackagesId = table.Column<int>(type: "int", nullable: false),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Memberships_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Packages_PackagesId",
                        column: x => x.PackagesId,
                        principalTable: "Packages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoice_AutomaticReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: false),
                    AutomaticRemindersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoice_AutomaticReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_AutomaticReminders_AutomaticReminders_AutomaticRemindersId",
                        column: x => x.AutomaticRemindersId,
                        principalTable: "AutomaticReminders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_AutomaticReminders_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoice_TotalDsicounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalDiscount = table.Column<decimal>(type: "Money", nullable: false),
                    DiscountType = table.Column<bool>(type: "bit", nullable: false),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoice_TotalDsicounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoice_TotalDsicounts_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoices_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoices_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoices_Attachments_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: false),
                    Fields_Per_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesSettings_Fields_Per_Service_Fields_Per_ServiceId",
                        column: x => x.Fields_Per_ServiceId,
                        principalTable: "Fields_Per_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SalesSettings_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShippingDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingFees = table.Column<decimal>(type: "Money", nullable: false),
                    ShowingInInvoiceOptions = table.Column<byte>(type: "tinyint", nullable: false),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingDetails_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuses_For_EachInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: false),
                    SalesInvoicesStatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses_For_EachInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_For_EachInvoice_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statuses_For_EachInvoice_SalesInvoicesStatuses_SalesInvoicesStatusId",
                        column: x => x.SalesInvoicesStatusId,
                        principalTable: "SalesInvoicesStatuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terms_Per_Invoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxValue = table.Column<int>(type: "int", nullable: false),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: false),
                    SalesTermsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terms_Per_Invoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Terms_Per_Invoice_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terms_Per_Invoice_TermsAndConditions_SalesTermsId",
                        column: x => x.SalesTermsId,
                        principalTable: "TermsAndConditions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription_AutomaticReminders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false),
                    AutomaticRemindersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription_AutomaticReminders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_AutomaticReminders_AutomaticReminders_AutomaticRemindersId",
                        column: x => x.AutomaticRemindersId,
                        principalTable: "AutomaticReminders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscription_AutomaticReminders_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription_Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FromDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ToDate = table.Column<DateTime>(type: "Date", nullable: false),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Invoices_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Subscription_Invoices_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Subscription_Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Notes_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription_Terms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Terms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription_Terms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Terms_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SubscriptionAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SubscriptionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionAttachments_Subscriptions_SubscriptionsId",
                        column: x => x.SubscriptionsId,
                        principalTable: "Subscriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TransferBetweenInvent_notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TransferBetweenInventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TransferBetweenInvent_notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TransferBetweenInvent_notes_TransferBetweenInvents_TransferBetweenInventId",
                        column: x => x.TransferBetweenInventId,
                        principalTable: "TransferBetweenInvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Booking_Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    BookingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Booking_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Booking_Services_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Booking_Services_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CreditNote_Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServicePrice = table.Column<decimal>(type: "Money", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    CreditNoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreditNote_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CreditNote_Services_CreditNotes_CreditNoteId",
                        column: x => x.CreditNoteId,
                        principalTable: "CreditNotes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CreditNote_Services_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "priceList_Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    PriceListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_priceList_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_priceList_Services_PriceLists_PriceListId",
                        column: x => x.PriceListId,
                        principalTable: "PriceLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_priceList_Services_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchase_RefundedServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefundedQuantity = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    Purchase_RefundRequestsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchase_RefundedServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchase_RefundedServices_Purchase_RefundRequests_Purchase_RefundRequestsId",
                        column: x => x.Purchase_RefundRequestsId,
                        principalTable: "Purchase_RefundRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchase_RefundedServices_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PurchasesInvoice_Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedQuantity = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    Purchase_invoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PurchasesInvoice_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PurchasesInvoice_Services_Purchase_invoices_Purchase_invoicesId",
                        column: x => x.Purchase_invoicesId,
                        principalTable: "Purchase_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PurchasesInvoice_Services_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Service_CustomFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Fields_Per_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service_CustomFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Service_CustomFields_Fields_Per_Service_Fields_Per_ServiceId",
                        column: x => x.Fields_Per_ServiceId,
                        principalTable: "Fields_Per_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Service_CustomFields_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceDescriptions_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceNotes_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServicesInSalesInvices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SubtotalPerItem = table.Column<decimal>(type: "Money", nullable: false),
                    Decriptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicesInSalesInvices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServicesInSalesInvices_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServicesInSalesInvices_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTaxSettings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    TaxSettingsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTaxSettings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServiceTaxSettings_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTaxSettings_TaxSettings_TaxSettingsId",
                        column: x => x.TaxSettingsId,
                        principalTable: "TaxSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Fields_layouts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Size = table.Column<byte>(type: "tinyint", nullable: false),
                    ShowInNewLine = table.Column<bool>(type: "bit", nullable: false),
                    HideField = table.Column<bool>(type: "bit", nullable: false),
                    Fields_validation_Foreach_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields_layouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_layouts_Fields_validation_Foreach_Services_Fields_validation_Foreach_ServiceId",
                        column: x => x.Fields_validation_Foreach_ServiceId,
                        principalTable: "Fields_validation_Foreach_Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fields_Properties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Label = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Hint = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InitialValue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Placeholder = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    EnableAutocomplete = table.Column<bool>(type: "bit", nullable: false),
                    HasChoices = table.Column<bool>(type: "bit", nullable: false),
                    EnableQuickSearch = table.Column<bool>(type: "bit", nullable: false),
                    Fields_validation_Foreach_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fields_Properties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fields_Properties_Fields_validation_Foreach_Services_Fields_validation_Foreach_ServiceId",
                        column: x => x.Fields_validation_Foreach_ServiceId,
                        principalTable: "Fields_validation_Foreach_Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinAndMaxDate",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinDate = table.Column<DateTime>(type: "Date", nullable: false),
                    MaxDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Fields_validation_Foreach_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinAndMaxDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinAndMaxDate_Fields_validation_Foreach_Services_Fields_validation_Foreach_ServiceId",
                        column: x => x.Fields_validation_Foreach_ServiceId,
                        principalTable: "Fields_validation_Foreach_Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MinAndMaxNumbers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinNumber = table.Column<short>(type: "smallint", nullable: false),
                    MaxNumber = table.Column<short>(type: "smallint", nullable: false),
                    Digit_Value_NotApplicable = table.Column<byte>(type: "tinyint", nullable: false),
                    Fields_validation_Foreach_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MinAndMaxNumbers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MinAndMaxNumbers_Fields_validation_Foreach_Services_Fields_validation_Foreach_ServiceId",
                        column: x => x.Fields_validation_Foreach_ServiceId,
                        principalTable: "Fields_validation_Foreach_Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendancePermission_DelayPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LateTime = table.Column<byte>(type: "tinyint", nullable: false),
                    AttendancePermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePermission_DelayPermissions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendancePermission_DelayPermissions_AttendancePermissions_AttendancePermissionId",
                        column: x => x.AttendancePermissionId,
                        principalTable: "AttendancePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendancePermission_notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttendancePermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePermission_notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendancePermission_notes_AttendancePermissions_AttendancePermissionId",
                        column: x => x.AttendancePermissionId,
                        principalTable: "AttendancePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendancePermission_VacationPerms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacationsType_LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    AttendancePermissionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendancePermission_VacationPerms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendancePermission_VacationPerms_AttendancePermissions_AttendancePermissionId",
                        column: x => x.AttendancePermissionId,
                        principalTable: "AttendancePermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendancePermission_VacationPerms_VacationsType_LeaveTypes_VacationsType_LeaveTypeId",
                        column: x => x.VacationsType_LeaveTypeId,
                        principalTable: "VacationsType_LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commissions_ItemCats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommissionsId = table.Column<int>(type: "int", nullable: false),
                    ItemSubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions_ItemCats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_ItemCats_Commissions_CommissionsId",
                        column: x => x.CommissionsId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_ItemCats_ItemSubCategories_ItemSubCategoryId",
                        column: x => x.ItemSubCategoryId,
                        principalTable: "ItemSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commissions_items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommissionsId = table.Column<int>(type: "int", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions_items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_items_Commissions_CommissionsId",
                        column: x => x.CommissionsId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_items_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commissions_Per_employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommissionsId = table.Column<int>(type: "int", nullable: false),
                    EmployeesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions_Per_employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_Per_employee_Commissions_CommissionsId",
                        column: x => x.CommissionsId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_Per_employee_Employees_EmployeesId",
                        column: x => x.EmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Commissions_SerCat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommissionsId = table.Column<int>(type: "int", nullable: false),
                    ServiceSubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions_SerCat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_SerCat_Commissions_CommissionsId",
                        column: x => x.CommissionsId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_SerCat_ServiceSubCategories_ServiceSubCategoryId",
                        column: x => x.ServiceSubCategoryId,
                        principalTable: "ServiceSubCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commissions_Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommissionsId = table.Column<int>(type: "int", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commissions_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commissions_Services_Commissions_CommissionsId",
                        column: x => x.CommissionsId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commissions_Services_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommissionsNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommissionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommissionsNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommissionsNotes_Commissions_CommissionsId",
                        column: x => x.CommissionsId,
                        principalTable: "Commissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractDurations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "Money", nullable: false),
                    MonthOrYear = table.Column<bool>(type: "bit", nullable: false),
                    Contract_Per_EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractDurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractDurations_Contract_Per_Emps_Contract_Per_EmpId",
                        column: x => x.Contract_Per_EmpId,
                        principalTable: "Contract_Per_Emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractEndDates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EndDate = table.Column<DateTime>(type: "Date", nullable: false),
                    Contract_Per_EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractEndDates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractEndDates_Contract_Per_Emps_Contract_Per_EmpId",
                        column: x => x.Contract_Per_EmpId,
                        principalTable: "Contract_Per_Emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContractsAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Contract_Per_EmpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContractsAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContractsAttachments_Contract_Per_Emps_Contract_Per_EmpId",
                        column: x => x.Contract_Per_EmpId,
                        principalTable: "Contract_Per_Emps",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Department_Descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department_Descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Department_Descriptions_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estimates_Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValidFromDate = table.Column<DateTime>(type: "Date", nullable: false),
                    ValidToDate = table.Column<DateTime>(type: "Date", nullable: false),
                    EstimateId = table.Column<int>(type: "int", nullable: true),
                    COCId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimates_Clients_COCs_COCId",
                        column: x => x.COCId,
                        principalTable: "COCs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estimates_Clients_Estimates_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estimates_Items",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewPrice = table.Column<decimal>(type: "Money", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: true),
                    EstimateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimates_Items_Estimates_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estimates_Items_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Estimates_Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NewPrice = table.Column<decimal>(type: "Money", nullable: false),
                    ServicesId = table.Column<int>(type: "int", nullable: true),
                    EstimateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estimates_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Estimates_Services_Estimates_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Estimates_Services_Services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EstimatesAttachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachment = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    EstimateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimatesAttachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimatesAttachments_Estimates_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimatesNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EstimateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimatesNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimatesNotes_Estimates_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimatesShippingFees",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShippingFees = table.Column<int>(type: "int", nullable: false),
                    EstimateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimatesShippingFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimatesShippingFees_Estimates_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EstimatesStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    EstimateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstimatesStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EstimatesStatuses_Estimates_EstimateId",
                        column: x => x.EstimateId,
                        principalTable: "Estimates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EstimatesStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Insurance_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    InsuranceAgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurance_Attachments_InsuranceAgents_InsuranceAgentId",
                        column: x => x.InsuranceAgentId,
                        principalTable: "InsuranceAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insurance_descriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InsuranceAgentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurance_descriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insurance_descriptions_InsuranceAgents_InsuranceAgentId",
                        column: x => x.InsuranceAgentId,
                        principalTable: "InsuranceAgents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Inbound_Invent_Requisitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inbound_Invent_Requisitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inbound_Invent_Requisitions_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Inbound_Invent_Requisitions_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InventoryAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryAddresses_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items_In_PurchaseInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AddedQuantity = table.Column<int>(type: "int", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false),
                    Purchase_invoicesId = table.Column<int>(type: "int", nullable: false),
                    InventoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_In_PurchaseInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_In_PurchaseInvoices_Inventories_InventoriesId",
                        column: x => x.InventoriesId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_In_PurchaseInvoices_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_In_PurchaseInvoices_Purchase_invoices_Purchase_invoicesId",
                        column: x => x.Purchase_invoicesId,
                        principalTable: "Purchase_invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items_in_Refunds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RefundedQuantity = table.Column<int>(type: "int", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false),
                    Purchase_RefundRequestsId = table.Column<int>(type: "int", nullable: false),
                    InventoriesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_in_Refunds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_in_Refunds_Inventories_InventoriesId",
                        column: x => x.InventoriesId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_in_Refunds_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_in_Refunds_Purchase_RefundRequests_Purchase_RefundRequestsId",
                        column: x => x.Purchase_RefundRequestsId,
                        principalTable: "Purchase_RefundRequests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items_NoEpires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_NoEpires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_NoEpires_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_NoEpires_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items_withEpires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    ExpireMonth = table.Column<byte>(type: "tinyint", maxLength: 2, nullable: false),
                    ExoireDate = table.Column<short>(type: "smallint", maxLength: 4, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items_withEpires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_withEpires_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_withEpires_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItemsInSalesInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Price = table.Column<decimal>(type: "Money", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SubtotalPerItem = table.Column<decimal>(type: "Money", nullable: false),
                    Decriptions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false),
                    SalesInvoicesId = table.Column<int>(type: "int", nullable: true),
                    InventoriesId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemsInSalesInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemsInSalesInvoices_Inventories_InventoriesId",
                        column: x => x.InventoriesId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItemsInSalesInvoices_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemsInSalesInvoices_SalesInvoices_SalesInvoicesId",
                        column: x => x.SalesInvoicesId,
                        principalTable: "SalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Outbound_Invent_Requisitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CurrentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    HasNotes = table.Column<bool>(type: "bit", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    ItemVariantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outbound_Invent_Requisitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outbound_Invent_Requisitions_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Outbound_Invent_Requisitions_ItemVariants_ItemVariantsId",
                        column: x => x.ItemVariantsId,
                        principalTable: "ItemVariants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LoanNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoansId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanNotes_Loans_LoansId",
                        column: x => x.LoansId,
                        principalTable: "Loans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceDaysPerEmps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceSheetId = table.Column<int>(type: "int", nullable: false),
                    ManualAttendenceEachDayId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceDaysPerEmps", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceDaysPerEmps_AttendanceSheets_AttendanceSheetId",
                        column: x => x.AttendanceSheetId,
                        principalTable: "AttendanceSheets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AttendanceDaysPerEmps_ManualAttendanceEachDays_ManualAttendenceEachDayId",
                        column: x => x.ManualAttendenceEachDayId,
                        principalTable: "ManualAttendanceEachDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManualAttandanceEachDay_PresentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OnDutyTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OffDutyTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SignInTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SignOutTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    LeaveCount = table.Column<byte>(type: "tinyint", nullable: false),
                    VacationsType_LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    ManualAttendenceEachDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualAttandanceEachDay_PresentStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualAttandanceEachDay_PresentStatuses_ManualAttendanceEachDays_ManualAttendenceEachDayId",
                        column: x => x.ManualAttendenceEachDayId,
                        principalTable: "ManualAttendanceEachDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManualAttandanceEachDay_PresentStatuses_VacationsType_LeaveTypes_VacationsType_LeaveTypeId",
                        column: x => x.VacationsType_LeaveTypeId,
                        principalTable: "VacationsType_LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManualAttendanceEachDay_notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManualAttendenceEachDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualAttendanceEachDay_notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualAttendanceEachDay_notes_ManualAttendanceEachDays_ManualAttendenceEachDayId",
                        column: x => x.ManualAttendenceEachDayId,
                        principalTable: "ManualAttendanceEachDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ManualAttendanceEachDay_VacationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VacationCount = table.Column<short>(type: "smallint", nullable: false),
                    VacationsType_LeaveTypeId = table.Column<int>(type: "int", nullable: false),
                    ManualAttendenceEachDayId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualAttendanceEachDay_VacationStatus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualAttendanceEachDay_VacationStatus_ManualAttendanceEachDays_ManualAttendenceEachDayId",
                        column: x => x.ManualAttendenceEachDayId,
                        principalTable: "ManualAttendanceEachDays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ManualAttendanceEachDay_VacationStatus_VacationsType_LeaveTypes_VacationsType_LeaveTypeId",
                        column: x => x.VacationsType_LeaveTypeId,
                        principalTable: "VacationsType_LeaveTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payslips_Deductions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayslipsId = table.Column<int>(type: "int", nullable: false),
                    SalaryDetuctionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips_Deductions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payslips_Deductions_Payslips_PayslipsId",
                        column: x => x.PayslipsId,
                        principalTable: "Payslips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payslips_Deductions_SalaryDetuction_SalaryDetuctionId",
                        column: x => x.SalaryDetuctionId,
                        principalTable: "SalaryDetuction",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Payslips_Earns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PayslipsId = table.Column<int>(type: "int", nullable: false),
                    SalaryEarningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payslips_Earns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payslips_Earns_Payslips_PayslipsId",
                        column: x => x.PayslipsId,
                        principalTable: "Payslips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Payslips_Earns_SalaryEarnings_SalaryEarningId",
                        column: x => x.SalaryEarningId,
                        principalTable: "SalaryEarnings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoicePayments_Attachments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Attachments = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    SalesInvoicePaymentsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoicePayments_Attachments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePayments_Attachments_SalesInvoicePayments_SalesInvoicePaymentsID",
                        column: x => x.SalesInvoicePaymentsID,
                        principalTable: "SalesInvoicePayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoicePayments_Details",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesInvoicePaymentsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoicePayments_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePayments_Details_SalesInvoicePayments_SalesInvoicePaymentsID",
                        column: x => x.SalesInvoicePaymentsID,
                        principalTable: "SalesInvoicePayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SalesInvoicePayments_Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SalesInvoicePaymentsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalesInvoicePayments_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalesInvoicePayments_Notes_SalesInvoicePayments_SalesInvoicePaymentsID",
                        column: x => x.SalesInvoicePaymentsID,
                        principalTable: "SalesInvoicePayments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier_ContactLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MobilePhone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier_ContactLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_ContactLists_Suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier_CustomFields",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuppliersId = table.Column<int>(type: "int", nullable: false),
                    Fields_Per_ServiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier_CustomFields", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_CustomFields_Fields_Per_Service_Fields_Per_ServiceId",
                        column: x => x.Fields_Per_ServiceId,
                        principalTable: "Fields_Per_Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Supplier_CustomFields_Suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Supplier_notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SuppliersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier_notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Supplier_notes_Suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupplierAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FlatNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddressLine_1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AddressLine_2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SuppliersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierAddresses_Suppliers_SuppliersId",
                        column: x => x.SuppliersId,
                        principalTable: "Suppliers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembershipDescriptions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MembershipsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipDescriptions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipDescriptions_Memberships_MembershipsId",
                        column: x => x.MembershipsId,
                        principalTable: "Memberships",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountsPerService",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountType = table.Column<bool>(type: "bit", nullable: false),
                    ServicesInSalesInvicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountsPerService", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountsPerService_ServicesInSalesInvices_ServicesInSalesInvicesId",
                        column: x => x.ServicesInSalesInvicesId,
                        principalTable: "ServicesInSalesInvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefundedServices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServicesInSalesInvicesId = table.Column<int>(type: "int", nullable: true),
                    CreditNote_ServicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundedServices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundedServices_CreditNote_Services_CreditNote_ServicesId",
                        column: x => x.CreditNote_ServicesId,
                        principalTable: "CreditNote_Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefundedServices_ServicesInSalesInvices_ServicesInSalesInvicesId",
                        column: x => x.ServicesInSalesInvicesId,
                        principalTable: "ServicesInSalesInvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxPerService_PerInvoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxSettingsId = table.Column<int>(type: "int", nullable: false),
                    ServicesInSalesInvicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPerService_PerInvoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxPerService_PerInvoices_ServicesInSalesInvices_ServicesInSalesInvicesId",
                        column: x => x.ServicesInSalesInvicesId,
                        principalTable: "ServicesInSalesInvices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxPerService_PerInvoices_TaxSettings_TaxSettingsId",
                        column: x => x.TaxSettingsId,
                        principalTable: "TaxSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Field_Choices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChoiceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Choicevalue = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Fields_PropertiesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Field_Choices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Field_Choices_Fields_Properties_Fields_PropertiesId",
                        column: x => x.Fields_PropertiesId,
                        principalTable: "Fields_Properties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InboundNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Inbound_Invent_RequisitionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InboundNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InboundNotes_Inbound_Invent_Requisitions_Inbound_Invent_RequisitionsId",
                        column: x => x.Inbound_Invent_RequisitionsId,
                        principalTable: "Inbound_Invent_Requisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addition_NoExpires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Items_NoEpireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addition_NoExpires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addition_NoExpires_Items_NoEpires_Items_NoEpireId",
                        column: x => x.Items_NoEpireId,
                        principalTable: "Items_NoEpires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Withdraw_NoExpires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Items_NoEpireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdraw_NoExpires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Withdraw_NoExpires_Items_NoEpires_Items_NoEpireId",
                        column: x => x.Items_NoEpireId,
                        principalTable: "Items_NoEpires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addition_WithExpire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Items_withEpireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addition_WithExpire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addition_WithExpire_Items_withEpires_Items_withEpireId",
                        column: x => x.Items_withEpireId,
                        principalTable: "Items_withEpires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Withdraw_WithExpires",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "Date", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    Items_withEpireId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Withdraw_WithExpires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Withdraw_WithExpires_Items_withEpires_Items_withEpireId",
                        column: x => x.Items_withEpireId,
                        principalTable: "Items_withEpires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DiscountsPerItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discount = table.Column<int>(type: "int", nullable: false),
                    DiscountType = table.Column<bool>(type: "bit", nullable: false),
                    ItemsInSalesInvoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiscountsPerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DiscountsPerItems_ItemsInSalesInvoices_ItemsInSalesInvoicesId",
                        column: x => x.ItemsInSalesInvoicesId,
                        principalTable: "ItemsInSalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefundedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemsInSalesInvoicesId = table.Column<int>(type: "int", nullable: true),
                    CreditNote_ItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefundedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefundedItems_CreditNote_Items_CreditNote_ItemsId",
                        column: x => x.CreditNote_ItemsId,
                        principalTable: "CreditNote_Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RefundedItems_ItemsInSalesInvoices_ItemsInSalesInvoicesId",
                        column: x => x.ItemsInSalesInvoicesId,
                        principalTable: "ItemsInSalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaxPer_Item_PerInvoice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxValue = table.Column<int>(type: "int", nullable: false),
                    TaxSettingsId = table.Column<int>(type: "int", nullable: false),
                    ItemsInSalesInvoicesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPer_Item_PerInvoice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxPer_Item_PerInvoice_ItemsInSalesInvoices_ItemsInSalesInvoicesId",
                        column: x => x.ItemsInSalesInvoicesId,
                        principalTable: "ItemsInSalesInvoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaxPer_Item_PerInvoice_TaxSettings_TaxSettingsId",
                        column: x => x.TaxSettingsId,
                        principalTable: "TaxSettings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OutboundNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Outbound_Invent_RequisitionsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OutboundNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OutboundNotes_Outbound_Invent_Requisitions_Outbound_Invent_RequisitionsId",
                        column: x => x.Outbound_Invent_RequisitionsId,
                        principalTable: "Outbound_Invent_Requisitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addition_NoExpires_Items_NoEpireId",
                table: "Addition_NoExpires",
                column: "Items_NoEpireId");

            migrationBuilder.CreateIndex(
                name: "IX_Addition_WithExpire_Items_withEpireId",
                table: "Addition_WithExpire",
                column: "Items_withEpireId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_COCId",
                table: "Appointments",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Actions_AppointmentsId",
                table: "Appointments_Actions",
                column: "AppointmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_Notes_AppointmentsId",
                table: "Appointments_Notes",
                column: "AppointmentsId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Email",
                table: "AspNetUsers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_Id",
                table: "AspNetUsers",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_PhoneNumber",
                table: "AspNetUsers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDaysPerEmps_AttendanceSheetId",
                table: "AttendanceDaysPerEmps",
                column: "AttendanceSheetId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceDaysPerEmps_ManualAttendenceEachDayId",
                table: "AttendanceDaysPerEmps",
                column: "ManualAttendenceEachDayId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePermission_DelayPermissions_AttendancePermissionId",
                table: "AttendancePermission_DelayPermissions",
                column: "AttendancePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePermission_notes_AttendancePermissionId",
                table: "AttendancePermission_notes",
                column: "AttendancePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePermission_VacationPerms_AttendancePermissionId",
                table: "AttendancePermission_VacationPerms",
                column: "AttendancePermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePermission_VacationPerms_VacationsType_LeaveTypeId",
                table: "AttendancePermission_VacationPerms",
                column: "VacationsType_LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendancePermissions_EmployeesId",
                table: "AttendancePermissions",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSheets_EmployeesId",
                table: "AttendanceSheets",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_AutomaticReminders_EmailTemplateId",
                table: "AutomaticReminders",
                column: "EmailTemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_AutomaticReminders_WhenOptionId",
                table: "AutomaticReminders",
                column: "WhenOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_BankAccount_Descriptions_BankAccountsId",
                table: "BankAccount_Descriptions",
                column: "BankAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Clients_BookingId",
                table: "Booking_Clients",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Clients_COCId",
                table: "Booking_Clients",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Services_BookingId",
                table: "Booking_Services",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_Booking_Services_ServicesId",
                table: "Booking_Services",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSettings_AssignedEmployee_Booking_settingsId",
                table: "BookingSettings_AssignedEmployee",
                column: "Booking_settingsId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingSettings_AssignedEmployee_EmployeesId",
                table: "BookingSettings_AssignedEmployee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesAddresses_BranchId",
                table: "BranchesAddresses",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_BranchesSettings_BranchId",
                table: "BranchesSettings",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_COCs_COCId",
                table: "Business_COCs",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_PerClient_COC_categoryId",
                table: "Category_PerClient",
                column: "COC_categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBook_Notes_CheckBookId",
                table: "CheckBook_Notes",
                column: "CheckBookId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBooks_BankAccountsId",
                table: "CheckBooks",
                column: "BankAccountsId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckBooks_CurrencyId",
                table: "CheckBooks",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientNotes_COCId",
                table: "ClientNotes",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientStatuses_COCId",
                table: "ClientStatuses",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_COC_CustomFields_COCId",
                table: "COC_CustomFields",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_COC_CustomFields_Fields_Per_ServiceId",
                table: "COC_CustomFields",
                column: "Fields_Per_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_COCAddresses_COCId",
                table: "COCAddresses",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_COCs_CountryId",
                table: "COCs",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_COCs_CurrencyId",
                table: "COCs",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_COCs_UserId",
                table: "COCs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_AddedBy_EmpId",
                table: "Commissions",
                column: "AddedBy_EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_CurrencyId",
                table: "Commissions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_ItemCats_CommissionsId",
                table: "Commissions_ItemCats",
                column: "CommissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_ItemCats_ItemSubCategoryId",
                table: "Commissions_ItemCats",
                column: "ItemSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_items_CommissionsId",
                table: "Commissions_items",
                column: "CommissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_items_ItemVariantsId",
                table: "Commissions_items",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_Per_employee_CommissionsId",
                table: "Commissions_Per_employee",
                column: "CommissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_Per_employee_EmployeesId",
                table: "Commissions_Per_employee",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_SerCat_CommissionsId",
                table: "Commissions_SerCat",
                column: "CommissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_SerCat_ServiceSubCategoryId",
                table: "Commissions_SerCat",
                column: "ServiceSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_Services_CommissionsId",
                table: "Commissions_Services",
                column: "CommissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Commissions_Services_ServicesId",
                table: "Commissions_Services",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_CommissionsNotes_CommissionsId",
                table: "CommissionsNotes",
                column: "CommissionsId");

            migrationBuilder.CreateIndex(
                name: "IX_ConstactList_PerCOC_COC_ContactListId",
                table: "ConstactList_PerCOC",
                column: "COC_ContactListId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_Per_Emps_ContractsId",
                table: "Contract_Per_Emps",
                column: "ContractsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contract_Per_Emps_EmployeesId",
                table: "Contract_Per_Emps",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractDurations_Contract_Per_EmpId",
                table: "ContractDurations",
                column: "Contract_Per_EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractEndDates_Contract_Per_EmpId",
                table: "ContractEndDates",
                column: "Contract_Per_EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CurrencyId",
                table: "Contracts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Deductions_ContractsId",
                table: "Contracts_Deductions",
                column: "ContractsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_Deductions_SalaryDetuctionId",
                table: "Contracts_Deductions",
                column: "SalaryDetuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_earns_ContractsId",
                table: "Contracts_earns",
                column: "ContractsId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_earns_SalaryEarningId",
                table: "Contracts_earns",
                column: "SalaryEarningId");

            migrationBuilder.CreateIndex(
                name: "IX_ContractsAttachments_Contract_Per_EmpId",
                table: "ContractsAttachments",
                column: "Contract_Per_EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCharge_descriptions_CreditChargeId",
                table: "CreditCharge_descriptions",
                column: "CreditChargeId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCharges_COCId",
                table: "CreditCharges",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditCharges_CreditTypesId",
                table: "CreditCharges",
                column: "CreditTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_Attachments_CreditNoteId",
                table: "CreditNote_Attachments",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_Items_CreditNoteId",
                table: "CreditNote_Items",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_Items_ItemVariantsId",
                table: "CreditNote_Items",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_Notes_CreditNoteId",
                table: "CreditNote_Notes",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_Services_CreditNoteId",
                table: "CreditNote_Services",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNote_Services_ServicesId",
                table: "CreditNote_Services",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_EmailsTemplatesId",
                table: "CreditNotes",
                column: "EmailsTemplatesId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNotes_UserId",
                table: "CreditNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNtotes_Client_COCId",
                table: "CreditNtotes_Client",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditNtotes_Client_CreditNoteId",
                table: "CreditNtotes_Client",
                column: "CreditNoteId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditTypeDescriptions_CreditTypesId",
                table: "CreditTypeDescriptions",
                column: "CreditTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditUsage_descriptions_CreditUsageId",
                table: "CreditUsage_descriptions",
                column: "CreditUsageId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditUsages_COCId",
                table: "CreditUsages",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_CreditUsages_CreditTypesId",
                table: "CreditUsages",
                column: "CreditTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_DaysOff_HolidayLists_HolidayListsId",
                table: "DaysOff_HolidayLists",
                column: "HolidayListsId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_Descriptions_DepartmentId",
                table: "Department_Descriptions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_EmployeesId",
                table: "Departments",
                column: "EmployeesId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Designation_Descriptions_DesignationId",
                table: "Designation_Descriptions",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountsPerItems_ItemsInSalesInvoicesId",
                table: "DiscountsPerItems",
                column: "ItemsInSalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_DiscountsPerService_ServicesInSalesInvicesId",
                table: "DiscountsPerService",
                column: "ServicesInSalesInvicesId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAddress_EmployeeId",
                table: "EmployeeAddress",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeLevel_descs_EmployessLevelId",
                table: "EmployeeLevel_descs",
                column: "EmployessLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeNotes_EmployeeId",
                table: "EmployeeNotes",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CountryId",
                table: "Employees",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DesignationId",
                table: "Employees",
                column: "DesignationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeLevelId",
                table: "Employees",
                column: "EmployeeLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeShiftsId",
                table: "Employees",
                column: "EmployeeShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_EmployeeTypeId",
                table: "Employees",
                column: "EmployeeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_HolidayListsId",
                table: "Employees",
                column: "HolidayListsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_VacationsPolicy_LeavePolicyId",
                table: "Employees",
                column: "VacationsPolicy_LeavePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_customFields_EmployeesId",
                table: "Employees_customFields",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_customFields_Fields_Per_ServiceId",
                table: "Employees_customFields",
                column: "Fields_Per_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_In_Branch_BranchId",
                table: "Employees_In_Branch",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTypes_descs_EmployeeTypesId",
                table: "EmployeeTypes_descs",
                column: "EmployeeTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_AddBy_empId",
                table: "Estimates",
                column: "AddBy_empId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_CurrencyId",
                table: "Estimates",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_EmailsTemplatesId",
                table: "Estimates",
                column: "EmailsTemplatesId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_Clients_COCId",
                table: "Estimates_Clients",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_Clients_EstimateId",
                table: "Estimates_Clients",
                column: "EstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_Items_EstimateId",
                table: "Estimates_Items",
                column: "EstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_Items_ItemVariantsId",
                table: "Estimates_Items",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_Services_EstimateId",
                table: "Estimates_Services",
                column: "EstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_Estimates_Services_ServicesId",
                table: "Estimates_Services",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimatesAttachments_EstimateId",
                table: "EstimatesAttachments",
                column: "EstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimatesNotes_EstimateId",
                table: "EstimatesNotes",
                column: "EstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimatesShippingFees_EstimateId",
                table: "EstimatesShippingFees",
                column: "EstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimatesStatuses_EstimateId",
                table: "EstimatesStatuses",
                column: "EstimateId");

            migrationBuilder.CreateIndex(
                name: "IX_EstimatesStatuses_StatusId",
                table: "EstimatesStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Field_Choices_Fields_PropertiesId",
                table: "Field_Choices",
                column: "Fields_PropertiesId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_layouts_Fields_validation_Foreach_ServiceId",
                table: "Fields_layouts",
                column: "Fields_validation_Foreach_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Per_Service_FieldsInSystemId",
                table: "Fields_Per_Service",
                column: "FieldsInSystemId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Per_Service_SystemsInERPId",
                table: "Fields_Per_Service",
                column: "SystemsInERPId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_Properties_Fields_validation_Foreach_ServiceId",
                table: "Fields_Properties",
                column: "Fields_validation_Foreach_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Fields_validation_Foreach_Services_Fields_Per_ServiceId",
                table: "Fields_validation_Foreach_Services",
                column: "Fields_Per_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Inbound_Invent_Requisitions_InventoryId",
                table: "Inbound_Invent_Requisitions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Inbound_Invent_Requisitions_ItemVariantsId",
                table: "Inbound_Invent_Requisitions",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_InboundNotes_Inbound_Invent_RequisitionsId",
                table: "InboundNotes",
                column: "Inbound_Invent_RequisitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_COCs_COCId",
                table: "Individual_COCs",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_Attachments_InsuranceAgentId",
                table: "Insurance_Attachments",
                column: "InsuranceAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_Insurance_descriptions_InsuranceAgentId",
                table: "Insurance_descriptions",
                column: "InsuranceAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceAgents_AddedBy_EmployeesId",
                table: "InsuranceAgents",
                column: "AddedBy_EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_AddedBy_EmpId",
                table: "Inventories",
                column: "AddedBy_EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAddresses_InventoryId",
                table: "InventoryAddresses",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Per_Subcategories_ItemId",
                table: "Item_Per_Subcategories",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Per_Subcategories_ItemSubCategoryId",
                table: "Item_Per_Subcategories",
                column: "ItemSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Units_ItemId",
                table: "Item_Units",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_Units_UnitsId",
                table: "Item_Units",
                column: "UnitsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBrands_BrandsId",
                table: "ItemBrands",
                column: "BrandsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemBrands_ItemId",
                table: "ItemBrands",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemDescriptions_ItemId",
                table: "ItemDescriptions",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemNotes_ItemId",
                table: "ItemNotes",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CustomFields_Fields_Per_ServiceId",
                table: "Items_CustomFields",
                column: "Fields_Per_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_CustomFields_ItemId",
                table: "Items_CustomFields",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_In_PurchaseInvoices_InventoriesId",
                table: "Items_In_PurchaseInvoices",
                column: "InventoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_In_PurchaseInvoices_ItemVariantsId",
                table: "Items_In_PurchaseInvoices",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_In_PurchaseInvoices_Purchase_invoicesId",
                table: "Items_In_PurchaseInvoices",
                column: "Purchase_invoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_in_Refunds_InventoriesId",
                table: "Items_in_Refunds",
                column: "InventoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_in_Refunds_ItemVariantsId",
                table: "Items_in_Refunds",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_in_Refunds_Purchase_RefundRequestsId",
                table: "Items_in_Refunds",
                column: "Purchase_RefundRequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_NoEpires_InventoryId",
                table: "Items_NoEpires",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_NoEpires_ItemVariantsId",
                table: "Items_NoEpires",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_withEpires_InventoryId",
                table: "Items_withEpires",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_withEpires_ItemVariantsId",
                table: "Items_withEpires",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInSalesInvoices_InventoriesId",
                table: "ItemsInSalesInvoices",
                column: "InventoriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInSalesInvoices_ItemVariantsId",
                table: "ItemsInSalesInvoices",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsInSalesInvoices_SalesInvoicesId",
                table: "ItemsInSalesInvoices",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemSubCategories_ItemMainCategoryId",
                table: "ItemSubCategories",
                column: "ItemMainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemsVariant_RetailPrices_ItemVariantsId",
                table: "ItemsVariant_RetailPrices",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTaxSettings_ItemId",
                table: "ItemTaxSettings",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTaxSettings_TaxSettingsId",
                table: "ItemTaxSettings",
                column: "TaxSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariant_WholeSalePrices_ItemVariantsId",
                table: "ItemVariant_WholeSalePrices",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_ItemVariants_ItemId",
                table: "ItemVariants",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanNotes_LoansId",
                table: "LoanNotes",
                column: "LoansId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_CurrencyId",
                table: "Loans",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_EmployeesId",
                table: "Loans",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Loans_TreasuriesId",
                table: "Loans",
                column: "TreasuriesId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualAttandanceEachDay_PresentStatuses_ManualAttendenceEachDayId",
                table: "ManualAttandanceEachDay_PresentStatuses",
                column: "ManualAttendenceEachDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualAttandanceEachDay_PresentStatuses_VacationsType_LeaveTypeId",
                table: "ManualAttandanceEachDay_PresentStatuses",
                column: "VacationsType_LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualAttendanceEachDay_notes_ManualAttendenceEachDayId",
                table: "ManualAttendanceEachDay_notes",
                column: "ManualAttendenceEachDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualAttendanceEachDay_VacationStatus_ManualAttendenceEachDayId",
                table: "ManualAttendanceEachDay_VacationStatus",
                column: "ManualAttendenceEachDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualAttendanceEachDay_VacationStatus_VacationsType_LeaveTypeId",
                table: "ManualAttendanceEachDay_VacationStatus",
                column: "VacationsType_LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ManualAttendanceEachDays_EmployeesId",
                table: "ManualAttendanceEachDays",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipDescriptions_MembershipsId",
                table: "MembershipDescriptions",
                column: "MembershipsId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_COCId",
                table: "Memberships",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_PackagesId",
                table: "Memberships",
                column: "PackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_SalesInvoicesId",
                table: "Memberships",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_MinAndMaxDate_Fields_validation_Foreach_ServiceId",
                table: "MinAndMaxDate",
                column: "Fields_validation_Foreach_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MinAndMaxNumbers_Fields_validation_Foreach_ServiceId",
                table: "MinAndMaxNumbers",
                column: "Fields_validation_Foreach_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberingSettings_SystemsInERPId",
                table: "NumberingSettings",
                column: "SystemsInERPId");

            migrationBuilder.CreateIndex(
                name: "IX_NumberSettings_Prefixes_NumberingSettingsId",
                table: "NumberSettings_Prefixes",
                column: "NumberingSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Outbound_Invent_Requisitions_InventoryId",
                table: "Outbound_Invent_Requisitions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Outbound_Invent_Requisitions_ItemVariantsId",
                table: "Outbound_Invent_Requisitions",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_OutboundNotes_Outbound_Invent_RequisitionsId",
                table: "OutboundNotes",
                column: "Outbound_Invent_RequisitionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CreditType_CreditTypesId",
                table: "Packages_CreditType",
                column: "CreditTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_CreditType_PackagesId",
                table: "Packages_CreditType",
                column: "PackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_Packages_Descriptions_PackagesId",
                table: "Packages_Descriptions",
                column: "PackagesId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperImages_EmployeeId",
                table: "PaperImages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableCheck_Attachments_PayableCheckId",
                table: "PayableCheck_Attachments",
                column: "PayableCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_PayableCheck_Descriptions_PayableCheckId",
                table: "PayableCheck_Descriptions",
                column: "PayableCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_CurrencyId",
                table: "Payslips",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_EmployeesId",
                table: "Payslips",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_Deductions_PayslipsId",
                table: "Payslips_Deductions",
                column: "PayslipsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_Deductions_SalaryDetuctionId",
                table: "Payslips_Deductions",
                column: "SalaryDetuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_Earns_PayslipsId",
                table: "Payslips_Earns",
                column: "PayslipsId");

            migrationBuilder.CreateIndex(
                name: "IX_Payslips_Earns_SalaryEarningId",
                table: "Payslips_Earns",
                column: "SalaryEarningId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceList_Items_ItemVariantsId",
                table: "PriceList_Items",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceList_Items_PriceListId",
                table: "PriceList_Items",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_priceList_Services_PriceListId",
                table: "priceList_Services",
                column: "PriceListId");

            migrationBuilder.CreateIndex(
                name: "IX_priceList_Services_ServicesId",
                table: "priceList_Services",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Attachments_Purchase_invoicesId",
                table: "Purchase_Attachments",
                column: "Purchase_invoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_invoices_CurrencyId",
                table: "Purchase_invoices",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Payments_Purchase_invoicesId",
                table: "Purchase_Payments",
                column: "Purchase_invoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_Payments_PurchasePaymentMethodsId",
                table: "Purchase_Payments",
                column: "PurchasePaymentMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_RefundedServices_Purchase_RefundRequestsId",
                table: "Purchase_RefundedServices",
                column: "Purchase_RefundRequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_RefundedServices_ServicesId",
                table: "Purchase_RefundedServices",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchase_RefundRequests_CurrencyId",
                table: "Purchase_RefundRequests",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_Deposits_Purchase_invoicesId",
                table: "Purchases_Deposits",
                column: "Purchase_invoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_discounts_Purchase_invoicesId",
                table: "Purchases_discounts",
                column: "Purchase_invoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_paymentTerms_Purchase_invoicesId",
                table: "Purchases_paymentTerms",
                column: "Purchase_invoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_shippingFees_Purchase_invoicesId",
                table: "Purchases_shippingFees",
                column: "Purchase_invoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesInvoice_Services_Purchase_invoicesId",
                table: "PurchasesInvoice_Services",
                column: "Purchase_invoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchasesInvoice_Services_ServicesId",
                table: "PurchasesInvoice_Services",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_PurchaseStatuses_Purchase_invoicesId",
                table: "PurchaseStatuses",
                column: "Purchase_invoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivableCheck_Attachments_ReceivableCheckId",
                table: "ReceivableCheck_Attachments",
                column: "ReceivableCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivableCheck_Descriptions_ReceivableCheckId",
                table: "ReceivableCheck_Descriptions",
                column: "ReceivableCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_ReceivableCheck_Endorsements_ReceivableCheckId",
                table: "ReceivableCheck_Endorsements",
                column: "ReceivableCheckId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundedItems_CreditNote_ItemsId",
                table: "RefundedItems",
                column: "CreditNote_ItemsId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundedItems_ItemsInSalesInvoicesId",
                table: "RefundedItems",
                column: "ItemsInSalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundedServices_CreditNote_ServicesId",
                table: "RefundedServices",
                column: "CreditNote_ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundedServices_ServicesInSalesInvicesId",
                table: "RefundedServices",
                column: "ServicesInSalesInvicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_Attachments_Purchase_RefundRequestsId",
                table: "Refunds_Attachments",
                column: "Purchase_RefundRequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_items_ShippingFees_Purchase_RefundRequestsId",
                table: "Refunds_items_ShippingFees",
                column: "Purchase_RefundRequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_Refunds_Notes_Purchase_RefundRequestsId",
                table: "Refunds_Notes",
                column: "Purchase_RefundRequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_RefundsStatuses_Purchase_RefundRequestsId",
                table: "RefundsStatuses",
                column: "Purchase_RefundRequestsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryComponentsAmounts_SalaryComponentsId",
                table: "SalaryComponentsAmounts",
                column: "SalaryComponentsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryComponentsFormulas_SalaryComponentsId",
                table: "SalaryComponentsFormulas",
                column: "SalaryComponentsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryDetuction_SalaryComponentsId",
                table: "SalaryDetuction",
                column: "SalaryComponentsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryEarnings_SalaryComponentsId",
                table: "SalaryEarnings",
                column: "SalaryComponentsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStructures_Deduction_SalaryDetuctionId",
                table: "SalaryStructures_Deduction",
                column: "SalaryDetuctionId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStructures_Deduction_SalaryStructuresId",
                table: "SalaryStructures_Deduction",
                column: "SalaryStructuresId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStructures_earns_SalaryEarningId",
                table: "SalaryStructures_earns",
                column: "SalaryEarningId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStructures_earns_SalaryStructuresId",
                table: "SalaryStructures_earns",
                column: "SalaryStructuresId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_AutomaticReminders_AutomaticRemindersId",
                table: "SalesInvoice_AutomaticReminders",
                column: "AutomaticRemindersId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_AutomaticReminders_SalesInvoicesId",
                table: "SalesInvoice_AutomaticReminders",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoice_TotalDsicounts_SalesInvoicesId",
                table: "SalesInvoice_TotalDsicounts",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayments_CollectedBy_EmpId",
                table: "SalesInvoicePayments",
                column: "CollectedBy_EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayments_CurrencyId",
                table: "SalesInvoicePayments",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayments_PaymentMethodsId",
                table: "SalesInvoicePayments",
                column: "PaymentMethodsId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayments_PaymentStatusId",
                table: "SalesInvoicePayments",
                column: "PaymentStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayments_Attachments_SalesInvoicePaymentsID",
                table: "SalesInvoicePayments_Attachments",
                column: "SalesInvoicePaymentsID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayments_Details_SalesInvoicePaymentsID",
                table: "SalesInvoicePayments_Details",
                column: "SalesInvoicePaymentsID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoicePayments_Notes_SalesInvoicePaymentsID",
                table: "SalesInvoicePayments_Notes",
                column: "SalesInvoicePaymentsID");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_COCId",
                table: "SalesInvoices",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_CreatedBy_UserId",
                table: "SalesInvoices",
                column: "CreatedBy_UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesInvoices_Attachments_SalesInvoicesId",
                table: "SalesInvoices_Attachments",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesSettings_Fields_Per_ServiceId",
                table: "SalesSettings",
                column: "Fields_Per_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_SalesSettings_SalesInvoicesId",
                table: "SalesSettings",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CustomFields_Fields_Per_ServiceId",
                table: "Service_CustomFields",
                column: "Fields_Per_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CustomFields_ServiceId",
                table: "Service_CustomFields",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDescriptions_ServiceId",
                table: "ServiceDescriptions",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceNotes_ServiceId",
                table: "ServiceNotes",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_ServiceSubCategoryId",
                table: "Services",
                column: "ServiceSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesInSalesInvices_SalesInvoicesId",
                table: "ServicesInSalesInvices",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServicesInSalesInvices_ServicesId",
                table: "ServicesInSalesInvices",
                column: "ServicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceSubCategories_ServiceMainCategoryId",
                table: "ServiceSubCategories",
                column: "ServiceMainCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTaxSettings_ServiceId",
                table: "ServiceTaxSettings",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTaxSettings_TaxSettingsId",
                table: "ServiceTaxSettings",
                column: "TaxSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftsTimeDetails_ShiftId",
                table: "ShiftsTimeDetails",
                column: "ShiftId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingDetails_SalesInvoicesId",
                table: "ShippingDetails",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingOptions_TaxSettingsId",
                table: "ShippingOptions",
                column: "TaxSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_For_EachInvoice_SalesInvoicesId",
                table: "Statuses_For_EachInvoice",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_For_EachInvoice_SalesInvoicesStatusId",
                table: "Statuses_For_EachInvoice",
                column: "SalesInvoicesStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_AutomaticReminders_AutomaticRemindersId",
                table: "Subscription_AutomaticReminders",
                column: "AutomaticRemindersId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_AutomaticReminders_SubscriptionsId",
                table: "Subscription_AutomaticReminders",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_Invoices_SalesInvoicesId",
                table: "Subscription_Invoices",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_Invoices_SubscriptionsId",
                table: "Subscription_Invoices",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_Notes_SubscriptionsId",
                table: "Subscription_Notes",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_Terms_SubscriptionsId",
                table: "Subscription_Terms",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionAttachments_SubscriptionsId",
                table: "SubscriptionAttachments",
                column: "SubscriptionsId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_COCId",
                table: "Subscriptions",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_CurrencyId",
                table: "Subscriptions",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_ContactLists_SuppliersId",
                table: "Supplier_ContactLists",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CustomFields_Fields_Per_ServiceId",
                table: "Supplier_CustomFields",
                column: "Fields_Per_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_CustomFields_SuppliersId",
                table: "Supplier_CustomFields",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_Supplier_notes_SuppliersId",
                table: "Supplier_notes",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierAddresses_SuppliersId",
                table: "SupplierAddresses",
                column: "SuppliersId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CountryId",
                table: "Suppliers",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CurrencyId",
                table: "Suppliers",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_EmployeesId",
                table: "Suppliers",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPer_Item_PerInvoice_ItemsInSalesInvoicesId",
                table: "TaxPer_Item_PerInvoice",
                column: "ItemsInSalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPer_Item_PerInvoice_TaxSettingsId",
                table: "TaxPer_Item_PerInvoice",
                column: "TaxSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPerService_PerInvoices_ServicesInSalesInvicesId",
                table: "TaxPerService_PerInvoices",
                column: "ServicesInSalesInvicesId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPerService_PerInvoices_TaxSettingsId",
                table: "TaxPerService_PerInvoices",
                column: "TaxSettingsId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_Per_Invoice_SalesInvoicesId",
                table: "Terms_Per_Invoice",
                column: "SalesInvoicesId");

            migrationBuilder.CreateIndex(
                name: "IX_Terms_Per_Invoice_SalesTermsId",
                table: "Terms_Per_Invoice",
                column: "SalesTermsId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferBetweenInvent_notes_TransferBetweenInventId",
                table: "TransferBetweenInvent_notes",
                column: "TransferBetweenInventId");

            migrationBuilder.CreateIndex(
                name: "IX_TransferBetweenInvents_ItemVariantsId",
                table: "TransferBetweenInvents",
                column: "ItemVariantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Treasury_Descriptions_TreasuriesId",
                table: "Treasury_Descriptions",
                column: "TreasuriesId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationPolicy_Types_VacationsPolicy_LeavePolicyId",
                table: "VacationPolicy_Types",
                column: "VacationsPolicy_LeavePolicyId");

            migrationBuilder.CreateIndex(
                name: "IX_VacationPolicy_Types_VacationsType_LeaveTypeId",
                table: "VacationPolicy_Types",
                column: "VacationsType_LeaveTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Withdraw_NoExpires_Items_NoEpireId",
                table: "Withdraw_NoExpires",
                column: "Items_NoEpireId");

            migrationBuilder.CreateIndex(
                name: "IX_Withdraw_WithExpires_Items_withEpireId",
                table: "Withdraw_WithExpires",
                column: "Items_withEpireId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_CurrencyId",
                table: "WorkOrders",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_Attachments_WorkOrdersId",
                table: "WorkOrders_Attachments",
                column: "WorkOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrders_Descriptions_WorkOrdersId",
                table: "WorkOrders_Descriptions",
                column: "WorkOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrdersActions_WorkOrdersId",
                table: "WorkOrdersActions",
                column: "WorkOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrdersClients_COCid",
                table: "WorkOrdersClients",
                column: "COCid");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrdersClients_WorkOrdersId",
                table: "WorkOrdersClients",
                column: "WorkOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrdersEmployees_EmployeesId",
                table: "WorkOrdersEmployees",
                column: "EmployeesId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrdersEmployees_WorkOrdersId",
                table: "WorkOrdersEmployees",
                column: "WorkOrdersId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkOrderStatuses_WorkOrdersId",
                table: "WorkOrderStatuses",
                column: "WorkOrdersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

            migrationBuilder.DropTable(
                name: "Addition_NoExpires");

            migrationBuilder.DropTable(
                name: "Addition_WithExpire");

            migrationBuilder.DropTable(
                name: "Appointments_Actions");

            migrationBuilder.DropTable(
                name: "Appointments_Notes");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AttendanceDaysPerEmps");

            migrationBuilder.DropTable(
                name: "AttendanceFlags");

            migrationBuilder.DropTable(
                name: "AttendancePermission_DelayPermissions");

            migrationBuilder.DropTable(
                name: "AttendancePermission_notes");

            migrationBuilder.DropTable(
                name: "AttendancePermission_VacationPerms");

            migrationBuilder.DropTable(
                name: "AttendanceSettings");

            migrationBuilder.DropTable(
                name: "BankAccount_Descriptions");

            migrationBuilder.DropTable(
                name: "Booking_Clients");

            migrationBuilder.DropTable(
                name: "Booking_Services");

            migrationBuilder.DropTable(
                name: "BookingSettings_AssignedEmployee");

            migrationBuilder.DropTable(
                name: "BranchesAddresses");

            migrationBuilder.DropTable(
                name: "BranchesSettings");

            migrationBuilder.DropTable(
                name: "Business_COCs");

            migrationBuilder.DropTable(
                name: "Category_PerClient");

            migrationBuilder.DropTable(
                name: "CheckBook_Notes");

            migrationBuilder.DropTable(
                name: "ClientNotes");

            migrationBuilder.DropTable(
                name: "ClientStatuses");

            migrationBuilder.DropTable(
                name: "COC_CustomFields");

            migrationBuilder.DropTable(
                name: "COCAddresses");

            migrationBuilder.DropTable(
                name: "Commissions_ItemCats");

            migrationBuilder.DropTable(
                name: "Commissions_items");

            migrationBuilder.DropTable(
                name: "Commissions_Per_employee");

            migrationBuilder.DropTable(
                name: "Commissions_SerCat");

            migrationBuilder.DropTable(
                name: "Commissions_Services");

            migrationBuilder.DropTable(
                name: "CommissionsNotes");

            migrationBuilder.DropTable(
                name: "ConstactList_PerCOC");

            migrationBuilder.DropTable(
                name: "ContractDurations");

            migrationBuilder.DropTable(
                name: "ContractEndDates");

            migrationBuilder.DropTable(
                name: "Contracts_Deductions");

            migrationBuilder.DropTable(
                name: "Contracts_earns");

            migrationBuilder.DropTable(
                name: "ContractsAttachments");

            migrationBuilder.DropTable(
                name: "CreditCharge_descriptions");

            migrationBuilder.DropTable(
                name: "CreditNote_Attachments");

            migrationBuilder.DropTable(
                name: "CreditNote_Notes");

            migrationBuilder.DropTable(
                name: "CreditNtotes_Client");

            migrationBuilder.DropTable(
                name: "CreditTypeDescriptions");

            migrationBuilder.DropTable(
                name: "CreditUsage_descriptions");

            migrationBuilder.DropTable(
                name: "DaysOff_HolidayLists");

            migrationBuilder.DropTable(
                name: "Department_Descriptions");

            migrationBuilder.DropTable(
                name: "Designation_Descriptions");

            migrationBuilder.DropTable(
                name: "DiscountsPerItems");

            migrationBuilder.DropTable(
                name: "DiscountsPerService");

            migrationBuilder.DropTable(
                name: "EmployeeAddress");

            migrationBuilder.DropTable(
                name: "EmployeeLevel_descs");

            migrationBuilder.DropTable(
                name: "EmployeeNotes");

            migrationBuilder.DropTable(
                name: "Employees_customFields");

            migrationBuilder.DropTable(
                name: "Employees_In_Branch");

            migrationBuilder.DropTable(
                name: "EmployeeTypes_descs");

            migrationBuilder.DropTable(
                name: "Estimates_Clients");

            migrationBuilder.DropTable(
                name: "Estimates_Items");

            migrationBuilder.DropTable(
                name: "Estimates_Services");

            migrationBuilder.DropTable(
                name: "EstimatesAttachments");

            migrationBuilder.DropTable(
                name: "EstimatesNotes");

            migrationBuilder.DropTable(
                name: "EstimatesShippingFees");

            migrationBuilder.DropTable(
                name: "EstimatesStatuses");

            migrationBuilder.DropTable(
                name: "Field_Choices");

            migrationBuilder.DropTable(
                name: "Fields_layouts");

            migrationBuilder.DropTable(
                name: "InboundNotes");

            migrationBuilder.DropTable(
                name: "Individual_COCs");

            migrationBuilder.DropTable(
                name: "Insurance_Attachments");

            migrationBuilder.DropTable(
                name: "Insurance_descriptions");

            migrationBuilder.DropTable(
                name: "InventoryAddresses");

            migrationBuilder.DropTable(
                name: "Item_Per_Subcategories");

            migrationBuilder.DropTable(
                name: "Item_Units");

            migrationBuilder.DropTable(
                name: "ItemBrands");

            migrationBuilder.DropTable(
                name: "ItemDescriptions");

            migrationBuilder.DropTable(
                name: "ItemNotes");

            migrationBuilder.DropTable(
                name: "Items_CustomFields");

            migrationBuilder.DropTable(
                name: "Items_In_PurchaseInvoices");

            migrationBuilder.DropTable(
                name: "Items_in_Refunds");

            migrationBuilder.DropTable(
                name: "ItemsVariant_RetailPrices");

            migrationBuilder.DropTable(
                name: "ItemTaxSettings");

            migrationBuilder.DropTable(
                name: "ItemVariant_WholeSalePrices");

            migrationBuilder.DropTable(
                name: "LoanNotes");

            migrationBuilder.DropTable(
                name: "ManualAttandanceEachDay_PresentStatuses");

            migrationBuilder.DropTable(
                name: "ManualAttendanceEachDay_notes");

            migrationBuilder.DropTable(
                name: "ManualAttendanceEachDay_VacationStatus");

            migrationBuilder.DropTable(
                name: "MembershipDescriptions");

            migrationBuilder.DropTable(
                name: "MinAndMaxDate");

            migrationBuilder.DropTable(
                name: "MinAndMaxNumbers");

            migrationBuilder.DropTable(
                name: "NumberSettings_Prefixes");

            migrationBuilder.DropTable(
                name: "OtherSettings");

            migrationBuilder.DropTable(
                name: "OutboundNotes");

            migrationBuilder.DropTable(
                name: "Packages_CreditType");

            migrationBuilder.DropTable(
                name: "Packages_Descriptions");

            migrationBuilder.DropTable(
                name: "PaperImages");

            migrationBuilder.DropTable(
                name: "PayableCheck_Attachments");

            migrationBuilder.DropTable(
                name: "PayableCheck_Descriptions");

            migrationBuilder.DropTable(
                name: "Payslips_Deductions");

            migrationBuilder.DropTable(
                name: "Payslips_Earns");

            migrationBuilder.DropTable(
                name: "PriceList_Items");

            migrationBuilder.DropTable(
                name: "priceList_Services");

            migrationBuilder.DropTable(
                name: "Purchase_Attachments");

            migrationBuilder.DropTable(
                name: "Purchase_Payments");

            migrationBuilder.DropTable(
                name: "Purchase_RefundedServices");

            migrationBuilder.DropTable(
                name: "Purchases_Deposits");

            migrationBuilder.DropTable(
                name: "Purchases_discounts");

            migrationBuilder.DropTable(
                name: "Purchases_paymentTerms");

            migrationBuilder.DropTable(
                name: "Purchases_shippingFees");

            migrationBuilder.DropTable(
                name: "PurchasesInvoice_Services");

            migrationBuilder.DropTable(
                name: "PurchaseStatuses");

            migrationBuilder.DropTable(
                name: "ReceivableCheck_Attachments");

            migrationBuilder.DropTable(
                name: "ReceivableCheck_Descriptions");

            migrationBuilder.DropTable(
                name: "ReceivableCheck_Endorsements");

            migrationBuilder.DropTable(
                name: "RefundedItems");

            migrationBuilder.DropTable(
                name: "RefundedServices");

            migrationBuilder.DropTable(
                name: "Refunds_Attachments");

            migrationBuilder.DropTable(
                name: "Refunds_items_ShippingFees");

            migrationBuilder.DropTable(
                name: "Refunds_Notes");

            migrationBuilder.DropTable(
                name: "RefundsStatuses");

            migrationBuilder.DropTable(
                name: "SalaryComponentsAmounts");

            migrationBuilder.DropTable(
                name: "SalaryComponentsFormulas");

            migrationBuilder.DropTable(
                name: "SalaryStructures_Deduction");

            migrationBuilder.DropTable(
                name: "SalaryStructures_earns");

            migrationBuilder.DropTable(
                name: "SalesInvoice_AutomaticReminders");

            migrationBuilder.DropTable(
                name: "SalesInvoice_TotalDsicounts");

            migrationBuilder.DropTable(
                name: "SalesInvoicePayments_Attachments");

            migrationBuilder.DropTable(
                name: "SalesInvoicePayments_Details");

            migrationBuilder.DropTable(
                name: "SalesInvoicePayments_Notes");

            migrationBuilder.DropTable(
                name: "SalesInvoices_Attachments");

            migrationBuilder.DropTable(
                name: "SalesSettings");

            migrationBuilder.DropTable(
                name: "Service_CustomFields");

            migrationBuilder.DropTable(
                name: "ServiceDescriptions");

            migrationBuilder.DropTable(
                name: "ServiceNotes");

            migrationBuilder.DropTable(
                name: "ServiceTaxSettings");

            migrationBuilder.DropTable(
                name: "ShiftsTimeDetails");

            migrationBuilder.DropTable(
                name: "ShippingDetails");

            migrationBuilder.DropTable(
                name: "ShippingOptions");

            migrationBuilder.DropTable(
                name: "Statuses_For_EachInvoice");

            migrationBuilder.DropTable(
                name: "Subscription_AutomaticReminders");

            migrationBuilder.DropTable(
                name: "Subscription_Invoices");

            migrationBuilder.DropTable(
                name: "Subscription_Notes");

            migrationBuilder.DropTable(
                name: "Subscription_Terms");

            migrationBuilder.DropTable(
                name: "SubscriptionAttachments");

            migrationBuilder.DropTable(
                name: "Supplier_ContactLists");

            migrationBuilder.DropTable(
                name: "Supplier_CustomFields");

            migrationBuilder.DropTable(
                name: "Supplier_notes");

            migrationBuilder.DropTable(
                name: "SupplierAddresses");

            migrationBuilder.DropTable(
                name: "TaxPer_Item_PerInvoice");

            migrationBuilder.DropTable(
                name: "TaxPerService_PerInvoices");

            migrationBuilder.DropTable(
                name: "Terms_Per_Invoice");

            migrationBuilder.DropTable(
                name: "TransferBetweenInvent_notes");

            migrationBuilder.DropTable(
                name: "Treasury_Descriptions");

            migrationBuilder.DropTable(
                name: "VacationPolicy_Types");

            migrationBuilder.DropTable(
                name: "Withdraw_NoExpires");

            migrationBuilder.DropTable(
                name: "Withdraw_WithExpires");

            migrationBuilder.DropTable(
                name: "WorkOrders_Attachments");

            migrationBuilder.DropTable(
                name: "WorkOrders_Descriptions");

            migrationBuilder.DropTable(
                name: "WorkOrdersActions");

            migrationBuilder.DropTable(
                name: "WorkOrdersClients");

            migrationBuilder.DropTable(
                name: "WorkOrdersEmployees");

            migrationBuilder.DropTable(
                name: "WorkOrderStatuses");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AttendanceSheets");

            migrationBuilder.DropTable(
                name: "AttendancePermissions");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Booking_settings");

            migrationBuilder.DropTable(
                name: "COC_category");

            migrationBuilder.DropTable(
                name: "CheckBooks");

            migrationBuilder.DropTable(
                name: "Commissions");

            migrationBuilder.DropTable(
                name: "COC_ContactList");

            migrationBuilder.DropTable(
                name: "Contract_Per_Emps");

            migrationBuilder.DropTable(
                name: "CreditCharges");

            migrationBuilder.DropTable(
                name: "CreditUsages");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "BusinessBranches");

            migrationBuilder.DropTable(
                name: "Estimates");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Fields_Properties");

            migrationBuilder.DropTable(
                name: "Inbound_Invent_Requisitions");

            migrationBuilder.DropTable(
                name: "InsuranceAgents");

            migrationBuilder.DropTable(
                name: "ItemSubCategories");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "Loans");

            migrationBuilder.DropTable(
                name: "ManualAttendanceEachDays");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "NumberingSettings");

            migrationBuilder.DropTable(
                name: "Outbound_Invent_Requisitions");

            migrationBuilder.DropTable(
                name: "PayableChecks");

            migrationBuilder.DropTable(
                name: "Payslips");

            migrationBuilder.DropTable(
                name: "PriceLists");

            migrationBuilder.DropTable(
                name: "PurchasePaymentMethods");

            migrationBuilder.DropTable(
                name: "Purchase_invoices");

            migrationBuilder.DropTable(
                name: "ReceivableChecks");

            migrationBuilder.DropTable(
                name: "CreditNote_Items");

            migrationBuilder.DropTable(
                name: "CreditNote_Services");

            migrationBuilder.DropTable(
                name: "Purchase_RefundRequests");

            migrationBuilder.DropTable(
                name: "SalaryDetuction");

            migrationBuilder.DropTable(
                name: "SalaryEarnings");

            migrationBuilder.DropTable(
                name: "SalaryStructures");

            migrationBuilder.DropTable(
                name: "SalesInvoicePayments");

            migrationBuilder.DropTable(
                name: "SalesInvoicesStatuses");

            migrationBuilder.DropTable(
                name: "AutomaticReminders");

            migrationBuilder.DropTable(
                name: "Subscriptions");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "ItemsInSalesInvoices");

            migrationBuilder.DropTable(
                name: "ServicesInSalesInvices");

            migrationBuilder.DropTable(
                name: "TaxSettings");

            migrationBuilder.DropTable(
                name: "TermsAndConditions");

            migrationBuilder.DropTable(
                name: "TransferBetweenInvents");

            migrationBuilder.DropTable(
                name: "VacationsType_LeaveTypes");

            migrationBuilder.DropTable(
                name: "Items_NoEpires");

            migrationBuilder.DropTable(
                name: "Items_withEpires");

            migrationBuilder.DropTable(
                name: "WorkOrders");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "CreditTypes");

            migrationBuilder.DropTable(
                name: "Fields_validation_Foreach_Services");

            migrationBuilder.DropTable(
                name: "ItemMainCategories");

            migrationBuilder.DropTable(
                name: "Treasuries");

            migrationBuilder.DropTable(
                name: "Packages");

            migrationBuilder.DropTable(
                name: "CreditNotes");

            migrationBuilder.DropTable(
                name: "SallaryComponents");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "SalesInvoice_PaymentStatus");

            migrationBuilder.DropTable(
                name: "WhenRemidersSents");

            migrationBuilder.DropTable(
                name: "SalesInvoices");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "ItemVariants");

            migrationBuilder.DropTable(
                name: "Fields_Per_Service");

            migrationBuilder.DropTable(
                name: "EmailsTemplates");

            migrationBuilder.DropTable(
                name: "COCs");

            migrationBuilder.DropTable(
                name: "ServiceSubCategories");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "FieldsInSystem");

            migrationBuilder.DropTable(
                name: "SystemsInERP");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "ServiceMainCategories");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EmployeeLevels");

            migrationBuilder.DropTable(
                name: "EmployeeShifts");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "HolidayLists");

            migrationBuilder.DropTable(
                name: "VacationsPolicy_LeavePolicies");
        }
    }
}
