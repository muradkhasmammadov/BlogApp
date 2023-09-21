using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class writerremoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BLogs_Writers_WriterID",
                table: "BLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_MessageReceiverID",
                table: "Message2s");

            migrationBuilder.DropForeignKey(
                name: "FK_Message2s_Writers_MessageSenderID",
                table: "Message2s");

            migrationBuilder.DropTable(
                name: "Writers");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_MessageReceiverID",
                table: "Message2s");

            migrationBuilder.DropIndex(
                name: "IX_Message2s_MessageSenderID",
                table: "Message2s");

            migrationBuilder.AddColumn<string>(
                name: "UserImage",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_BLogs_AspNetUsers_WriterID",
                table: "BLogs",
                column: "WriterID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BLogs_AspNetUsers_WriterID",
                table: "BLogs");

            migrationBuilder.DropColumn(
                name: "UserImage",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Writers",
                columns: table => new
                {
                    WriterID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WriterAbout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WriterStatus = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Writers", x => x.WriterID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_MessageReceiverID",
                table: "Message2s",
                column: "MessageReceiverID");

            migrationBuilder.CreateIndex(
                name: "IX_Message2s_MessageSenderID",
                table: "Message2s",
                column: "MessageSenderID");

            migrationBuilder.AddForeignKey(
                name: "FK_BLogs_Writers_WriterID",
                table: "BLogs",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_MessageReceiverID",
                table: "Message2s",
                column: "MessageReceiverID",
                principalTable: "Writers",
                principalColumn: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Message2s_Writers_MessageSenderID",
                table: "Message2s",
                column: "MessageSenderID",
                principalTable: "Writers",
                principalColumn: "WriterID");
        }
    }
}
