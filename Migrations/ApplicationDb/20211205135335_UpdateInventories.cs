using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations.ApplicationDb
{
    public partial class UpdateInventories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_Employees_AddedBy_EmpId",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "AddedBy_EmpId",
                table: "Inventories",
                newName: "AddedBy_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_AddedBy_EmpId",
                table: "Inventories",
                newName: "IX_Inventories_AddedBy_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_AspNetUsers_AddedBy_UserId",
                table: "Inventories",
                column: "AddedBy_UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventories_AspNetUsers_AddedBy_UserId",
                table: "Inventories");

            migrationBuilder.RenameColumn(
                name: "AddedBy_UserId",
                table: "Inventories",
                newName: "AddedBy_EmpId");

            migrationBuilder.RenameIndex(
                name: "IX_Inventories_AddedBy_UserId",
                table: "Inventories",
                newName: "IX_Inventories_AddedBy_EmpId");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventories_Employees_AddedBy_EmpId",
                table: "Inventories",
                column: "AddedBy_EmpId",
                principalTable: "Employees",
                principalColumn: "Id");
        }
    }
}
