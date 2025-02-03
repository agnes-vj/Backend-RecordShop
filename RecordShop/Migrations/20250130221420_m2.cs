using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecordShop.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MusicGenre",
                table: "Albums",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "About", "Name" },
                values: new object[,]
                {
                    { 1, "Legendary British rock band.", "The Beatles" },
                    { 2, "Award-winning pop and country music artist.", "Taylor Swift" },
                    { 3, "Known as the King of Pop, Michael Jackson was a global icon and music legend.", "Michael Jackson" }
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "MusicGenre", "ReleaseYear", "Stock", "Title" },
                values: new object[,]
                {
                    { 1, 1, "ROCK", 1969, 10, "Abbey Road" },
                    { 2, 1, "ROCK", 1970, 40, "Let It Be" },
                    { 3, 2, "POP", 2014, 15, "1989" },
                    { 4, 3, "POP", 1982, 10, "Thriller" },
                    { 5, 2, "COUNTRY", 2008, 55, "Fearless" },
                    { 6, 2, "CLASSICAL", 2020, 75, "Folklore" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Albums",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Artists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<int>(
                name: "MusicGenre",
                table: "Albums",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
