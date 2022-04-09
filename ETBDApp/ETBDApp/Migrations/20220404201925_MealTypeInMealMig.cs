using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETBDApp.Migrations
{
    public partial class MealTypeInMealMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MealTypeId",
                table: "Meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals",
                column: "MealTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_MealTypes_MealTypeId",
                table: "Meals",
                column: "MealTypeId",
                principalTable: "MealTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Meals_MealTypes_MealTypeId",
                table: "Meals");

            migrationBuilder.DropIndex(
                name: "IX_Meals_MealTypeId",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "MealTypeId",
                table: "Meals");
        }
    }
}
