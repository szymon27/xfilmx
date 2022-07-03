using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace xfilmx.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Celebrities",
                columns: table => new
                {
                    CelebritieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celebrities", x => x.CelebritieId);
                });

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    CountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Productions",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsSerie = table.Column<bool>(type: "bit", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    BeginDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productions", x => x.ProductionId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "ProductionActors",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    CelebritieId = table.Column<int>(type: "int", nullable: false),
                    Character = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionActors", x => new { x.ProductionId, x.CelebritieId });
                    table.ForeignKey(
                        name: "FK_ProductionActors_Celebrities_CelebritieId",
                        column: x => x.CelebritieId,
                        principalTable: "Celebrities",
                        principalColumn: "CelebritieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionActors_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionCountries",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    CountryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionCountries", x => new { x.ProductionId, x.CountryId });
                    table.ForeignKey(
                        name: "FK_ProductionCountries_Countries_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Countries",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionCountries_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionDirectors",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    CelebritieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionDirectors", x => new { x.ProductionId, x.CelebritieId });
                    table.ForeignKey(
                        name: "FK_ProductionDirectors_Celebrities_CelebritieId",
                        column: x => x.CelebritieId,
                        principalTable: "Celebrities",
                        principalColumn: "CelebritieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionDirectors_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionEpisods",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    Season = table.Column<int>(type: "int", nullable: false),
                    Episod = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionEpisods", x => new { x.ProductionId, x.Season, x.Episod });
                    table.ForeignKey(
                        name: "FK_ProductionEpisods_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionGenres",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionGenres", x => new { x.ProductionId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_ProductionGenres_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionGenres_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionPictures",
                columns: table => new
                {
                    ProductionPictureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionPictures", x => x.ProductionPictureId);
                    table.ForeignKey(
                        name: "FK_ProductionPictures_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionScreenwriters",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    CelebritieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionScreenwriters", x => new { x.ProductionId, x.CelebritieId });
                    table.ForeignKey(
                        name: "FK_ProductionScreenwriters_Celebrities_CelebritieId",
                        column: x => x.CelebritieId,
                        principalTable: "Celebrities",
                        principalColumn: "CelebritieId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionScreenwriters_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionTrailers",
                columns: table => new
                {
                    ProductionTrailerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionTrailers", x => x.ProductionTrailerId);
                    table.ForeignKey(
                        name: "FK_ProductionTrailers_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    NewsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.NewsId);
                    table.ForeignKey(
                        name: "FK_News_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionComments",
                columns: table => new
                {
                    ProductionCommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionComments", x => x.ProductionCommentId);
                    table.ForeignKey(
                        name: "FK_ProductionComments_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionComments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionRates",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionRates", x => new { x.ProductionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProductionRates_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionRates_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductionWatchStatuses",
                columns: table => new
                {
                    ProductionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    WatchStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionWatchStatuses", x => new { x.ProductionId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ProductionWatchStatuses_Productions_ProductionId",
                        column: x => x.ProductionId,
                        principalTable: "Productions",
                        principalColumn: "ProductionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductionWatchStatuses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_News_UserId",
                table: "News",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionActors_CelebritieId",
                table: "ProductionActors",
                column: "CelebritieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionComments_ProductionId",
                table: "ProductionComments",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionComments_UserId",
                table: "ProductionComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionCountries_CountryId",
                table: "ProductionCountries",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionDirectors_CelebritieId",
                table: "ProductionDirectors",
                column: "CelebritieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionGenres_GenreId",
                table: "ProductionGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionPictures_ProductionId",
                table: "ProductionPictures",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionRates_UserId",
                table: "ProductionRates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionScreenwriters_CelebritieId",
                table: "ProductionScreenwriters",
                column: "CelebritieId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionTrailers_ProductionId",
                table: "ProductionTrailers",
                column: "ProductionId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductionWatchStatuses_UserId",
                table: "ProductionWatchStatuses",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "ProductionActors");

            migrationBuilder.DropTable(
                name: "ProductionComments");

            migrationBuilder.DropTable(
                name: "ProductionCountries");

            migrationBuilder.DropTable(
                name: "ProductionDirectors");

            migrationBuilder.DropTable(
                name: "ProductionEpisods");

            migrationBuilder.DropTable(
                name: "ProductionGenres");

            migrationBuilder.DropTable(
                name: "ProductionPictures");

            migrationBuilder.DropTable(
                name: "ProductionRates");

            migrationBuilder.DropTable(
                name: "ProductionScreenwriters");

            migrationBuilder.DropTable(
                name: "ProductionTrailers");

            migrationBuilder.DropTable(
                name: "ProductionWatchStatuses");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Celebrities");

            migrationBuilder.DropTable(
                name: "Productions");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
