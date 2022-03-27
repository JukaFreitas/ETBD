using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETBDApp.Migrations
{
    public partial class FoodMealPortion_2Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Portion",
                table: "FoodMeals",
                type: "decimal(5,2)",
                precision: 5,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Portion",
                table: "FoodMeals",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(5,2)",
                oldPrecision: 5);
        }
    }
}
