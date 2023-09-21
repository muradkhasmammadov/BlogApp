using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "BLogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BLogs_CategoryID",
                table: "BLogs",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_BLogs_Categories_CategoryID",
                table: "BLogs",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BLogs_Categories_CategoryID",
                table: "BLogs");

            migrationBuilder.DropIndex(
                name: "IX_BLogs_CategoryID",
                table: "BLogs");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "BLogs");
        }
    }
}
