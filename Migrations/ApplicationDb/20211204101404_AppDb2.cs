using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations.ApplicationDb
{
    public partial class AppDb2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StatusName",
                table: "Statuses",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Statuses",
                newName: "StatusName");
        }
    }
}
