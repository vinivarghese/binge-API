using Microsoft.EntityFrameworkCore.Migrations;

namespace BingeAPI.Migrations
{
    public partial class UpdatedFavouritesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Movie_MovieId",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_MovieId",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Favourites");

            migrationBuilder.AddColumn<int>(
                name: "FavouritesId",
                table: "Movie",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Favourites",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_MovieId",
                table: "Favourites",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Movie_MovieId",
                table: "Favourites",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
