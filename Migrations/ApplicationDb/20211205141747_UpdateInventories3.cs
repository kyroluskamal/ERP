using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations.ApplicationDb
{
    public partial class UpdateInventories3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryAddresses_InventoryAddressId",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryAddressId",
                table: "Inventories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventoryAddresses_InventoryAddressId",
                table: "Inventories",
                column: "InventoryAddressId",
                principalTable: "InventoryAddresses",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_InventoryAddresses_InventoryAddressId",
                table: "Inventories");

            migrationBuilder.AlterColumn<int>(
                name: "InventoryAddressId",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_InventoryAddresses_InventoryAddressId",
                table: "Inventories",
                column: "InventoryAddressId",
                principalTable: "InventoryAddresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
