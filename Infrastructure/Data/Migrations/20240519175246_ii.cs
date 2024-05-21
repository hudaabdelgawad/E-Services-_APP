using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ii : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientRequestId",
                table: "ServiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "ClientRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 2,
                column: "ClientRequestId",
                value: null);

            migrationBuilder.UpdateData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 3,
                column: "ClientRequestId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_ServiceDetails_ClientRequestId",
                table: "ServiceDetails",
                column: "ClientRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_ServiceDetails_ClientRequest_ClientRequestId",
                table: "ServiceDetails",
                column: "ClientRequestId",
                principalTable: "ClientRequest",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ServiceDetails_ClientRequest_ClientRequestId",
                table: "ServiceDetails");

            migrationBuilder.DropIndex(
                name: "IX_ServiceDetails_ClientRequestId",
                table: "ServiceDetails");

            migrationBuilder.DropColumn(
                name: "ClientRequestId",
                table: "ServiceDetails");
        }
    }
}
