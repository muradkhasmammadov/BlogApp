using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class user_updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_AppUserId",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_AspNetUsers_AppUserId1",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_AppUserId",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_AppUserId1",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Message2s");

            migrationBuilder.DropColumn(
                name: "AppUserId1",
                table: "Message2s");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Message2s",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AppUserId1",
                table: "Message2s",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_AppUserId",
                table: "Message2s",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_AppUserId1",
                table: "Message2s",
                column: "AppUserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_AspNetUsers_AppUserId",
                table: "Message2s",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_AspNetUsers_AppUserId1",
                table: "Message2s",
                column: "AppUserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
