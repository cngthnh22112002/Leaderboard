using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Leaderboard.Migrations
{
    /// <inheritdoc />
    public partial class RefactorUserPlay : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rank",
                table: "UserPlays");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rank",
                table: "UserPlays",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
