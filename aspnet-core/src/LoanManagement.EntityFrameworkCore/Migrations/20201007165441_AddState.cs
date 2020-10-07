using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "State",
                table: "ManualAssetEntries");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Addresses");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "ManualAssetEntries",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.Id);
                });

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
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8075));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8077));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 21, 54, 40, 747, DateTimeKind.Local).AddTicks(8081));

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
                values: new object[,]
                {
                    { 58, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1892), null, null, null, false, null, null, "WI" },
                    { 38, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1854), null, null, null, false, null, null, "NC" },
                    { 39, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1856), null, null, null, false, null, null, "ND" },
                    { 40, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1858), null, null, null, false, null, null, "MP" },
                    { 41, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1860), null, null, null, false, null, null, "OH" },
                    { 42, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1862), null, null, null, false, null, null, "OK" },
                    { 43, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1864), null, null, null, false, null, null, "OR" },
                    { 44, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1866), null, null, null, false, null, null, "PW" },
                    { 45, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1868), null, null, null, false, null, null, "PA" },
                    { 46, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1870), null, null, null, false, null, null, "PR" },
                    { 59, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1894), null, null, null, false, null, null, "WY" },
                    { 47, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1872), null, null, null, false, null, null, "RI" },
                    { 49, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1875), null, null, null, false, null, null, "SD" },
                    { 50, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1877), null, null, null, false, null, null, "TN" },
                    { 51, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1879), null, null, null, false, null, null, "TX" },
                    { 52, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1881), null, null, null, false, null, null, "UT" },
                    { 37, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1853), null, null, null, false, null, null, "NY" },
                    { 54, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1885), null, null, null, false, null, null, "VI" },
                    { 55, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1886), null, null, null, false, null, null, "VA" },
                    { 56, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1888), null, null, null, false, null, null, "WA" },
                    { 57, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1890), null, null, null, false, null, null, "WV" },
                    { 48, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1873), null, null, null, false, null, null, "SC" },
                    { 53, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1883), null, null, null, false, null, null, "VT" },
                    { 36, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1851), null, null, null, false, null, null, "NM" },
                    { 34, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1847), null, null, null, false, null, null, "NH" },
                    { 15, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1812), null, null, null, false, null, null, "HI" },
                    { 14, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1810), null, null, null, false, null, null, "GU" },
                    { 13, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1808), null, null, null, false, null, null, "GA" },
                    { 12, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1806), null, null, null, false, null, null, "FL" },
                    { 11, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1805), null, null, null, false, null, null, "FM" },
                    { 10, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1803), null, null, null, false, null, null, "DC" },
                    { 16, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1814), null, null, null, false, null, null, "ID" },
                    { 9, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1801), null, null, null, false, null, null, "DE" },
                    { 7, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1777), null, null, null, false, null, null, "CO" },
                    { 6, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1775), null, null, null, false, null, null, "CA" },
                    { 5, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1772), null, null, null, false, null, null, "AR" },
                    { 4, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1770), null, null, null, false, null, null, "AZ" },
                    { 3, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1768), null, null, null, false, null, null, "AS" },
                    { 2, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1751), null, null, null, false, null, null, "AK" },
                    { 8, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1799), null, null, null, false, null, null, "CT" },
                    { 35, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1849), null, null, null, false, null, null, "NJ" },
                    { 17, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1815), null, null, null, false, null, null, "IL" },
                    { 19, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1819), null, null, null, false, null, null, "IA" },
                    { 33, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1845), null, null, null, false, null, null, "NV" },
                    { 32, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1843), null, null, null, false, null, null, "NE" },
                    { 31, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1841), null, null, null, false, null, null, "MT" },
                    { 30, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1839), null, null, null, false, null, null, "MO" },
                    { 29, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1838), null, null, null, false, null, null, "MS" },
                    { 28, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1836), null, null, null, false, null, null, "MN" },
                    { 18, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1817), null, null, null, false, null, null, "IN" },
                    { 27, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1834), null, null, null, false, null, null, "MI" },
                    { 25, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1830), null, null, null, false, null, null, "MD" },
                    { 24, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1828), null, null, null, false, null, null, "MH" },
                    { 23, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1826), null, null, null, false, null, null, "ME" },
                    { 22, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1824), null, null, null, false, null, null, "LA" },
                    { 21, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1822), null, null, null, false, null, null, "KY" },
                    { 20, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1821), null, null, null, false, null, null, "KS" },
                    { 26, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(1832), null, null, null, false, null, null, "MA" },
                    { 1, new DateTime(2020, 10, 7, 21, 54, 40, 751, DateTimeKind.Local).AddTicks(668), null, null, null, false, null, null, "AL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManualAssetEntries_StateId",
                table: "ManualAssetEntries",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ManualAssetEntries_States_StateId",
                table: "ManualAssetEntries",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_States_StateId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_ManualAssetEntries_States_StateId",
                table: "ManualAssetEntries");

            migrationBuilder.DropTable(
                name: "States");

            migrationBuilder.DropIndex(
                name: "IX_ManualAssetEntries_StateId",
                table: "ManualAssetEntries");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_StateId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "ManualAssetEntries");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Addresses");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "ManualAssetEntries",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Addresses",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 681, DateTimeKind.Local).AddTicks(9941));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5558));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5617));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5620));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5622));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5624));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5626));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5628));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5630));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5632));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5634));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 7, 16, 47, 46, 683, DateTimeKind.Local).AddTicks(5636));
        }
    }
}
