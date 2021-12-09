using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations.ApplicationDb
{
    public partial class UpdateInventories4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryAddresses_InventoryAddressId",
                table: "Inventories");

            migrationBuilder.DropIndex(
                name: "IX_Inventories_InventoryAddressId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "InventoryAddressId",
                table: "Inventories");

            migrationBuilder.AddColumn<int>(
                name: "InventoryId",
                table: "InventoryAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_InventoryAddresses_InventoryId",
                table: "InventoryAddresses",
                column: "InventoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryAddresses_Inventories_InventoryId",
                table: "InventoryAddresses",
                column: "InventoryId",
                principalTable: "Inventories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryAddresses_Inventories_InventoryId",
                table: "InventoryAddresses");

            migrationBuilder.DropIndex(
                name: "IX_InventoryAddresses_InventoryId",
                table: "InventoryAddresses");

            migrationBuilder.DropColumn(
                name: "InventoryId",
                table: "InventoryAddresses");

            migrationBuilder.AddColumn<int>(
                name: "InventoryAddressId",
                table: "Inventories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventories_InventoryAddressId",
                table: "Inventories",
                column: "InventoryAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventoryAddresses_InventoryAddressId",
                table: "Inventories",
                column: "InventoryAddressId",
                principalTable: "InventoryAddresses",
                principalColumn: "Id");
        }
    }
}
