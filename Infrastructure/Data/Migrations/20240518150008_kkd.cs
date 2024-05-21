using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class kkd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ApplicationUserId",
                table: "ClientRequest");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequest_ApplicationUserId",
                table: "ClientRequest");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "ClientRequest");

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "ClientRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "ClientRequest");

            migrationBuilder.AddColumn<string>(
                name: "ApplicationUserId",
                table: "ClientRequest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequest_ApplicationUserId",
                table: "ClientRequest",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ApplicationUserId",
                table: "ClientRequest",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
