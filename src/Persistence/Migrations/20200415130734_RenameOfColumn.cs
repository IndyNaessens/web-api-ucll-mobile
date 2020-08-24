using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class RenameOfColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fresh",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "IsFresh",
                table: "Items",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFresh",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "Fresh",
                table: "Items",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }
    }
}
