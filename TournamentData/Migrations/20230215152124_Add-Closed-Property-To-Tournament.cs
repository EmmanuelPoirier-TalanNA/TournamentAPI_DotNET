using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TournamentData.Migrations
{
    /// <inheritdoc />
    public partial class AddClosedPropertyToTournament : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Closed",
                table: "Tournaments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Closed",
                table: "Tournaments");
        }
    }
}
