using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddMissingAsset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 566, DateTimeKind.Local).AddTicks(8026));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(813));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(857));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(860));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(862));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(864));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(866));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(868));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(870), "Real Estate Owned" });

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(872), "Retirement Funds" });

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(873), "Savings Account" });

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(875), "Stocks & Bonds" });

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
                values: new object[] { 13L, new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(877), null, null, null, false, null, null, "Trust Account" });

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(6800));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8608));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8627));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8629));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8631));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8633));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8635));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8637));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8664));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8665));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8667));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8671));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8678));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8680));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8682));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8684));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8685));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8687));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8689));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8691));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8693));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8696));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8698));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8703));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8705));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8712));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8714));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8716));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8717));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8719));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8721));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8723));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8725));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8726));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8728));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8730));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8732));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8734));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8735));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8737));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8739));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8741));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8742));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8744));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8746));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 571, DateTimeKind.Local).AddTicks(8749));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 13L);

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 746, DateTimeKind.Local).AddTicks(6013));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8018));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8062));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8065));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8067));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8069));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8071));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8073));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8075), "Retirement Funds" });

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8077), "Savings Account" });

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8079), "Stocks & Bonds" });

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreationTime", "Name" },
                values: new object[] { new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8081), "Trust Account" });

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(668));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1751));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1768));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1770));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1772));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1775));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1777));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1799));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1801));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1803));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1805));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1806));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1808));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1810));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1812));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1814));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1815));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1817));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1819));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1821));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1824));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1826));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1828));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1830));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1832));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1834));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1836));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1838));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1839));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1841));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1845));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1847));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1849));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1851));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1853));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1854));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1856));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1858));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1860));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1862));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1864));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1866));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1868));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1870));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1872));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1873));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1875));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1877));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1879));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1881));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1883));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1885));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1886));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1888));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1890));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1892));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1894));
        }
    }
}
