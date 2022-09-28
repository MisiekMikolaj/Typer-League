using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyperLeague.DataAccess.Migrations
{
    public partial class ValidationInGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Matches",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Matches");

            migrationBuilder.RenameTable(
                name: "Matches",
                newName: "Games");

            migrationBuilder.RenameColumn(
                name: "Result12",
                table: "Games",
                newName: "Result");

            migrationBuilder.AlterColumn<string>(
                name: "Team2",
                table: "Games",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Team1",
                table: "Games",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "Deadline",
                table: "Games",
                type: "datetime2",
                maxLength: 50,
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Games",
                table: "Games",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Games",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "Deadline",
                table: "Games");

            migrationBuilder.RenameTable(
                name: "Games",
                newName: "Matches");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "Matches",
                newName: "Result12");

            migrationBuilder.AlterColumn<string>(
                name: "Team2",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Team1",
                table: "Matches",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Matches",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Matches",
                table: "Matches",
                column: "Id");
        }
    }
}
