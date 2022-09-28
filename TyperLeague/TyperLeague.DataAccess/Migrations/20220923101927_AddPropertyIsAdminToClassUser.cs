using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyperLeague.DataAccess.Migrations
{
    public partial class AddPropertyIsAdminToClassUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameTeam_Games_GamesId",
                table: "GameTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTeam_Teams_TeamsId",
                table: "GameTeam");

            migrationBuilder.RenameColumn(
                name: "TeamsId",
                table: "GameTeam",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "GamesId",
                table: "GameTeam",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_GameTeam_TeamsId",
                table: "GameTeam",
                newName: "IX_GameTeam_TeamId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "Users",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "UserPrediction",
                table: "Bets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "RealResult",
                table: "Bets",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_GameTeam_Games_GameId",
                table: "GameTeam",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTeam_Teams_TeamId",
                table: "GameTeam",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GameTeam_Games_GameId",
                table: "GameTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_GameTeam_Teams_TeamId",
                table: "GameTeam");

            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "Users");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "GameTeam",
                newName: "TeamsId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "GameTeam",
                newName: "GamesId");

            migrationBuilder.RenameIndex(
                name: "IX_GameTeam_TeamId",
                table: "GameTeam",
                newName: "IX_GameTeam_TeamsId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "UserPrediction",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "RealResult",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Bets",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTeam_Games_GamesId",
                table: "GameTeam",
                column: "GamesId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GameTeam_Teams_TeamsId",
                table: "GameTeam",
                column: "TeamsId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
