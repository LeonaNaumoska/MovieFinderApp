using Microsoft.EntityFrameworkCore.Migrations;

namespace EMovieFinder.Repository.Migrations
{
    public partial class secondUpdateModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MovieDescription",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MoviePrice",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "MovieInDownloads",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MovieCategory",
                table: "Movie",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "MovieInDownloads");

            migrationBuilder.DropColumn(
                name: "MovieCategory",
                table: "Movie");

            migrationBuilder.AddColumn<string>(
                name: "MovieDescription",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MoviePrice",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
