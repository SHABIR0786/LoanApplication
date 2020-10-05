using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class addrelationwithloanApplicationId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_AdditionalDetails_AdditionalDetailId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_AdditionalIncomes_AdditionalIncomeId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_ConsentDetails_ConsentDetailId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_CreditAuthAgreements_CreditAuthAgreementId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DeclarationBorrowereDemographicsInformation~",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Declarations_DeclarationId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Expenses_ExpenseId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_LoanDetails_LoanDetailId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_PersonalDetails_PersonalDetailId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_AdditionalDetailId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_AdditionalIncomeId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_ConsentDetailId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_CreditAuthAgreementId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_DeclarationBorrowereDemographicsInformation~",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_DeclarationId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_ExpenseId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_LoanDetailId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_PersonalDetailId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "AdditionalDetailId",
                table: "LoanApplications");

            migrationBuilder.RenameColumn(
                name: "declarationsSection",
                table: "Declarations",
                newName: "DeclarationsSection");

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "PersonalDetails",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "LoanDetails",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "Expenses",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "Declarations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "DeclarationBorrowereDemographicsInformations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "CreditAuthAgreements",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "ConsentDetails",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "BorrowerMonthlyIncomes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "BorrowerEmploymentInformations",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "AdditionalIncomes",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "LoanApplicationId",
                table: "AdditionalDetails",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_PersonalDetails_LoanApplicationId",
                table: "PersonalDetails",
                column: "LoanApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanDetails_LoanApplicationId",
                table: "LoanDetails",
                column: "LoanApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_LoanApplicationId",
                table: "Expenses",
                column: "LoanApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_LoanApplicationId",
                table: "Declarations",
                column: "LoanApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeclarationBorrowereDemographicsInformations_LoanApplication~",
                table: "DeclarationBorrowereDemographicsInformations",
                column: "LoanApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CreditAuthAgreements_LoanApplicationId",
                table: "CreditAuthAgreements",
                column: "LoanApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConsentDetails_LoanApplicationId",
                table: "ConsentDetails",
                column: "LoanApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerMonthlyIncomes_LoanApplicationId",
                table: "BorrowerMonthlyIncomes",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerEmploymentInformations_LoanApplicationId",
                table: "BorrowerEmploymentInformations",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalIncomes_LoanApplicationId",
                table: "AdditionalIncomes",
                column: "LoanApplicationId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalDetails_LoanApplicationId",
                table: "AdditionalDetails",
                column: "LoanApplicationId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalDetails_LoanApplications_LoanApplicationId",
                table: "AdditionalDetails",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdditionalIncomes_LoanApplications_LoanApplicationId",
                table: "AdditionalIncomes",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerEmploymentInformations_LoanApplications_LoanApplicat~",
                table: "BorrowerEmploymentInformations",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerMonthlyIncomes_LoanApplications_LoanApplicationId",
                table: "BorrowerMonthlyIncomes",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ConsentDetails_LoanApplications_LoanApplicationId",
                table: "ConsentDetails",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CreditAuthAgreements_LoanApplications_LoanApplicationId",
                table: "CreditAuthAgreements",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DeclarationBorrowereDemographicsInformations_LoanApplication~",
                table: "DeclarationBorrowereDemographicsInformations",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Declarations_LoanApplications_LoanApplicationId",
                table: "Declarations",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_LoanApplications_LoanApplicationId",
                table: "Expenses",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanDetails_LoanApplications_LoanApplicationId",
                table: "LoanDetails",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PersonalDetails_LoanApplications_LoanApplicationId",
                table: "PersonalDetails",
                column: "LoanApplicationId",
                principalTable: "LoanApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalDetails_LoanApplications_LoanApplicationId",
                table: "AdditionalDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AdditionalIncomes_LoanApplications_LoanApplicationId",
                table: "AdditionalIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerEmploymentInformations_LoanApplications_LoanApplicat~",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerMonthlyIncomes_LoanApplications_LoanApplicationId",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DropForeignKey(
                name: "FK_ConsentDetails_LoanApplications_LoanApplicationId",
                table: "ConsentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_CreditAuthAgreements_LoanApplications_LoanApplicationId",
                table: "CreditAuthAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_DeclarationBorrowereDemographicsInformations_LoanApplication~",
                table: "DeclarationBorrowereDemographicsInformations");

            migrationBuilder.DropForeignKey(
                name: "FK_Declarations_LoanApplications_LoanApplicationId",
                table: "Declarations");

            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_LoanApplications_LoanApplicationId",
                table: "Expenses");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanDetails_LoanApplications_LoanApplicationId",
                table: "LoanDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_PersonalDetails_LoanApplications_LoanApplicationId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_PersonalDetails_LoanApplicationId",
                table: "PersonalDetails");

            migrationBuilder.DropIndex(
                name: "IX_LoanDetails_LoanApplicationId",
                table: "LoanDetails");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_LoanApplicationId",
                table: "Expenses");

            migrationBuilder.DropIndex(
                name: "IX_Declarations_LoanApplicationId",
                table: "Declarations");

            migrationBuilder.DropIndex(
                name: "IX_DeclarationBorrowereDemographicsInformations_LoanApplication~",
                table: "DeclarationBorrowereDemographicsInformations");

            migrationBuilder.DropIndex(
                name: "IX_CreditAuthAgreements_LoanApplicationId",
                table: "CreditAuthAgreements");

            migrationBuilder.DropIndex(
                name: "IX_ConsentDetails_LoanApplicationId",
                table: "ConsentDetails");

            migrationBuilder.DropIndex(
                name: "IX_BorrowerMonthlyIncomes_LoanApplicationId",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DropIndex(
                name: "IX_BorrowerEmploymentInformations_LoanApplicationId",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalIncomes_LoanApplicationId",
                table: "AdditionalIncomes");

            migrationBuilder.DropIndex(
                name: "IX_AdditionalDetails_LoanApplicationId",
                table: "AdditionalDetails");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "PersonalDetails");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "LoanDetails");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "Declarations");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "DeclarationBorrowereDemographicsInformations");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "CreditAuthAgreements");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "ConsentDetails");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "BorrowerMonthlyIncomes");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "AdditionalIncomes");

            migrationBuilder.DropColumn(
                name: "LoanApplicationId",
                table: "AdditionalDetails");

            migrationBuilder.RenameColumn(
                name: "DeclarationsSection",
                table: "Declarations",
                newName: "declarationsSection");

            migrationBuilder.AddColumn<long>(
                name: "AdditionalDetailId",
                table: "LoanApplications",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_AdditionalDetailId",
                table: "LoanApplications",
                column: "AdditionalDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_AdditionalIncomeId",
                table: "LoanApplications",
                column: "AdditionalIncomeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ConsentDetailId",
                table: "LoanApplications",
                column: "ConsentDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CreditAuthAgreementId",
                table: "LoanApplications",
                column: "CreditAuthAgreementId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DeclarationBorrowereDemographicsInformation~",
                table: "LoanApplications",
                column: "DeclarationBorrowereDemographicsInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DeclarationId",
                table: "LoanApplications",
                column: "DeclarationId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ExpenseId",
                table: "LoanApplications",
                column: "ExpenseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_LoanDetailId",
                table: "LoanApplications",
                column: "LoanDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_PersonalDetailId",
                table: "LoanApplications",
                column: "PersonalDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_AdditionalDetails_AdditionalDetailId",
                table: "LoanApplications",
                column: "AdditionalDetailId",
                principalTable: "AdditionalDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_AdditionalIncomes_AdditionalIncomeId",
                table: "LoanApplications",
                column: "AdditionalIncomeId",
                principalTable: "AdditionalIncomes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_ConsentDetails_ConsentDetailId",
                table: "LoanApplications",
                column: "ConsentDetailId",
                principalTable: "ConsentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_CreditAuthAgreements_CreditAuthAgreementId",
                table: "LoanApplications",
                column: "CreditAuthAgreementId",
                principalTable: "CreditAuthAgreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DeclarationBorrowereDemographicsInformation~",
                table: "LoanApplications",
                column: "DeclarationBorrowereDemographicsInformationId",
                principalTable: "DeclarationBorrowereDemographicsInformations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Declarations_DeclarationId",
                table: "LoanApplications",
                column: "DeclarationId",
                principalTable: "Declarations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Expenses_ExpenseId",
                table: "LoanApplications",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_LoanDetails_LoanDetailId",
                table: "LoanApplications",
                column: "LoanDetailId",
                principalTable: "LoanDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_PersonalDetails_PersonalDetailId",
                table: "LoanApplications",
                column: "PersonalDetailId",
                principalTable: "PersonalDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
