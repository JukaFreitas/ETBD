using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETBDApp.Migrations
{
    public partial class FoodIdMig3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actions_Foods_FoodId",
                table: "Actions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
