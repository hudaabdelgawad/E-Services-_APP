using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class addaplicationuserclients : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ClientId1",
                table: "ClientRequest");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequest_ClientId1",
                table: "ClientRequest");

            migrationBuilder.DropColumn(
                name: "ClientId1",
                table: "ClientRequest");

            migrationBuilder.AlterColumn<string>(
                name: "ClientId",
                table: "ClientRequest",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequest_ClientId",
                table: "ClientRequest",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ClientId",
                table: "ClientRequest",
                column: "ClientId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ClientId",
                table: "ClientRequest");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequest_ClientId",
                table: "ClientRequest");

            migrationBuilder.AlterColumn<Guid>(
                name: "ClientId",
                table: "ClientRequest",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ClientId1",
                table: "ClientRequest",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequest_ClientId1",
                table: "ClientRequest",
                column: "ClientId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_AspNetUsers_ClientId1",
                table: "ClientRequest",
                column: "ClientId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
