using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meal_management.Migrations
{
    /// <inheritdoc />
    public partial class initialmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    meal = table.Column<int>(type: "int", nullable: false),
                    diposit = table.Column<int>(type: "int", nullable: true),
                    due = table.Column<int>(type: "int", nullable: true),
                    totalMeal = table.Column<int>(type: "int", nullable: false),
                    Refund = table.Column<int>(type: "int", nullable: false),
                    totalCost = table.Column<double>(type: "float", nullable: false),
                    mealRate = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "meals");
        }
    }
}
