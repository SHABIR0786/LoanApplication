using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LoanManagement.Migrations
{
    public partial class removeEmoploymentincome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_EmploymentIncomes_EmploymentIncomeId",
                table: "LoanApplications");

            migrationBuilder.DropTable(
                name: "EmploymentIncomes");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_EmploymentIncomeId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "EmploymentIncomeId",
                table: "LoanApplications");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EmploymentIncomeId",
                table: "LoanApplications",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmploymentIncomes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BorrowerEmploymentInformationsId = table.Column<long>(type: "bigint", nullable: true),
                    BorrowerMonthlyIncomeId = table.Column<long>(type: "bigint", nullable: true),
                    CoBorrowerEmploymentInformationsId = table.Column<long>(type: "bigint", nullable: true),
                    CoBorrowerMonthlyIncomeId = table.Column<long>(type: "bigint", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmploymentIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmploymentIncomes_BorrowerEmploymentInformations_BorrowerEmp~",
                        column: x => x.BorrowerEmploymentInformationsId,
                        principalTable: "BorrowerEmploymentInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmploymentIncomes_BorrowerMonthlyIncomes_BorrowerMonthlyInco~",
                        column: x => x.BorrowerMonthlyIncomeId,
                        principalTable: "BorrowerMonthlyIncomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmploymentIncomes_BorrowerEmploymentInformations_CoBorrowerE~",
                        column: x => x.CoBorrowerEmploymentInformationsId,
                        principalTable: "BorrowerEmploymentInformations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_EmploymentIncomes_BorrowerMonthlyIncomes_CoBorrowerMonthlyIn~",
                        column: x => x.CoBorrowerMonthlyIncomeId,
                        principalTable: "BorrowerMonthlyIncomes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_EmploymentIncomeId",
                table: "LoanApplications",
                column: "EmploymentIncomeId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_EmploymentIncomes_EmploymentIncomeId",
                table: "LoanApplications",
                column: "EmploymentIncomeId",
                principalTable: "EmploymentIncomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
