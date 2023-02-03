using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class changedApplicationIdname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationPersonalInformation_MortgageApplications_~",
                table: "MortgageApplicationPersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MortgageApplicationPersonalInformation_MortgageApplicationId~",
                table: "MortgageApplicationPersonalInformation");

            migrationBuilder.DropColumn(
                name: "MortgageApplicationIdId",
                table: "MortgageApplicationPersonalInformation");

            migrationBuilder.RenameColumn(
                name: "MortgageApplication",
                table: "MortgageApplicationPersonalInformation",
                newName: "MortgageApplicationId");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6581));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6595));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6596));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6599));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6600));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6601));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6602));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6603));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6604));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6606));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6785));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6790));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6791));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6792));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 47, 26, 868, DateTimeKind.Local).AddTicks(6868));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationPersonalInformation_MortgageApplicationId",
                table: "MortgageApplicationPersonalInformation",
                column: "MortgageApplicationId");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationPersonalInformation_MortgageApplications_~",
                table: "MortgageApplicationPersonalInformation",
                column: "MortgageApplicationId",
                principalTable: "MortgageApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationPersonalInformation_MortgageApplications_~",
                table: "MortgageApplicationPersonalInformation");

            migrationBuilder.DropIndex(
                name: "IX_MortgageApplicationPersonalInformation_MortgageApplicationId",
                table: "MortgageApplicationPersonalInformation");

            migrationBuilder.RenameColumn(
                name: "MortgageApplicationId",
                table: "MortgageApplicationPersonalInformation",
                newName: "MortgageApplication");

            migrationBuilder.AddColumn<int>(
                name: "MortgageApplicationIdId",
                table: "MortgageApplicationPersonalInformation",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2455));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationPersonalInformation_MortgageApplicationId~",
                table: "MortgageApplicationPersonalInformation",
                column: "MortgageApplicationIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationPersonalInformation_MortgageApplications_~",
                table: "MortgageApplicationPersonalInformation",
                column: "MortgageApplicationIdId",
                principalTable: "MortgageApplications",
                principalColumn: "Id");
        }
    }
}
