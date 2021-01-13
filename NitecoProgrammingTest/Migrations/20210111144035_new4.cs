using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NitecoProgrammingTest.Migrations
{
    public partial class new4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8ee941f9-5b83-4923-8118-dd865992fc0c");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96b771b3-4ffc-46c9-85db-18e714ae4093", "f43e99ae-28a6-488b-b2c3-3145f7b4b56a", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96b771b3-4ffc-46c9-85db-18e714ae4093");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8ee941f9-5b83-4923-8118-dd865992fc0c", "5039e3ea-2007-4d04-9ee7-7fc9ae7b1db3", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 1, 1, 1, new DateTime(2021, 1, 10, 23, 5, 51, 626, DateTimeKind.Local).AddTicks(2245), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 2, 2, 1, new DateTime(2021, 1, 10, 23, 5, 51, 627, DateTimeKind.Local).AddTicks(1208), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 3, 3, 1, new DateTime(2021, 1, 10, 23, 5, 51, 627, DateTimeKind.Local).AddTicks(1266), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 4, 4, 1, new DateTime(2021, 1, 10, 23, 5, 51, 627, DateTimeKind.Local).AddTicks(1283), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 5, 5, 1, new DateTime(2021, 1, 10, 23, 5, 51, 627, DateTimeKind.Local).AddTicks(1298), 1 });
        }
    }
}
