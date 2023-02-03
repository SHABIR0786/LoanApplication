using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class addisAppliedfieldinMortgageLoanOnFinancialPropertytable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgagePropertyFinancialInformations_MortgageApplicationPer~",
                table: "MortgagePropertyFinancialInformations");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgagePropertyFinancialInformations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "isApplied",
                table: "MortgageLoanOnProperyFinancialInformations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "creditLimit",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<bool>(
                name: "isApplied",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1240));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1242));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1244));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1262));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1265));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1267));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1271));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1273));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1275));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1276));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1278));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1692));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1700));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1702));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1703));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 13, 414, DateTimeKind.Local).AddTicks(1763));

            migrationBuilder.AddForeignKey(
                name: "FK_MortgagePropertyFinancialInformations_MortgageApplicationPer~",
                table: "MortgagePropertyFinancialInformations",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgagePropertyFinancialInformations_MortgageApplicationPer~",
                table: "MortgagePropertyFinancialInformations");

            migrationBuilder.DropColumn(
                name: "isApplied",
                table: "MortgageLoanOnProperyFinancialInformations");

            migrationBuilder.DropColumn(
                name: "creditLimit",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations");

            migrationBuilder.DropColumn(
                name: "isApplied",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgagePropertyFinancialInformations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.AddForeignKey(
                name: "FK_MortgagePropertyFinancialInformations_MortgageApplicationPer~",
                table: "MortgagePropertyFinancialInformations",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
