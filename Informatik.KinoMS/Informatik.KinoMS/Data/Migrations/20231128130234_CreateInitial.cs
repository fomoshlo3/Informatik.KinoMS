using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Informatik.KinoMS.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Halls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatsCount = table.Column<int>(type: "int", nullable: false),
                    ScreeningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Halls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PCA = table.Column<int>(type: "int", nullable: false),
                    PublishedDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Length = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Screenings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    EndTime = table.Column<TimeOnly>(type: "time", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    HallId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Screenings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Screenings_Halls_HallId",
                        column: x => x.HallId,
                        principalTable: "Halls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Screenings_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ScreeningId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Screenings_ScreeningId",
                        column: x => x.ScreeningId,
                        principalTable: "Screenings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Halls",
                columns: new[] { "Id", "ScreeningId", "SeatsCount" },
                values: new object[,]
                {
                    { 1, 0, 340 },
                    { 2, 0, 280 },
                    { 3, 0, 280 },
                    { 4, 0, 180 },
                    { 5, 0, 340 },
                    { 6, 0, 180 }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Length", "PCA", "PublishedDate", "Title" },
                values: new object[,]
                {
                    { 1, "Richtig Lahmer Method-Acting Film", new TimeSpan(0, 1, 30, 0, 0), 12, "1975", "Einer flog über das Kuckucksnest" },
                    { 2, "Bewegendes Drama über den Holocaust", new TimeSpan(0, 3, 15, 0, 0), 16, "1993", "Schindlers Liste" },
                    { 3, "Verwirrend genialer Science-Fiction-Thriller", new TimeSpan(0, 2, 28, 0, 0), 16, "2010", "Inception" },
                    { 4, "Bewegendes Drama über den Holocaust", new TimeSpan(0, 3, 15, 0, 0), 16, "1993", "Schindlers Liste" },
                    { 5, "Ein Klassiker des Mafiafilms", new TimeSpan(0, 2, 55, 0, 0), 18, "1972", "Der Pate" },
                    { 6, "Epische Reise eines einfachen Mannes", new TimeSpan(0, 2, 22, 0, 0), 12, "1994", "Forrest Gump" },
                    { 7, "Epos über die Reise eines Hobbits", new TimeSpan(0, 2, 58, 0, 0), 12, "2001", "Der Herr der Ringe: Die Gefährten" }
                });

            migrationBuilder.InsertData(
                table: "Screenings",
                columns: new[] { "Id", "Date", "EndTime", "HallId", "MovieId", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 1, 1, new TimeOnly(15, 0, 0) },
                    { 2, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 2, 2, new TimeOnly(15, 0, 0) },
                    { 3, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 3, 3, new TimeOnly(15, 0, 0) },
                    { 4, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 4, 4, new TimeOnly(15, 0, 0) },
                    { 5, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 5, 5, new TimeOnly(15, 0, 0) },
                    { 6, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 1, 6, new TimeOnly(19, 0, 0) },
                    { 7, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 2, 7, new TimeOnly(19, 0, 0) },
                    { 8, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 3, 7, new TimeOnly(19, 0, 0) },
                    { 9, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 4, 7, new TimeOnly(19, 0, 0) },
                    { 10, new DateOnly(2023, 11, 28), new TimeOnly(0, 0, 0), 5, 7, new TimeOnly(19, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ScreeningId",
                table: "Bookings",
                column: "ScreeningId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_HallId",
                table: "Screenings",
                column: "HallId");

            migrationBuilder.CreateIndex(
                name: "IX_Screenings_MovieId",
                table: "Screenings",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Screenings");

            migrationBuilder.DropTable(
                name: "Halls");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
