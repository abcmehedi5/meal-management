using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meal_management.Migrations
{
    /// <inheritdoc />
    public partial class addedmarketTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "market",
                columns: table => new
                {
                    marketId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dailyMarket = table.Column<double>(type: "float", nullable: false),
                    dailyMeal = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_market", x => x.marketId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "market");

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
    }
}
