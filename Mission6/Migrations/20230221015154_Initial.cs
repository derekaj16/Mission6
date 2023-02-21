using Microsoft.EntityFrameworkCore.Migrations;

namespace Mission06_dprodigy.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CategoryID = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    Year = table.Column<ushort>(nullable: false),
                    DirectorName = table.Column<string>(nullable: false),
                    Rating = table.Column<string>(nullable: false),
                    Edited = table.Column<bool>(nullable: false),
                    LentTo = table.Column<string>(nullable: true),
                    Notes = table.Column<string>(maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_movies_categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 1, "Action/Adventure" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 2, "Comedy" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 3, "Drama" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 4, "Family" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 5, "Horror/Suspense" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 6, "Miscellaneous" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 7, "Television" });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "CategoryID", "CategoryName" },
                values: new object[] { 8, "VHS" });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "CategoryID", "DirectorName", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 1, 1, "Joss Whedon", false, null, null, "PG-13", "The Avengers", (ushort)2012 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "CategoryID", "DirectorName", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 2, 1, "Tim Burton", false, null, null, "PG-13", "Batman", (ushort)1989 });

            migrationBuilder.InsertData(
                table: "movies",
                columns: new[] { "MovieId", "CategoryID", "DirectorName", "Edited", "LentTo", "Notes", "Rating", "Title", "Year" },
                values: new object[] { 3, 1, "Christopher Nolan", false, null, null, "PG-13", "The Dark Knight", (ushort)2008 });

            migrationBuilder.CreateIndex(
                name: "IX_movies_CategoryID",
                table: "movies",
                column: "CategoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "movies");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
