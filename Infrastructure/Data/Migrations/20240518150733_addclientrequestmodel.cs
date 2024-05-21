using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addclientrequestmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_AspNetUsers_UserId1",
                table: "ClientRequest");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "ClientRequest",
                newName: "ApplicationUserId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRequest_UserId1",
                table: "ClientRequest",
                newName: "IX_ClientRequest_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ApplicationUserId",
                table: "ClientRequest",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ApplicationUserId",
                table: "ClientRequest");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ClientRequest",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRequest_ApplicationUserId",
                table: "ClientRequest",
                newName: "IX_ClientRequest_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_AspNetUsers_UserId1",
                table: "ClientRequest",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
