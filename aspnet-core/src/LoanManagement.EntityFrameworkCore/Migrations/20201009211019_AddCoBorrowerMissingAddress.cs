using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddCoBorrowerMissingAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CoBorrowerIsMailingAddressSameAsResidential",
                table: "PersonalDetails",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BorrowerTypeId",
                table: "Addresses",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 598, DateTimeKind.Local).AddTicks(8347));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2081));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2107));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2109));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2110));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2112));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2113));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2114));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2115));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2116));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2118));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2119));

            migrationBuilder.UpdateData(
                table: "AssetType",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 599, DateTimeKind.Local).AddTicks(2120));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(4643));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5857));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5859));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5861));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5862));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5863));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5864));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5866));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5867));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5868));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5869));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5871));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5872));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5873));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5874));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5875));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5877));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5879));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5880));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5881));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5883));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5884));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5885));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5886));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5888));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5889));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5890));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5891));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5893));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5894));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5895));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5896));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5898));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5899));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5900));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5901));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5903));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5905));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5906));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5908));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5909));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5911));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5913));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5914));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5915));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5925));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5926));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5928));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5929));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5930));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5931));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5932));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5934));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5935));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5936));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreationTime",
                value: new DateTime(2020, 10, 10, 2, 10, 18, 601, DateTimeKind.Local).AddTicks(5937));

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_BorrowerTypeId",
                table: "Addresses",
                column: "BorrowerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_BorrowerTypes_BorrowerTypeId",
                table: "Addresses",
                column: "BorrowerTypeId",
                principalTable: "BorrowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_BorrowerTypes_BorrowerTypeId",
                table: "Addresses");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_BorrowerTypeId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CoBorrowerIsMailingAddressSameAsResidential",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "BorrowerTypeId",
                table: "Addresses");

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
        }
    }
}
