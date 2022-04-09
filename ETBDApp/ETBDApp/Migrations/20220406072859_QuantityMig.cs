using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETBDApp.Migrations
{
    public partial class QuantityMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Portion",
                table: "FoodMeals",
                newName: "Quantity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Quantity",
                table: "FoodMeals",
                newName: "Portion");
        }
    }
}
