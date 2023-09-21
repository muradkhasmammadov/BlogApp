using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class writerandblogrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterID",
                table: "BLogs",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BLogs_WriterID",
                table: "BLogs",
                column: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_BLogs_Writers_WriterID",
                table: "BLogs",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BLogs_Writers_WriterID",
                table: "BLogs");

            migrationBuilder.DropIndex(
                name: "IX_BLogs_WriterID",
                table: "BLogs");

            migrationBuilder.DropColumn(
                name: "WriterID",
                table: "BLogs");
        }
    }
}
