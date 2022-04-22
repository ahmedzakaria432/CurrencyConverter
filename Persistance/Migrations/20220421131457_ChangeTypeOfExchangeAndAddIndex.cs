using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CurrencyConverter.Infrastructure.Migrations
{
    public partial class ChangeTypeOfExchangeAndAddIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("20d0b2b3-7df8-4dc6-a4ae-d97746f18bd4"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExchangeDate",
                table: "exchangeHistories",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.InsertData(
                table: "exchangeHistories",
                columns: new[] { "Id", "CurrencyId", "ExchangeDate", "Rate" },
                values: new object[] { new Guid("498531c9-af8c-41a4-9530-d0cad1fa3674"), new Guid("9c37c1e5-5e1b-4f06-ad7c-16e7a10d212d"), new DateTime(2022, 4, 19, 14, 50, 39, 998, DateTimeKind.Unspecified).AddTicks(887), 1.0 });

            migrationBuilder.CreateIndex(
                name: "IX_exchangeHistories_ExchangeDate",
                table: "exchangeHistories",
                column: "ExchangeDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_exchangeHistories_ExchangeDate",
                table: "exchangeHistories");

            migrationBuilder.DeleteData(
                table: "exchangeHistories",
                keyColumn: "Id",
                keyValue: new Guid("498531c9-af8c-41a4-9530-d0cad1fa3674"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExchangeDate",
                table: "exchangeHistories",
                type: "date",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "exchangeHistories",
                columns: new[] { "Id", "CurrencyId", "ExchangeDate", "Rate" },
                values: new object[] { new Guid("20d0b2b3-7df8-4dc6-a4ae-d97746f18bd4"), new Guid("9c37c1e5-5e1b-4f06-ad7c-16e7a10d212d"), new DateTime(2022, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), 1.0 });
        }
    }
}
