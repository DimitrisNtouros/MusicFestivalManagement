using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicFestivalManagement.Migrations
{
    /// <inheritdoc />
    public partial class RefactoringPerformancetableandaddingArtist : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MerchandiseItems",
                table: "Performance",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferredPerformanceSlots",
                table: "Performance",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PreferredRehearsalTimes",
                table: "Performance",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Setlist",
                table: "Performance",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TechnicalRequirements",
                table: "Performance",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Artist",
                columns: table => new
                {
                    ArtistId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Role = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PerformanceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artist", x => x.ArtistId);
                    table.ForeignKey(
                        name: "FK_Artist_Performance_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Performance",
                        principalColumn: "PerformanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artist_PerformanceId",
                table: "Artist",
                column: "PerformanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artist");

            migrationBuilder.DropColumn(
                name: "MerchandiseItems",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "PreferredPerformanceSlots",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "PreferredRehearsalTimes",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "Setlist",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "TechnicalRequirements",
                table: "Performance");
        }
    }
}
