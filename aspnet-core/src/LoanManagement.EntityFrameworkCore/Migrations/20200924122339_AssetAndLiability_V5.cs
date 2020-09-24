using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AssetAndLiability_V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_AssetAndLiablities_AssetAndLiablityId",
                table: "LoanApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetAndLiablities",
                table: "AssetAndLiablities");

            migrationBuilder.RenameTable(
                name: "AssetAndLiablities",
                newName: "AssetAndLiabilities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetAndLiabilities",
                table: "AssetAndLiabilities",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 17, 23, 38, 679, DateTimeKind.Local).AddTicks(9177));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 17, 23, 38, 682, DateTimeKind.Local).AddTicks(429));

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_AssetAndLiabilities_AssetAndLiablityId",
                table: "LoanApplications",
                column: "AssetAndLiablityId",
                principalTable: "AssetAndLiabilities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_AssetAndLiabilities_AssetAndLiablityId",
                table: "LoanApplications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssetAndLiabilities",
                table: "AssetAndLiabilities");

            migrationBuilder.RenameTable(
                name: "AssetAndLiabilities",
                newName: "AssetAndLiablities");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssetAndLiablities",
                table: "AssetAndLiablities",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 17, 22, 18, 496, DateTimeKind.Local).AddTicks(4427));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 17, 22, 18, 497, DateTimeKind.Local).AddTicks(7247));

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_AssetAndLiablities_AssetAndLiablityId",
                table: "LoanApplications",
                column: "AssetAndLiablityId",
                principalTable: "AssetAndLiablities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
