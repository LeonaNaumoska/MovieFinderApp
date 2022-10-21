using Microsoft.EntityFrameworkCore.Migrations;

namespace EMovieFinder.Repository.Migrations
{
    public partial class forthUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembershipType",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MovieUserId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_MovieUserId",
                table: "AspNetUsers",
                column: "MovieUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_MovieUserId",
                table: "AspNetUsers",
                column: "MovieUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_AspNetUsers_MovieUserId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_MovieUserId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MembershipType",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MovieUserId",
                table: "AspNetUsers");
        }
    }
}
