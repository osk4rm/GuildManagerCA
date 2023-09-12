using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GuildManagerCA.Infrastructure.Migrations
{
    public partial class initialwithraidevents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RaidEvents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaidLocationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    StartDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AutoAccept = table.Column<bool>(type: "bit", nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Difficulty = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaidEvents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RaidLocations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpansionName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ExpansionImageUrl = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaidLocations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaidEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Author = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => new { x.CommentId, x.RaidEventId });
                    table.ForeignKey(
                        name: "FK_Comments_RaidEvents_RaidEventId",
                        column: x => x.RaidEventId,
                        principalTable: "RaidEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RaidEventAttendances",
                columns: table => new
                {
                    RaidEventAttendanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RaidEventId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CharacterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AcceptanceStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RaidEventAttendances", x => new { x.RaidEventAttendanceId, x.RaidEventId });
                    table.ForeignKey(
                        name: "FK_RaidEventAttendances_RaidEvents_RaidEventId",
                        column: x => x.RaidEventId,
                        principalTable: "RaidEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_RaidEventId",
                table: "Comments",
                column: "RaidEventId");

            migrationBuilder.CreateIndex(
                name: "IX_RaidEventAttendances_RaidEventId",
                table: "RaidEventAttendances",
                column: "RaidEventId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "RaidEventAttendances");

            migrationBuilder.DropTable(
                name: "RaidLocations");

            migrationBuilder.DropTable(
                name: "RaidEvents");
        }
    }
}
