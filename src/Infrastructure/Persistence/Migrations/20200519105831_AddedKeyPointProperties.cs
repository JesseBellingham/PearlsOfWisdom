using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PearlsOfWisdom.Infrastructure.Persistence.Migrations
{
    public partial class AddedKeyPointProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyPoints_PearlItems_PearlItemId",
                table: "KeyPoints");

            migrationBuilder.AlterColumn<Guid>(
                name: "PearlItemId",
                table: "KeyPoints",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KeyPoints_PearlItems_PearlItemId",
                table: "KeyPoints",
                column: "PearlItemId",
                principalTable: "PearlItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KeyPoints_PearlItems_PearlItemId",
                table: "KeyPoints");

            migrationBuilder.AlterColumn<Guid>(
                name: "PearlItemId",
                table: "KeyPoints",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_KeyPoints_PearlItems_PearlItemId",
                table: "KeyPoints",
                column: "PearlItemId",
                principalTable: "PearlItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
