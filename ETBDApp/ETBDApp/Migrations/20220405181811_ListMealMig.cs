using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETBDApp.Migrations
{
    public partial class ListMealMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_FoodMeals_FoodMealFoodId_FoodMealMealId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_FoodMealFoodId_FoodMealMealId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "FoodMealFoodId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "FoodMealMealId",
                table: "Meals");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FoodMealFoodId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FoodMealMealId",
                table: "Meals",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_FoodMealFoodId_FoodMealMealId",
                table: "Meals",
                columns: new[] { "FoodMealFoodId", "FoodMealMealId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_FoodMeals_FoodMealFoodId_FoodMealMealId",
                table: "Meals",
                columns: new[] { "FoodMealFoodId", "FoodMealMealId" },
                principalTable: "FoodMeals",
                principalColumns: new[] { "FoodId", "MealId" });
        }
    }
}
