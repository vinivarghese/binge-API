using Microsoft.EntityFrameworkCore.Migrations;

namespace BingeAPI.Migrations
{
    public partial class RemovedMovieForeignKeyFromFavourites : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Favourites_FavouritesId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_FavouritesId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "FavouritesId",
                table: "Movie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FavouritesId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FavouritesId",
                table: "Movie",
                column: "FavouritesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Favourites_FavouritesId",
                table: "Movie",
                column: "FavouritesId",
                principalTable: "Favourites",
                principalColumn: "FavouritesId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
