using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Persistence.Migrations
{
    public partial class InitialMigrate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    InviteCode = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => new { x.UserId, x.GroupId });
                    table.ForeignKey(
                        name: "FK_Members_Groups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Groups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Members_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(nullable: false),
                    SendAt = table.Column<DateTime>(nullable: false),
                    MemberUserId = table.Column<int>(nullable: false),
                    MemberGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Messages_Members_MemberUserId_MemberGroupId",
                        columns: x => new { x.MemberUserId, x.MemberGroupId },
                        principalTable: "Members",
                        principalColumns: new[] { "UserId", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingTrips",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    MeansOfTransport = table.Column<string>(nullable: false),
                    MemberUserId = table.Column<int>(nullable: false),
                    MemberGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingTrips", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingTrips_Members_MemberUserId_MemberGroupId",
                        columns: x => new { x.MemberUserId, x.MemberGroupId },
                        principalTable: "Members",
                        principalColumns: new[] { "UserId", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: false),
                    Amount = table.Column<int>(nullable: false),
                    Fresh = table.Column<bool>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: true),
                    ShoppingTripId = table.Column<int>(nullable: false),
                    MemberUserId = table.Column<int>(nullable: false),
                    MemberGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Items_ShoppingTrips_ShoppingTripId",
                        column: x => x.ShoppingTripId,
                        principalTable: "ShoppingTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Members_MemberUserId_MemberGroupId",
                        columns: x => new { x.MemberUserId, x.MemberGroupId },
                        principalTable: "Members",
                        principalColumns: new[] { "UserId", "GroupId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    PlaceId = table.Column<string>(nullable: false),
                    StoreName = table.Column<string>(nullable: false),
                    FormattedAddress = table.Column<string>(nullable: false),
                    Rating = table.Column<double>(nullable: false),
                    ShoppingTripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.PlaceId);
                    table.ForeignKey(
                        name: "FK_Locations_ShoppingTrips_ShoppingTripId",
                        column: x => x.ShoppingTripId,
                        principalTable: "ShoppingTrips",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groups_InviteCode",
                table: "Groups",
                column: "InviteCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ShoppingTripId",
                table: "Items",
                column: "ShoppingTripId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_MemberUserId_MemberGroupId",
                table: "Items",
                columns: new[] { "MemberUserId", "MemberGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_ShoppingTripId",
                table: "Locations",
                column: "ShoppingTripId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Members_GroupId",
                table: "Members",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_MemberUserId_MemberGroupId",
                table: "Messages",
                columns: new[] { "MemberUserId", "MemberGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingTrips_MemberUserId_MemberGroupId",
                table: "ShoppingTrips",
                columns: new[] { "MemberUserId", "MemberGroupId" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName_Email",
                table: "Users",
                columns: new[] { "UserName", "Email" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "ShoppingTrips");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Groups");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
