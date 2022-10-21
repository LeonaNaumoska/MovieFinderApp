using Microsoft.EntityFrameworkCore.Migrations;

namespace EMovieFinder.Repository.Migrations
{
    public partial class sixthUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MovieDownloadLink",
                table: "Movie",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieDownloadLink",
                table: "Movie");
        }
    }
}
