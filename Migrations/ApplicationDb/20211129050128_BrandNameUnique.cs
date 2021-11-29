using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations.ApplicationDb
{
    public partial class BrandNameUnique : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Balance",
                table: "COCs",
                newName: "TotalBalance");

            migrationBuilder.AlterColumn<int>(
                name: "COC_ContactListId",
                table: "ConstactList_PerCOC",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "COCId",
                table: "ConstactList_PerCOC",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Relational:ColumnOrder", 0);

            migrationBuilder.CreateIndex(
                name: "IX_Units_RetailUnit",
                table: "Units",
                column: "RetailUnit",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Brands_Name",
                table: "Brands",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_RetailUnit",
                table: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Brands_Name",
                table: "Brands");

            migrationBuilder.RenameColumn(
                name: "TotalBalance",
                table: "COCs",
                newName: "Balance");

            migrationBuilder.AlterColumn<int>(
                name: "COC_ContactListId",
                table: "ConstactList_PerCOC",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 1);

            migrationBuilder.AlterColumn<int>(
                name: "COCId",
                table: "ConstactList_PerCOC",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("Relational:ColumnOrder", 0);
        }
    }
}
