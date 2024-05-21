using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class seeddata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "Gender",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.UpdateData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 1,
                column: "ServiceFeatures",
                value: "تسجيل قراءه عداد");

            migrationBuilder.UpdateData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ServiceFeatures", "ServiceId" },
                values: new object[] { "دفع الفواتير  ", 1 });

            migrationBuilder.UpdateData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ServiceFeatures", "ServiceId" },
                values: new object[] { "تصحيح قراءه عداد", 2 });

            migrationBuilder.InsertData(
                table: "ServiceDetails",
                columns: new[] { "Id", "ServiceFeatures", "ServiceId" },
                values: new object[,]
                {
                    { 4, "تصحيح بيانات صاحب العداد", 2 },
                    { 5, "سداد دفعة مقدمة للعداد", 3 },
                    { 6, "جدوله مديونية على اقساط شهريه", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "ServiceName",
                value: "خدمات العدادات");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "ServiceName",
                value: " تغيير بيانات");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "ServiceName",
                value: " سداد دفعات");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AddColumn<int>(
                name: "ClientRequestId",
                table: "ServiceDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "Gender",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ClientRequestId", "ServiceFeatures" },
                values: new object[] { null, "Product_1" });

            migrationBuilder.UpdateData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ClientRequestId", "ServiceFeatures", "ServiceId" },
                values: new object[] { null, "Product_2", 2 });

            migrationBuilder.UpdateData(
                table: "ServiceDetails",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ClientRequestId", "ServiceFeatures", "ServiceId" },
                values: new object[] { null, "Product_3", 3 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 1,
                column: "ServiceName",
                value: "Service one");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 2,
                column: "ServiceName",
                value: "Service two");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 3,
                column: "ServiceName",
                value: "Service three");

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
    }
}
