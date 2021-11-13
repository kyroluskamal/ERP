using Microsoft.EntityFrameworkCore.Migrations;

namespace ERP.Migrations.ApplicationDb
{
    public partial class SetUniqueMainCatName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ItemMainCategories_Name",
                table: "ItemMainCategories",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ItemMainCategories_Name",
                table: "ItemMainCategories");
        }
    }
}
