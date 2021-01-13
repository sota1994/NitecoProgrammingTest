using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NitecoProgrammingTest.Migrations
{
    public partial class new6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb74dd5b-498e-4008-ba84-fd683899e2ed");

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "95852c60-2ea0-4d39-bd5c-77018b32080c", "510ae066-0dd9-48a6-999a-c241848aaee1", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 1, 1, 1, new DateTime(2021, 1, 11, 21, 56, 53, 267, DateTimeKind.Local).AddTicks(3557), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 2, 2, 1, new DateTime(2021, 1, 11, 21, 56, 53, 268, DateTimeKind.Local).AddTicks(3080), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 3, 3, 1, new DateTime(2021, 1, 11, 21, 56, 53, 268, DateTimeKind.Local).AddTicks(3151), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 4, 4, 1, new DateTime(2021, 1, 11, 21, 56, 53, 268, DateTimeKind.Local).AddTicks(3170), 1 });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "Amount", "CustomerId", "OrderDate", "ProductId" },
                values: new object[] { 5, 5, 1, new DateTime(2021, 1, 11, 21, 56, 53, 268, DateTimeKind.Local).AddTicks(3188), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95852c60-2ea0-4d39-bd5c-77018b32080c");

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

            migrationBuilder.AlterColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "CustomerId",
                table: "Orders",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cb74dd5b-498e-4008-ba84-fd683899e2ed", "03c1296f-7faf-4b86-a99c-52b365c4c853", "User", "USER" });
        }
    }
}
