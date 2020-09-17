using Microsoft.EntityFrameworkCore.Migrations;

namespace BingeAPI.Migrations
{
    public partial class ChangedSizeofStringColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieName",
                table: "Movie",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movie",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MovieName",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Movie",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");
        }
    }
}
