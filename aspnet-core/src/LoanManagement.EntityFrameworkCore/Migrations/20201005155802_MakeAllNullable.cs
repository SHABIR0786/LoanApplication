using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class MakeAllNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerEmploymentInformations_BorrowerTypes_BorrowerTypeId",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerMonthlyIncomes_BorrowerTypes_BorrowerTypeId",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DeleteData(
                table: "BorrowerTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BorrowerTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfDependents",
                table: "Borrowers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MaritalStatusId",
                table: "Borrowers",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BorrowerTypeId",
                table: "BorrowerMonthlyIncomes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "BorrowerEmploymentInformations",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "BorrowerEmploymentInformations",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<int>(
                name: "BorrowerTypeId",
                table: "BorrowerEmploymentInformations",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Address",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Years",
                table: "Address",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "Months",
                table: "Address",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "BorrowerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Borrower" });

            migrationBuilder.InsertData(
                table: "BorrowerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Co-Borrower" });

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerEmploymentInformations_BorrowerTypes_BorrowerTypeId",
                table: "BorrowerEmploymentInformations",
                column: "BorrowerTypeId",
                principalTable: "BorrowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerMonthlyIncomes_BorrowerTypes_BorrowerTypeId",
                table: "BorrowerMonthlyIncomes",
                column: "BorrowerTypeId",
                principalTable: "BorrowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerEmploymentInformations_BorrowerTypes_BorrowerTypeId",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerMonthlyIncomes_BorrowerTypes_BorrowerTypeId",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DeleteData(
                table: "BorrowerTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BorrowerTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfDependents",
                table: "Borrowers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaritalStatusId",
                table: "Borrowers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BorrowerTypeId",
                table: "BorrowerMonthlyIncomes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartDate",
                table: "BorrowerEmploymentInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndDate",
                table: "BorrowerEmploymentInformations",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BorrowerTypeId",
                table: "BorrowerEmploymentInformations",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ZipCode",
                table: "Address",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Years",
                table: "Address",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Months",
                table: "Address",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "BorrowerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Borrower" });

            migrationBuilder.InsertData(
                table: "BorrowerTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Co-Borrower" });

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerEmploymentInformations_BorrowerTypes_BorrowerTypeId",
                table: "BorrowerEmploymentInformations",
                column: "BorrowerTypeId",
                principalTable: "BorrowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerMonthlyIncomes_BorrowerTypes_BorrowerTypeId",
                table: "BorrowerMonthlyIncomes",
                column: "BorrowerTypeId",
                principalTable: "BorrowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
