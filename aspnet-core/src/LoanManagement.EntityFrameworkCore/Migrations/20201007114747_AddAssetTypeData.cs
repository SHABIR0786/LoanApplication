using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddAssetTypeData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockAndBond_ManualAssetEntries_ManualAssetEntryId",
                table: "StockAndBond");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockAndBond",
                table: "StockAndBond");

            migrationBuilder.RenameTable(
                name: "StockAndBond",
                newName: "StockAndBonds");

            migrationBuilder.RenameIndex(
                name: "IX_StockAndBond_ManualAssetEntryId",
                table: "StockAndBonds",
                newName: "IX_StockAndBonds_ManualAssetEntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockAndBonds",
                table: "StockAndBonds",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AssetType",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2020, 10, 7, 16, 47, 46, 681, DateTimeKind.Local).AddTicks(9941), null, null, null, false, null, null, "Cash deposit on sales contract" },
                    { 2L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5558), null, null, null, false, null, null, "Certificate of Deposit" },
                    { 3L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5617), null, null, null, false, null, null, "Checking Account" },
                    { 4L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5620), null, null, null, false, null, null, "Gifts" },
                    { 5L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5622), null, null, null, false, null, null, "Gift of equity" },
                    { 6L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5624), null, null, null, false, null, null, "Money Market Fund" },
                    { 7L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5626), null, null, null, false, null, null, "Mutual Funds" },
                    { 8L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5628), null, null, null, false, null, null, "Net Proceeds from Real Estate Funds" },
                    { 9L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5630), null, null, null, false, null, null, "Retirement Funds" },
                    { 10L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5632), null, null, null, false, null, null, "Savings Account" },
                    { 11L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5634), null, null, null, false, null, null, "Stocks & Bonds" },
                    { 12L, new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5636), null, null, null, false, null, null, "Trust Account" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_StockAndBonds_ManualAssetEntries_ManualAssetEntryId",
                table: "StockAndBonds",
                column: "ManualAssetEntryId",
                principalTable: "ManualAssetEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StockAndBonds_ManualAssetEntries_ManualAssetEntryId",
                table: "StockAndBonds");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockAndBonds",
                table: "StockAndBonds");

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 12L);

            migrationBuilder.RenameTable(
                name: "StockAndBonds",
                newName: "StockAndBond");

            migrationBuilder.RenameIndex(
                name: "IX_StockAndBonds_ManualAssetEntryId",
                table: "StockAndBond",
                newName: "IX_StockAndBond_ManualAssetEntryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockAndBond",
                table: "StockAndBond",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StockAndBond_ManualAssetEntries_ManualAssetEntryId",
                table: "StockAndBond",
                column: "ManualAssetEntryId",
                principalTable: "ManualAssetEntries",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
