using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ETBDApp.Migrations
{
    public partial class DataBaseFinalMig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMeals_PortionTypes_PortionTypeId",
                table: "FoodMeals");

            migrationBuilder.RenameColumn(
                name: "PortionTypeId",
                table: "FoodMeals",
                newName: "PortionTypesId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodMeals_PortionTypeId",
                table: "FoodMeals",
                newName: "IX_FoodMeals_PortionTypesId");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Meals",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Weight = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Height = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Age = table.Column<int>(type: "int", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlackLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlackLists_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BlackLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FavouriteLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FavouriteLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FavouriteLists_Foods_FoodId",
                        column: x => x.FoodId,
                        principalTable: "Foods",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FavouriteLists_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Meals_UserId1",
                table: "Meals",
                column: "UserId1");

            migrationBuilder.CreateIndex(
                name: "IX_BlackLists_FoodId",
                table: "BlackLists",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_BlackLists_UserId",
                table: "BlackLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteLists_FoodId",
                table: "FavouriteLists",
                column: "FoodId");

            migrationBuilder.CreateIndex(
                name: "IX_FavouriteLists_UserId",
                table: "FavouriteLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMeals_PortionTypes_PortionTypesId",
                table: "FoodMeals",
                column: "PortionTypesId",
                principalTable: "PortionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Meals_Users_UserId1",
                table: "Meals",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodMeals_PortionTypes_PortionTypesId",
                table: "FoodMeals");

            migrationBuilder.DropForeignKey(
                name: "FK_Meals_Users_UserId1",
                table: "Meals");

            migrationBuilder.DropTable(
                name: "BlackLists");

            migrationBuilder.DropTable(
                name: "FavouriteLists");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Meals_UserId1",
                table: "Meals");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Meals");

            migrationBuilder.RenameColumn(
                name: "PortionTypesId",
                table: "FoodMeals",
                newName: "PortionTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_FoodMeals_PortionTypesId",
                table: "FoodMeals",
                newName: "IX_FoodMeals_PortionTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodMeals_PortionTypes_PortionTypeId",
                table: "FoodMeals",
                column: "PortionTypeId",
                principalTable: "PortionTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
