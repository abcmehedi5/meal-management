using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meal_management.Migrations
{
    /// <inheritdoc />
    public partial class addedmarketTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_meals",
                table: "meals");

            migrationBuilder.RenameTable(
                name: "meals",
                newName: "MealManageModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealManageModel",
                table: "MealManageModel",
                column: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_MealManageModel",
                table: "MealManageModel");

            migrationBuilder.RenameTable(
                name: "MealManageModel",
                newName: "meals");

            migrationBuilder.AddPrimaryKey(
                name: "PK_meals",
                table: "meals",
                column: "id");
        }
    }
}
