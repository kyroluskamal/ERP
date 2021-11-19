using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations.ApplicationDb
{
    public partial class AddConversionRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConversionRate",
                table: "Units",
                type: "int",
                nullable: false,
                computedColumnSql: "[NumberInWholeSale] * [NumberInRetailSale]");

            migrationBuilder.CreateIndex(
                name: "IX_Units_WholeSaleUnit",
                table: "Units",
                column: "WholeSaleUnit",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Units_WholeSaleUnit",
                table: "Units");

            migrationBuilder.DropColumn(
                name: "ConversionRate",
                table: "Units");
        }
    }
}
