using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class removedTenentId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplications");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationTypeOfCredits",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationSources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationPreviousEmploymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationPersonalInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationOtherBorrowers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationMailingAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationIncomeSources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationFormerAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationEmploymentIncomeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationEmploymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationCurrentAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationContactInformation",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationAlternateNames",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(419));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(432));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(433));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(564));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(571));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(572));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(574));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(575));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(576));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(577));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(578));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(579));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(580));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(799));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(802));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(803));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(805));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 20, 23, 10, 491, DateTimeKind.Local).AddTicks(841));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationTypeOfCredits");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationSources");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationPreviousEmploymentDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationPersonalInformation");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationOtherBorrowers");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationMailingAddresses");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationIncomeSources");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationFormerAddresses");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationEmploymentIncomeDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationEmploymentDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationCurrentAddresses");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationContactInformation");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationAlternateNames");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "MortgageApplicationAdditionalEmploymentDetails");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "MortgageApplications",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8898));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8911));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8912));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8913));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8915));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8916));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8917));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8918));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8919));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8920));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8921));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(8928));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(9142));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(9145));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(9146));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(9147));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 19, 41, 5, 320, DateTimeKind.Local).AddTicks(9184));
        }
    }
}
