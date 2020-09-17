using Microsoft.EntityFrameworkCore.Migrations;

namespace BingeAPI.Migrations
{
    public partial class RemovedGenreId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GenreId",
                table: "Movie",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
