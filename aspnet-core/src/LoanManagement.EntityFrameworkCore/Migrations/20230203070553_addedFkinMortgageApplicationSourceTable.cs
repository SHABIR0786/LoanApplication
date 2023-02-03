using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class addedFkinMortgageApplicationSourceTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationIncomeSources_MortgageApplicationSources_~",
                table: "MortgageApplicationIncomeSources");

            migrationBuilder.DropIndex(
                name: "IX_MortgageApplicationIncomeSources_SourceId",
                table: "MortgageApplicationIncomeSources");

            migrationBuilder.DropColumn(
                name: "SourceId",
                table: "MortgageApplicationIncomeSources");

            migrationBuilder.AddColumn<int>(
                name: "IncomeSourceId",
                table: "MortgageApplicationSources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationIncomeSources",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8454));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationSources_IncomeSourceId",
                table: "MortgageApplicationSources",
                column: "IncomeSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationIncomeSources_PersonalInformationId",
                table: "MortgageApplicationIncomeSources",
                column: "PersonalInformationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationIncomeSources_MortgageApplicationPersonal~",
                table: "MortgageApplicationIncomeSources",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationSources_MortgageApplicationIncomeSources_~",
                table: "MortgageApplicationSources",
                column: "IncomeSourceId",
                principalTable: "MortgageApplicationIncomeSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationIncomeSources_MortgageApplicationPersonal~",
                table: "MortgageApplicationIncomeSources");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationSources_MortgageApplicationIncomeSources_~",
                table: "MortgageApplicationSources");

            migrationBuilder.DropIndex(
                name: "IX_MortgageApplicationSources_IncomeSourceId",
                table: "MortgageApplicationSources");

            migrationBuilder.DropIndex(
                name: "IX_MortgageApplicationIncomeSources_PersonalInformationId",
                table: "MortgageApplicationIncomeSources");

            migrationBuilder.DropColumn(
                name: "IncomeSourceId",
                table: "MortgageApplicationSources");

            migrationBuilder.DropColumn(
                name: "PersonalInformationId",
                table: "MortgageApplicationIncomeSources");

            migrationBuilder.AddColumn<int>(
                name: "SourceId",
                table: "MortgageApplicationIncomeSources",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6948));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7168));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationIncomeSources_SourceId",
                table: "MortgageApplicationIncomeSources",
                column: "SourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationIncomeSources_MortgageApplicationSources_~",
                table: "MortgageApplicationIncomeSources",
                column: "SourceId",
                principalTable: "MortgageApplicationSources",
                principalColumn: "Id");
        }
    }
}
