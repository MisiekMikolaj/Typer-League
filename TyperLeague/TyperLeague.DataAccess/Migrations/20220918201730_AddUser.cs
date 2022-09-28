using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyperLeague.DataAccess.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Games");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Bets",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RealResult",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Bets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserPrediction",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Points = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bets_UserId",
                table: "Bets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bets_Users_UserId",
                table: "Bets",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bets_Users_UserId",
                table: "Bets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Bets_UserId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "RealResult",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Bets");

            migrationBuilder.DropColumn(
                name: "UserPrediction",
                table: "Bets");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Games",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
