using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AssetAndLiablity_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountName",
                table: "AssetAndLiablities");

            migrationBuilder.AddColumn<string>(
                name: "AccountNumber",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 17, 15, 50, 389, DateTimeKind.Local).AddTicks(9936));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 17, 15, 50, 394, DateTimeKind.Local).AddTicks(1673));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountNumber",
                table: "AssetAndLiablities");

            migrationBuilder.AddColumn<string>(
                name: "AccountName",
                table: "AssetAndLiablities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 17, 8, 31, 423, DateTimeKind.Local).AddTicks(3804));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 17, 8, 31, 425, DateTimeKind.Local).AddTicks(5483));
        }
    }
}
