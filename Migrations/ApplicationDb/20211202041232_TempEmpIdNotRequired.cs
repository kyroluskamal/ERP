using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations.ApplicationDb
{
    public partial class TempEmpIdNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Employees_AddedBy_EmpId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ItemSKU",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemSKU",
                table: "ItemVariants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AddedBy_EmpId",
                table: "Inventories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Employees_AddedBy_EmpId",
                table: "Inventories",
                column: "AddedBy_EmpId",
                principalTable: "Employees",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Employees_AddedBy_EmpId",
                table: "Inventories");

            migrationBuilder.DropColumn(
                name: "ItemSKU",
                table: "ItemVariants");

            migrationBuilder.AddColumn<int>(
                name: "ItemSKU",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "AddedBy_EmpId",
                table: "Inventories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Employees_AddedBy_EmpId",
                table: "Inventories",
                column: "AddedBy_EmpId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
