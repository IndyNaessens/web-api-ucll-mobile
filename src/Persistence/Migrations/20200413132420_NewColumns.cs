using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class NewColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MeansOfTransport",
                table: "ShoppingTrips");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ShoppingTrips",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "ShoppingTrips",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Transportation",
                table: "ShoppingTrips",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ShoppingTrips");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "ShoppingTrips");

            migrationBuilder.DropColumn(
                name: "Transportation",
                table: "ShoppingTrips");

            migrationBuilder.AddColumn<string>(
                name: "MeansOfTransport",
                table: "ShoppingTrips",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
