using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETBDApp.Migrations
{
    public partial class FoodIdMig4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Actions_FoodId",
                table: "Actions");

            migrationBuilder.DropColumn(
                name: "FoodId",
                table: "Actions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
