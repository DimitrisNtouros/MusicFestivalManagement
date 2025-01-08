using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicFestivalManagement.Migrations
{
    /// <inheritdoc />
    public partial class fixingdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Role_Festival_FestivalId",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_FestivalId",
                table: "Role");

            migrationBuilder.DropIndex(
                name: "IX_Role_UserId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.DropColumn(
                name: "FestivalId",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "RoleType",
                table: "Role");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Role");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Role",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    FestivalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.UserRoleId);
                    table.ForeignKey(
                        name: "FK_UserRole_Festival_FestivalId",
                        column: x => x.FestivalId,
                        principalTable: "Festival",
                        principalColumn: "FestivalId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_FestivalId",
                table: "UserRole",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId_FestivalId",
                table: "UserRole",
                columns: new[] { "UserId", "FestivalId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Role");

            migrationBuilder.AddColumn<int>(
                name: "Role",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FestivalId",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RoleType",
                table: "Role",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Role",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Role_FestivalId",
                table: "Role",
                column: "FestivalId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_UserId",
                table: "Role",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Role_Festival_FestivalId",
                table: "Role",
                column: "FestivalId",
                principalTable: "Festival",
                principalColumn: "FestivalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Role_User_UserId",
                table: "Role",
                column: "UserId",
                principalTable: "User",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
