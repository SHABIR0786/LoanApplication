using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class BorrowerInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_BorrowerEmplo~",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_CoBorrowerEmp~",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_BorrowerEmploymentInfoId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_CoBorrowerEmploymentInfoId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BorrowerEmploymentInfoId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "CoBorrowerEmploymentInfoId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BorrowerType",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "BusinessPhone1",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "BusinessPhone2",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "BusinessPhone3",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "DateFromTo2",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "DateFromTo3",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "EmployersAddress1",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "EmployersAddress2",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "EmployersAddress3",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "EmployersName1",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "EmployersName2",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "EmployersName3",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "IsSelfEmployer1",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "IsSelfEmployer2",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "IsSelfEmployer3",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "MonthlyIncome2",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "MonthlyIncome3",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "Position1",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "Position2",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "Position3",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "YearInThisLineOfWork1",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "YearOnThisJob1",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.AddColumn<long>(
                name: "BorrowerEmploymentInfoId1",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BorrowerEmploymentInfoId2",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BorrowerEmploymentInfoId3",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CoBorrowerEmploymentInfoId1",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CoBorrowerEmploymentInfoId2",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CoBorrowerEmploymentInfoId3",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone",
                table: "BorrowerEmploymentInformation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFromTo",
                table: "BorrowerEmploymentInformation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployersAddress",
                table: "BorrowerEmploymentInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployersName",
                table: "BorrowerEmploymentInformation",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsSelfEmployer",
                table: "BorrowerEmploymentInformation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyIncome",
                table: "BorrowerEmploymentInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "BorrowerEmploymentInformation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearInThisLineOfWork",
                table: "BorrowerEmploymentInformation",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOnThisJob",
                table: "BorrowerEmploymentInformation",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BorrowerEmploymentInfoId1",
                table: "LoanApplications",
                column: "BorrowerEmploymentInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BorrowerEmploymentInfoId2",
                table: "LoanApplications",
                column: "BorrowerEmploymentInfoId2");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BorrowerEmploymentInfoId3",
                table: "LoanApplications",
                column: "BorrowerEmploymentInfoId3");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CoBorrowerEmploymentInfoId1",
                table: "LoanApplications",
                column: "CoBorrowerEmploymentInfoId1");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CoBorrowerEmploymentInfoId2",
                table: "LoanApplications",
                column: "CoBorrowerEmploymentInfoId2");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CoBorrowerEmploymentInfoId3",
                table: "LoanApplications",
                column: "CoBorrowerEmploymentInfoId3");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_BorrowerEmplo~",
                table: "LoanApplications",
                column: "BorrowerEmploymentInfoId1",
                principalTable: "BorrowerEmploymentInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_BorrowerEmpl~1",
                table: "LoanApplications",
                column: "BorrowerEmploymentInfoId2",
                principalTable: "BorrowerEmploymentInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_BorrowerEmpl~2",
                table: "LoanApplications",
                column: "BorrowerEmploymentInfoId3",
                principalTable: "BorrowerEmploymentInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_CoBorrowerEmp~",
                table: "LoanApplications",
                column: "CoBorrowerEmploymentInfoId1",
                principalTable: "BorrowerEmploymentInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_CoBorrowerEm~1",
                table: "LoanApplications",
                column: "CoBorrowerEmploymentInfoId2",
                principalTable: "BorrowerEmploymentInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_CoBorrowerEm~2",
                table: "LoanApplications",
                column: "CoBorrowerEmploymentInfoId3",
                principalTable: "BorrowerEmploymentInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_BorrowerEmplo~",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_BorrowerEmpl~1",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_BorrowerEmpl~2",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_CoBorrowerEmp~",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_CoBorrowerEm~1",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_CoBorrowerEm~2",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_BorrowerEmploymentInfoId1",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_BorrowerEmploymentInfoId2",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_BorrowerEmploymentInfoId3",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_CoBorrowerEmploymentInfoId1",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_CoBorrowerEmploymentInfoId2",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_CoBorrowerEmploymentInfoId3",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BorrowerEmploymentInfoId1",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BorrowerEmploymentInfoId2",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BorrowerEmploymentInfoId3",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "CoBorrowerEmploymentInfoId1",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "CoBorrowerEmploymentInfoId2",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "CoBorrowerEmploymentInfoId3",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "BusinessPhone",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "DateFromTo",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "EmployersAddress",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "EmployersName",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "IsSelfEmployer",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "MonthlyIncome",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "YearInThisLineOfWork",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "YearOnThisJob",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.AddColumn<long>(
                name: "BorrowerEmploymentInfoId",
                table: "LoanApplications",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CoBorrowerEmploymentInfoId",
                table: "LoanApplications",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BorrowerType",
                table: "BorrowerEmploymentInformation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone1",
                table: "BorrowerEmploymentInformation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone2",
                table: "BorrowerEmploymentInformation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BusinessPhone3",
                table: "BorrowerEmploymentInformation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFromTo2",
                table: "BorrowerEmploymentInformation",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DateFromTo3",
                table: "BorrowerEmploymentInformation",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "EmployersAddress1",
                table: "BorrowerEmploymentInformation",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployersAddress2",
                table: "BorrowerEmploymentInformation",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployersAddress3",
                table: "BorrowerEmploymentInformation",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployersName1",
                table: "BorrowerEmploymentInformation",
                type: "varchar(100) CHARACTER SET utf8mb4",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployersName2",
                table: "BorrowerEmploymentInformation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmployersName3",
                table: "BorrowerEmploymentInformation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelfEmployer1",
                table: "BorrowerEmploymentInformation",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelfEmployer2",
                table: "BorrowerEmploymentInformation",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSelfEmployer3",
                table: "BorrowerEmploymentInformation",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyIncome2",
                table: "BorrowerEmploymentInformation",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyIncome3",
                table: "BorrowerEmploymentInformation",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position1",
                table: "BorrowerEmploymentInformation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position2",
                table: "BorrowerEmploymentInformation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position3",
                table: "BorrowerEmploymentInformation",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearInThisLineOfWork1",
                table: "BorrowerEmploymentInformation",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "YearOnThisJob1",
                table: "BorrowerEmploymentInformation",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BorrowerEmploymentInfoId",
                table: "LoanApplications",
                column: "BorrowerEmploymentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CoBorrowerEmploymentInfoId",
                table: "LoanApplications",
                column: "CoBorrowerEmploymentInfoId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_BorrowerEmplo~",
                table: "LoanApplications",
                column: "BorrowerEmploymentInfoId",
                principalTable: "BorrowerEmploymentInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_BorrowerEmploymentInformation_CoBorrowerEmp~",
                table: "LoanApplications",
                column: "CoBorrowerEmploymentInfoId",
                principalTable: "BorrowerEmploymentInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
