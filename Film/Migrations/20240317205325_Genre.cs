using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Film.Migrations
{
    /// <inheritdoc />
    public partial class Genre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GenreId",
                table: "movies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    GenreId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.GenreId);
                });

            migrationBuilder.InsertData(
                table: "genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { "A", "Action" },
                    { "c", "Comedy" },
                    { "D", "Drama" },
                    { "H", "Horror" },
                    { "M", "Musical" },
                    { "R", "Romance" },
                    { "S", "Sci-Fi" }
                });

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 1,
                column: "GenreId",
                value: "D");

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 2,
                column: "GenreId",
                value: "D");

            migrationBuilder.UpdateData(
                table: "movies",
                keyColumn: "MovieId",
                keyValue: 3,
                column: "GenreId",
                value: "A");

            migrationBuilder.CreateIndex(
                name: "IX_movies_GenreId",
                table: "movies",
                column: "GenreId");

            migrationBuilder.AddForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies",
                column: "GenreId",
                principalTable: "genres",
                principalColumn: "GenreId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_movies_genres_GenreId",
                table: "movies");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropIndex(
                name: "IX_movies_GenreId",
                table: "movies");

            migrationBuilder.DropColumn(
                name: "GenreId",
                table: "movies");
        }
    }
}
