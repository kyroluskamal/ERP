using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ERP.Migrations.ApplicationDb
{
    public partial class AddItemImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProductImage",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductImage",
                table: "Items");
        }
    }
}
