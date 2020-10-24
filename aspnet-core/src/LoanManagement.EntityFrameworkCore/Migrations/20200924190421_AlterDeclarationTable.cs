using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AlterDeclarationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 12, 4, 20, 340, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 12, 4, 20, 343, DateTimeKind.Local).AddTicks(7974));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 11, 28, 59, 205, DateTimeKind.Local).AddTicks(2441));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 11, 28, 59, 208, DateTimeKind.Local).AddTicks(3746));
        }
    }
}
