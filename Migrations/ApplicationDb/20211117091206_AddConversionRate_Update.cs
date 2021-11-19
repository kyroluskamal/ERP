using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations.ApplicationDb
{
    public partial class AddConversionRate_Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<short>(
                name: "ConversionRate",
                table: "Units",
                type: "smallint",
                nullable: false,
                computedColumnSql: "[NumberInWholeSale] * [NumberInRetailSale]",
                oldClrType: typeof(int),
                oldType: "int",
                oldComputedColumnSql: "[NumberInWholeSale] * [NumberInRetailSale]");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ConversionRate",
                table: "Units",
                type: "int",
                nullable: false,
                computedColumnSql: "[NumberInWholeSale] * [NumberInRetailSale]",
                oldClrType: typeof(short),
                oldType: "smallint",
                oldComputedColumnSql: "[NumberInWholeSale] * [NumberInRetailSale]");
        }
    }
}
