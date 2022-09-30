using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyperLeague.DataAccess.Migrations
{
    public partial class _2XOneToManyRelationBetwweenGameAndTeam : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameTeam");

            migrationBuilder.AddColumn<int>(
                name: "FirstTeamId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecondTeamId",
                table: "Games",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Games_FirstTeamId",
                table: "Games",
                column: "FirstTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SecondTeamId",
                table: "Games",
                column: "SecondTeamId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_FirstTeamId",
                table: "Games",
                column: "FirstTeamId",
                principalTable: "Teams",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Teams_SecondTeamId",
                table: "Games",
                column: "SecondTeamId",
                principalTable: "Teams",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_FirstTeamId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Games_Teams_SecondTeamId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_FirstTeamId",
                table: "Games");

            migrationBuilder.DropIndex(
                name: "IX_Games_SecondTeamId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "FirstTeamId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "SecondTeamId",
                table: "Games");

            migrationBuilder.CreateTable(
                name: "GameTeam",
                columns: table => new
                {
                    GameId = table.Column<int>(type: "int", nullable: false),
                    TeamId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameTeam", x => new { x.GameId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_GameTeam_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GameTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GameTeam_TeamId",
                table: "GameTeam",
                column: "TeamId");
        }
    }
}
