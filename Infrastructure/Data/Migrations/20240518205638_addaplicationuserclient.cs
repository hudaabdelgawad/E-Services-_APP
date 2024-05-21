using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addaplicationuserclient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ApplicationUserId",
                table: "ClientRequest");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ClientRequest",
                newName: "ClientId");

            migrationBuilder.RenameColumn(
                name: "ApplicationUserId",
                table: "ClientRequest",
                newName: "ClientId1");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRequest_ApplicationUserId",
                table: "ClientRequest",
                newName: "IX_ClientRequest_ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ClientId1",
                table: "ClientRequest",
                column: "ClientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ClientId1",
                table: "ClientRequest");

            migrationBuilder.RenameColumn(
                name: "ClientId1",
                table: "ClientRequest",
                newName: "ApplicationUserId");

            migrationBuilder.RenameColumn(
                name: "ClientId",
                table: "ClientRequest",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_ClientRequest_ClientId1",
                table: "ClientRequest",
                newName: "IX_ClientRequest_ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ApplicationUserId",
                table: "ClientRequest",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
