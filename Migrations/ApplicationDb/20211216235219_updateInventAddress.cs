using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations.ApplicationDb
{
    public partial class updateInventAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "InventoryAddresses");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "InventoryAddresses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAddresses_CountryId",
                table: "InventoryAddresses",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAddresses_Countries_CountryId",
                table: "InventoryAddresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAddresses_Countries_CountryId",
                table: "InventoryAddresses");

            migrationBuilder.DropIndex(
                name: "IX_InventoryAddresses_CountryId",
                table: "InventoryAddresses");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "InventoryAddresses");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "InventoryAddresses",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
