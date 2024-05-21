using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class adddetailrequest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ServiceDetails",
                table: "ClientRequest",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestDate",
                table: "ClientRequest",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ServiceDetailsId",
                table: "ClientRequest",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ClientRequest_ServiceDetailsId",
                table: "ClientRequest",
                column: "ServiceDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientRequest_ServiceDetails_ServiceDetailsId",
                table: "ClientRequest",
                column: "ServiceDetailsId",
                principalTable: "ServiceDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientRequest_ServiceDetails_ServiceDetailsId",
                table: "ClientRequest");

            migrationBuilder.DropIndex(
                name: "IX_ClientRequest_ServiceDetailsId",
                table: "ClientRequest");

            migrationBuilder.DropColumn(
                name: "RequestDate",
                table: "ClientRequest");

            migrationBuilder.DropColumn(
                name: "ServiceDetailsId",
                table: "ClientRequest");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ClientRequest",
                newName: "ServiceDetails");
        }
    }
}
