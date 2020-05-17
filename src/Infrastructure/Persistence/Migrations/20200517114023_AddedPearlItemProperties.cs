using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PearlsOfWisdom.Infrastructure.Persistence.Migrations
{
    public partial class AddedPearlItemProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reminder",
                table: "PearlItems");

            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "PearlItems",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Transcription",
                table: "PearlItems",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "KeyPoints",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    Created = table.Column<DateTime>(nullable: false),
                    LastModifiedBy = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    PearlItemId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeyPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeyPoints_PearlItems_PearlItemId",
                        column: x => x.PearlItemId,
                        principalTable: "PearlItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KeyPoints_PearlItemId",
                table: "KeyPoints",
                column: "PearlItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KeyPoints");

            migrationBuilder.DropColumn(
                name: "Author",
                table: "PearlItems");

            migrationBuilder.DropColumn(
                name: "Transcription",
                table: "PearlItems");

            migrationBuilder.AddColumn<DateTime>(
                name: "Reminder",
                table: "PearlItems",
                type: "timestamp without time zone",
                nullable: true);
        }
    }
}
