using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ASpecialDay.Migrations
{
    public partial class ComplexDataModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WeddingID",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GiftLists",
                columns: table => new
                {
                    InviteCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BrideId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftLists", x => x.InviteCode);
                    table.ForeignKey(
                        name: "FK_GiftLists_AspNetUsers_BrideId",
                        column: x => x.BrideId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weddings",
                columns: table => new
                {
                    WeddingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weddings", x => x.WeddingID);
                });

            migrationBuilder.CreateTable(
                name: "Gifts",
                columns: table => new
                {
                    InviteCode = table.Column<int>(type: "int", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBought = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gifts", x => new { x.InviteCode, x.Position });
                    table.ForeignKey(
                        name: "FK_Gifts_GiftLists_InviteCode",
                        column: x => x.InviteCode,
                        principalTable: "GiftLists",
                        principalColumn: "InviteCode",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Guests",
                columns: table => new
                {
                    GuestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InviteCode = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GiftListInviteCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Guests", x => x.GuestID);
                    table.ForeignKey(
                        name: "FK_Guests_GiftLists_GiftListInviteCode",
                        column: x => x.GiftListInviteCode,
                        principalTable: "GiftLists",
                        principalColumn: "InviteCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoughtBy",
                columns: table => new
                {
                    BoughtByID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GiftInviteCode = table.Column<int>(type: "int", nullable: true),
                    GiftPosition = table.Column<int>(type: "int", nullable: true),
                    GuestID = table.Column<int>(type: "int", nullable: true),
                    GiftListInviteCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoughtBy", x => x.BoughtByID);
                    table.ForeignKey(
                        name: "FK_BoughtBy_GiftLists_GiftListInviteCode",
                        column: x => x.GiftListInviteCode,
                        principalTable: "GiftLists",
                        principalColumn: "InviteCode",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoughtBy_Gifts_GiftInviteCode_GiftPosition",
                        columns: x => new { x.GiftInviteCode, x.GiftPosition },
                        principalTable: "Gifts",
                        principalColumns: new[] { "InviteCode", "Position" },
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoughtBy_Guests_GuestID",
                        column: x => x.GuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GiftGuest",
                columns: table => new
                {
                    GuestsGuestID = table.Column<int>(type: "int", nullable: false),
                    GiftsInviteCode = table.Column<int>(type: "int", nullable: false),
                    GiftsPosition = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GiftGuest", x => new { x.GuestsGuestID, x.GiftsInviteCode, x.GiftsPosition });
                    table.ForeignKey(
                        name: "FK_GiftGuest_Gifts_GiftsInviteCode_GiftsPosition",
                        columns: x => new { x.GiftsInviteCode, x.GiftsPosition },
                        principalTable: "Gifts",
                        principalColumns: new[] { "InviteCode", "Position" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GiftGuest_Guests_GuestsGuestID",
                        column: x => x.GuestsGuestID,
                        principalTable: "Guests",
                        principalColumn: "GuestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoughtBy_GiftInviteCode_GiftPosition",
                table: "BoughtBy",
                columns: new[] { "GiftInviteCode", "GiftPosition" });

            migrationBuilder.CreateIndex(
                name: "IX_BoughtBy_GiftListInviteCode",
                table: "BoughtBy",
                column: "GiftListInviteCode");

            migrationBuilder.CreateIndex(
                name: "IX_BoughtBy_GuestID",
                table: "BoughtBy",
                column: "GuestID");

            migrationBuilder.CreateIndex(
                name: "IX_GiftGuest_GiftsInviteCode_GiftsPosition",
                table: "GiftGuest",
                columns: new[] { "GiftsInviteCode", "GiftsPosition" });

            migrationBuilder.CreateIndex(
                name: "IX_GiftLists_BrideId",
                table: "GiftLists",
                column: "BrideId");

            migrationBuilder.CreateIndex(
                name: "IX_Guests_GiftListInviteCode",
                table: "Guests",
                column: "GiftListInviteCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoughtBy");

            migrationBuilder.DropTable(
                name: "GiftGuest");

            migrationBuilder.DropTable(
                name: "Weddings");

            migrationBuilder.DropTable(
                name: "Gifts");

            migrationBuilder.DropTable(
                name: "Guests");

            migrationBuilder.DropTable(
                name: "GiftLists");

            migrationBuilder.DropColumn(
                name: "WeddingID",
                table: "AspNetUsers");
        }
    }
}
