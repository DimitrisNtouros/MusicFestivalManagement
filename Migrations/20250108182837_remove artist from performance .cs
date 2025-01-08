using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicFestivalManagement.Migrations
{
    /// <inheritdoc />
    public partial class removeartistfromperformance : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Performance",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Performance_UserId",
                table: "Performance",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_User_UserId",
                table: "Performance",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_User_UserId",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Performance_UserId",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Performance");
        }
    }
}
