using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AssetAndLiablity_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "LifeInsuranceNetFaceAmount",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetWorth",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAssets",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalLiabilities",
                table: "AssetAndLiablities",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LifeInsuranceNetFaceAmount",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "NetWorth",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "TotalAssets",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "TotalLiabilities",
                table: "AssetAndLiablities");

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 15, 14, 23, 437, DateTimeKind.Local).AddTicks(3467));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 15, 14, 23, 439, DateTimeKind.Local).AddTicks(2627));
        }
    }
}
