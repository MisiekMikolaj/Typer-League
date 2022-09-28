using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TyperLeague.DataAccess.Migrations
{
    public partial class ChangeClassCameAndProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lol",
                table: "Matches",
                newName: "Date");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Matches",
                newName: "lol");
        }
    }
}
