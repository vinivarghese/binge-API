using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BingeAPI.Migrations
{
    public partial class AddedFavouritesModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Genre_GenreId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_GenreId",
                table: "Movie");

            migrationBuilder.AddColumn<int>(
                name: "FavouritesId",
                table: "Movie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Movie",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Genre",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Favourites",
                columns: table => new
                {
                    FavouritesId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Favourites", x => x.FavouritesId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movie_FavouritesId",
                table: "Movie",
                column: "FavouritesId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_MovieId",
                table: "Genre",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Genre_Movie_MovieId",
                table: "Genre",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "MovieId",
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_Genre_Movie_MovieId",
                table: "Genre");

            migrationBuilder.DropForeignKey(
                name: "FK_Movie_Favourites_FavouritesId",
                table: "Movie");

            migrationBuilder.DropTable(
                name: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Movie_FavouritesId",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Genre_MovieId",
                table: "Genre");

            migrationBuilder.DropColumn(
                name: "FavouritesId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Genre");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_GenreId",
                table: "Movie",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_Genre_GenreId",
                table: "Movie",
                column: "GenreId",
                principalTable: "Genre",
                principalColumn: "GenreID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
