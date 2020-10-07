using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddBorrowerTypeId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowerTypeId",
                table: "ManualAssetEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 7, DateTimeKind.Local).AddTicks(7987));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8556));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8661));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8669));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8673));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8676));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8679));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8683));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8686));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8690));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8694));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8697));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 9, DateTimeKind.Local).AddTicks(8700));

            migrationBuilder.InsertData(
                table: "BorrowerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Both" });

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(3272));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5296));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5317));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5319));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5321));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5323));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5325));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5327));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5329));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5331));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5333));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5335));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5337));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5339));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5340));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5342));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5344));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5346));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5348));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5350));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5352));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5354));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5356));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5358));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5360));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5362));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5364));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5365));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5367));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5369));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5371));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5373));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5375));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5377));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5379));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5380));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5382));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5384));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5388));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5389));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5391));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5395));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5396));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5398));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5400));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5402));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5403));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5405));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5407));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5409));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5411));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5432));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5434));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5436));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5438));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5440));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreationTime",
                value: new DateTime(2020, 10, 8, 3, 53, 3, 18, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.CreateIndex(
                name: "IX_ManualAssetEntries_BorrowerTypeId",
                table: "ManualAssetEntries",
                column: "BorrowerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ManualAssetEntries_BorrowerTypes_BorrowerTypeId",
                table: "ManualAssetEntries",
                column: "BorrowerTypeId",
                principalTable: "BorrowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ManualAssetEntries_BorrowerTypes_BorrowerTypeId",
                table: "ManualAssetEntries");

            migrationBuilder.DropIndex(
                name: "IX_ManualAssetEntries_BorrowerTypeId",
                table: "ManualAssetEntries");

            migrationBuilder.DeleteData(
                table: "BorrowerTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "BorrowerTypeId",
                table: "ManualAssetEntries");

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
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(870));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(872));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(873));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(875));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 23, 11, 42, 568, DateTimeKind.Local).AddTicks(877));

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
    }
}
