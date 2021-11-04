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
                name: "COCs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientType = table.Column<bool>(type: "bool", nullable: false),
                    CreditLimit = table.Column<int>(type: "int", nullable: false),
                    CreditPeriodLimit = table.Column<int>(type: "int", nullable: false),
                    Balance = table.Column<decimal>(type: "Money", nullable: false),
                    BalanceStartDate = table.Column<DateTime>(type: "Date", nullable: false),
                    HasEstimates = table.Column<bool>(type: "bit", nullable: false),
                    HasCategory = table.Column<bool>(type: "bit", nullable: false),
                    HasNote = table.Column<bool>(type: "bit", nullable: false),
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
                name: "AttendanceDaysPerEmps",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AttendanceSheetId = table.Column<int>(type: "int", nullable: false),
                    ManualAttendenceEachDayId = table.Column<int>(type: "int", nullable: false)
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
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_Business_COCs_COCId",
                table: "Business_COCs",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_Category_PerClient_COC_categoryId",
                table: "Category_PerClient",
                column: "COC_categoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientNotes_COCId",
                table: "ClientNotes",
                column: "COCId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientStatuses_COCId",
                table: "ClientStatuses",
                column: "COCId");

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
                name: "IX_ConstactList_PerCOC_COC_ContactListId",
                table: "ConstactList_PerCOC",
                column: "COC_ContactListId");

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
                name: "IX_EmployeeTypes_descs_EmployeeTypesId",
                table: "EmployeeTypes_descs",
                column: "EmployeeTypesId");

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
                name: "IX_Individual_COCs_COCId",
                table: "Individual_COCs",
                column: "COCId");

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
                name: "IX_MinAndMaxDate_Fields_validation_Foreach_ServiceId",
                table: "MinAndMaxDate",
                column: "Fields_validation_Foreach_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_MinAndMaxNumbers_Fields_validation_Foreach_ServiceId",
                table: "MinAndMaxNumbers",
                column: "Fields_validation_Foreach_ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_PaperImages_EmployeeId",
                table: "PaperImages",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_ShiftsTimeDetails_ShiftId",
                table: "ShiftsTimeDetails",
                column: "ShiftId");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Actions");

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
                name: "AutomaticReminders");

            migrationBuilder.DropTable(
                name: "BankAccount_Descriptions");

            migrationBuilder.DropTable(
                name: "Business_COCs");

            migrationBuilder.DropTable(
                name: "Category_PerClient");

            migrationBuilder.DropTable(
                name: "ClientNotes");

            migrationBuilder.DropTable(
                name: "ClientStatuses");

            migrationBuilder.DropTable(
                name: "COCAddresses");

            migrationBuilder.DropTable(
                name: "ConstactList_PerCOC");

            migrationBuilder.DropTable(
                name: "DaysOff_HolidayLists");

            migrationBuilder.DropTable(
                name: "Department_Descriptions");

            migrationBuilder.DropTable(
                name: "Designation_Descriptions");

            migrationBuilder.DropTable(
                name: "EmployeeAddress");

            migrationBuilder.DropTable(
                name: "EmployeeLevel_descs");

            migrationBuilder.DropTable(
                name: "EmployeeNotes");

            migrationBuilder.DropTable(
                name: "Employees_customFields");

            migrationBuilder.DropTable(
                name: "EmployeeTypes_descs");

            migrationBuilder.DropTable(
                name: "Field_Choices");

            migrationBuilder.DropTable(
                name: "Fields_layouts");

            migrationBuilder.DropTable(
                name: "Individual_COCs");

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
                name: "ItemsVariant_RetailPrices");

            migrationBuilder.DropTable(
                name: "ItemTaxSettings");

            migrationBuilder.DropTable(
                name: "ItemVariant_WholeSalePrices");

            migrationBuilder.DropTable(
                name: "ManualAttandanceEachDay_PresentStatuses");

            migrationBuilder.DropTable(
                name: "ManualAttendanceEachDay_notes");

            migrationBuilder.DropTable(
                name: "ManualAttendanceEachDay_VacationStatus");

            migrationBuilder.DropTable(
                name: "MinAndMaxDate");

            migrationBuilder.DropTable(
                name: "MinAndMaxNumbers");

            migrationBuilder.DropTable(
                name: "PaperImages");

            migrationBuilder.DropTable(
                name: "ShiftsTimeDetails");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Treasury_Descriptions");

            migrationBuilder.DropTable(
                name: "VacationPolicy_Types");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AttendanceSheets");

            migrationBuilder.DropTable(
                name: "AttendancePermissions");

            migrationBuilder.DropTable(
                name: "EmailsTemplates");

            migrationBuilder.DropTable(
                name: "WhenRemidersSents");

            migrationBuilder.DropTable(
                name: "BankAccounts");

            migrationBuilder.DropTable(
                name: "COC_category");

            migrationBuilder.DropTable(
                name: "COC_ContactList");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Fields_Properties");

            migrationBuilder.DropTable(
                name: "COCs");

            migrationBuilder.DropTable(
                name: "ItemSubCategories");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "Brands");

            migrationBuilder.DropTable(
                name: "TaxSettings");

            migrationBuilder.DropTable(
                name: "ItemVariants");

            migrationBuilder.DropTable(
                name: "ManualAttendanceEachDays");

            migrationBuilder.DropTable(
                name: "Treasuries");

            migrationBuilder.DropTable(
                name: "VacationsType_LeaveTypes");

            migrationBuilder.DropTable(
                name: "Fields_validation_Foreach_Services");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "ItemMainCategories");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Fields_Per_Service");

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

            migrationBuilder.DropTable(
                name: "FieldsInSystem");

            migrationBuilder.DropTable(
                name: "SystemsInERP");
        }
    }
}
