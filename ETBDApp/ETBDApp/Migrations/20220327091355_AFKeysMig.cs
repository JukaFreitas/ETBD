using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETBDApp.Migrations
{
    public partial class AFKeysMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionFoods_Actions_ActionId",
                table: "ActionFoods");

            migrationBuilder.DropForeignKey(
                name: "FK_ActionFoods_Foods_FoodId",
                table: "ActionFoods");

            migrationBuilder.DropIndex(
                name: "IX_ActionFoods_FoodId",
                table: "ActionFoods");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ActionFoods_FoodId",
                table: "ActionFoods",
                column: "FoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_ActionFoods_Actions_ActionId",
                table: "ActionFoods",
                column: "ActionId",
                principalTable: "Actions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActionFoods_Foods_FoodId",
                table: "ActionFoods",
                column: "FoodId",
                principalTable: "Foods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
