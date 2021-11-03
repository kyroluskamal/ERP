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
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    StandardOrAdvanced = table.Column<bool>(type: "bit", nullable: false)
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTypes", x => x.Id);
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
                        name: "FK_Employees_EmployeeShifts_EmployeeShiftsId",
                        column: x => x.EmployeeShiftsId,
                        principalTable: "EmployeeShifts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Abbreviation = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
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
                name: "IX_Department_Descriptions_DepartmentId",
                table: "Department_Descriptions",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_EmployeesId",
                table: "Departments",
                column: "EmployeesId");

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
                name: "IX_Employees_EmployeeShiftsId",
                table: "Employees",
                column: "EmployeeShiftsId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_UserId",
                table: "Employees",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTypes_descs_EmployeeTypesId",
                table: "EmployeeTypes_descs",
                column: "EmployeeTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Individual_COCs_COCId",
                table: "Individual_COCs",
                column: "COCId");

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
                name: "EmployeeTypes_descs");

            migrationBuilder.DropTable(
                name: "Individual_COCs");

            migrationBuilder.DropTable(
                name: "PaperImages");

            migrationBuilder.DropTable(
                name: "ShiftsTimeDetails");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Treasury_Descriptions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

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
                name: "Designations");

            migrationBuilder.DropTable(
                name: "EmployeeLevels");

            migrationBuilder.DropTable(
                name: "EmployeeTypes");

            migrationBuilder.DropTable(
                name: "COCs");

            migrationBuilder.DropTable(
                name: "Treasuries");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Currencies");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "EmployeeShifts");
        }
    }
}
