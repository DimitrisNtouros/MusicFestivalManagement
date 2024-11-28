using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicFestivalManagement.Migrations
{
    /// <inheritdoc />
    public partial class RenamingTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performances_Festivals_FestivalId",
                table: "Performances");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Festivals_FestivalId",
                table: "Roles");

            migrationBuilder.DropForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Roles",
                table: "Roles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Performances",
                table: "Performances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Festivals",
                table: "Festivals");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Roles",
                newName: "Role");

            migrationBuilder.RenameTable(
                name: "Performances",
                newName: "Performance");

            migrationBuilder.RenameTable(
                name: "Festivals",
                newName: "Festival");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_UserId",
                table: "Role",
                newName: "IX_Role_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Roles_FestivalId",
                table: "Role",
                newName: "IX_Role_FestivalId");

            migrationBuilder.RenameIndex(
                name: "IX_Performances_FestivalId",
                table: "Performance",
                newName: "IX_Performance_FestivalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Role",
                table: "Role",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Performance",
                table: "Performance",
                column: "PerformanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Festival",
                table: "Festival",
                column: "FestivalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Festival_FestivalId",
                table: "Performance",
                column: "FestivalId",
                principalTable: "Festival",
                principalColumn: "FestivalId",
                onDelete: ReferentialAction.Cascade);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Festival_FestivalId",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_Festival_FestivalId",
                table: "Role");

            migrationBuilder.DropForeignKey(
                name: "FK_Role_User_UserId",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Role",
                table: "Role");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Performance",
                table: "Performance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Festival",
                table: "Festival");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Role",
                newName: "Roles");

            migrationBuilder.RenameTable(
                name: "Performance",
                newName: "Performances");

            migrationBuilder.RenameTable(
                name: "Festival",
                newName: "Festivals");

            migrationBuilder.RenameIndex(
                name: "IX_Role_UserId",
                table: "Roles",
                newName: "IX_Roles_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Role_FestivalId",
                table: "Roles",
                newName: "IX_Roles_FestivalId");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_FestivalId",
                table: "Performances",
                newName: "IX_Performances_FestivalId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Roles",
                table: "Roles",
                column: "RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Performances",
                table: "Performances",
                column: "PerformanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Festivals",
                table: "Festivals",
                column: "FestivalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performances_Festivals_FestivalId",
                table: "Performances",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "FestivalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Festivals_FestivalId",
                table: "Roles",
                column: "FestivalId",
                principalTable: "Festivals",
                principalColumn: "FestivalId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_Users_UserId",
                table: "Roles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
