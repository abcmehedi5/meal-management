using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace meal_management.Migrations
{
    /// <inheritdoc />
    public partial class removetablecolomn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Refund",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "due",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "mealRate",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "totalCost",
                table: "meals");

            migrationBuilder.DropColumn(
                name: "totalMeal",
                table: "meals");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "meals",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "diposit",
                table: "meals",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "meals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "meals",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "diposit",
                table: "meals",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "Refund",
                table: "meals",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "due",
                table: "meals",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "mealRate",
                table: "meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "totalCost",
                table: "meals",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "totalMeal",
                table: "meals",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
