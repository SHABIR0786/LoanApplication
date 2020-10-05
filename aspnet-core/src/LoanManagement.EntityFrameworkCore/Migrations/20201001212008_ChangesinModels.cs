using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LoanManagement.Migrations
{
    public partial class ChangesinModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerEmploymentInformations_EmploymentIncomes_EmploymentI~",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerEmploymentInformations_EmploymentIncomes_Employment~1",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerMonthlyIncomes_EmploymentIncomes_EmploymentIncomeId",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerMonthlyIncomes_EmploymentIncomes_EmploymentIncomeId1",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_BorrowerMonthlyIncomes_EmploymentIncomeId",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_BorrowerMonthlyIncomes_EmploymentIncomeId1",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_BorrowerEmploymentInformations_EmploymentIncomeId",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropIndex(
                name: "IX_BorrowerEmploymentInformations_EmploymentIncomeId1",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropColumn(
                name: "EmploymentIncomeId",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DropColumn(
                name: "EmploymentIncomeId1",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DropColumn(
                name: "EmploymentIncomeId",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropColumn(
                name: "EmploymentIncomeId1",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.AddColumn<long>(
                name: "BorrowerEmploymentInformationsId",
                table: "EmploymentIncomes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BorrowerMonthlyIncomeId",
                table: "EmploymentIncomes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CoBorrowerEmploymentInformationsId",
                table: "EmploymentIncomes",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "CoBorrowerMonthlyIncomeId",
                table: "EmploymentIncomes",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSelfEmployed",
                table: "BorrowerEmploymentInformations",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "tinyint(1)");

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    AddressType = table.Column<string>(nullable: true),
                    AddressLine1 = table.Column<string>(nullable: true),
                    AddressLine2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<int>(nullable: false),
                    Years = table.Column<int>(nullable: false),
                    Months = table.Column<int>(nullable: false),
                    PersonalDetailId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_PersonalDetails_PersonalDetailId",
                        column: x => x.PersonalDetailId,
                        principalTable: "PersonalDetails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentIncomes_BorrowerEmploymentInformationsId",
                table: "EmploymentIncomes",
                column: "BorrowerEmploymentInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentIncomes_BorrowerMonthlyIncomeId",
                table: "EmploymentIncomes",
                column: "BorrowerMonthlyIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentIncomes_CoBorrowerEmploymentInformationsId",
                table: "EmploymentIncomes",
                column: "CoBorrowerEmploymentInformationsId");

            migrationBuilder.CreateIndex(
                name: "IX_EmploymentIncomes_CoBorrowerMonthlyIncomeId",
                table: "EmploymentIncomes",
                column: "CoBorrowerMonthlyIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_Address_PersonalDetailId",
                table: "Address",
                column: "PersonalDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentIncomes_BorrowerEmploymentInformations_BorrowerEmp~",
                table: "EmploymentIncomes",
                column: "BorrowerEmploymentInformationsId",
                principalTable: "BorrowerEmploymentInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentIncomes_BorrowerMonthlyIncomes_BorrowerMonthlyInco~",
                table: "EmploymentIncomes",
                column: "BorrowerMonthlyIncomeId",
                principalTable: "BorrowerMonthlyIncomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentIncomes_BorrowerEmploymentInformations_CoBorrowerE~",
                table: "EmploymentIncomes",
                column: "CoBorrowerEmploymentInformationsId",
                principalTable: "BorrowerEmploymentInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EmploymentIncomes_BorrowerMonthlyIncomes_CoBorrowerMonthlyIn~",
                table: "EmploymentIncomes",
                column: "CoBorrowerMonthlyIncomeId",
                principalTable: "BorrowerMonthlyIncomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentIncomes_BorrowerEmploymentInformations_BorrowerEmp~",
                table: "EmploymentIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentIncomes_BorrowerMonthlyIncomes_BorrowerMonthlyInco~",
                table: "EmploymentIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentIncomes_BorrowerEmploymentInformations_CoBorrowerE~",
                table: "EmploymentIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_EmploymentIncomes_BorrowerMonthlyIncomes_CoBorrowerMonthlyIn~",
                table: "EmploymentIncomes");

            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentIncomes_BorrowerEmploymentInformationsId",
                table: "EmploymentIncomes");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentIncomes_BorrowerMonthlyIncomeId",
                table: "EmploymentIncomes");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentIncomes_CoBorrowerEmploymentInformationsId",
                table: "EmploymentIncomes");

            migrationBuilder.DropIndex(
                name: "IX_EmploymentIncomes_CoBorrowerMonthlyIncomeId",
                table: "EmploymentIncomes");

            migrationBuilder.DropColumn(
                name: "BorrowerEmploymentInformationsId",
                table: "EmploymentIncomes");

            migrationBuilder.DropColumn(
                name: "BorrowerMonthlyIncomeId",
                table: "EmploymentIncomes");

            migrationBuilder.DropColumn(
                name: "CoBorrowerEmploymentInformationsId",
                table: "EmploymentIncomes");

            migrationBuilder.DropColumn(
                name: "CoBorrowerMonthlyIncomeId",
                table: "EmploymentIncomes");

            migrationBuilder.AddColumn<long>(
                name: "EmploymentIncomeId",
                table: "BorrowerMonthlyIncomes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmploymentIncomeId1",
                table: "BorrowerMonthlyIncomes",
                type: "bigint",
                nullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsSelfEmployed",
                table: "BorrowerEmploymentInformations",
                type: "tinyint(1)",
                nullable: false,
                oldClrType: typeof(bool),
                oldNullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmploymentIncomeId",
                table: "BorrowerEmploymentInformations",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "EmploymentIncomeId1",
                table: "BorrowerEmploymentInformations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerMonthlyIncomes_EmploymentIncomeId",
                table: "BorrowerMonthlyIncomes",
                column: "EmploymentIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerMonthlyIncomes_EmploymentIncomeId1",
                table: "BorrowerMonthlyIncomes",
                column: "EmploymentIncomeId1");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerEmploymentInformations_EmploymentIncomeId",
                table: "BorrowerEmploymentInformations",
                column: "EmploymentIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerEmploymentInformations_EmploymentIncomeId1",
                table: "BorrowerEmploymentInformations",
                column: "EmploymentIncomeId1");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerEmploymentInformations_EmploymentIncomes_EmploymentI~",
                table: "BorrowerEmploymentInformations",
                column: "EmploymentIncomeId",
                principalTable: "EmploymentIncomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerEmploymentInformations_EmploymentIncomes_Employment~1",
                table: "BorrowerEmploymentInformations",
                column: "EmploymentIncomeId1",
                principalTable: "EmploymentIncomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerMonthlyIncomes_EmploymentIncomes_EmploymentIncomeId",
                table: "BorrowerMonthlyIncomes",
                column: "EmploymentIncomeId",
                principalTable: "EmploymentIncomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerMonthlyIncomes_EmploymentIncomes_EmploymentIncomeId1",
                table: "BorrowerMonthlyIncomes",
                column: "EmploymentIncomeId1",
                principalTable: "EmploymentIncomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
