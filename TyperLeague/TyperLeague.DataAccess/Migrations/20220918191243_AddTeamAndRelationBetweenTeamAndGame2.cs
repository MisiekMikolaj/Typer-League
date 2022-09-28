using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyperLeague.DataAccess.Migrations
{
    public partial class AddTeamAndRelationBetweenTeamAndGame2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Games_GameId1",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "GameId1",
                table: "Team",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Team_GameId1",
                table: "Team",
                newName: "IX_Team_GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Games_GameId",
                table: "Team",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_Games_GameId",
                table: "Team");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Team",
                newName: "GameId1");

            migrationBuilder.RenameIndex(
                name: "IX_Team_GameId",
                table: "Team",
                newName: "IX_Team_GameId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_Games_GameId1",
                table: "Team",
                column: "GameId1",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
