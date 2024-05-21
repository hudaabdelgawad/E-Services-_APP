using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addnavigationpropuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "ClientRequest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequest_UserId1",
                table: "ClientRequest",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_AspNetUsers_UserId1",
                table: "ClientRequest",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_AspNetUsers_UserId1",
                table: "ClientRequest");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequest_UserId1",
                table: "ClientRequest");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "ClientRequest");
        }
    }
}
