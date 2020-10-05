using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddExpenseId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ExpenseId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_ExpenseId",
                table: "LoanApplications",
                column: "ExpenseId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_Expenses_ExpenseId",
                table: "LoanApplications",
                column: "ExpenseId",
                principalTable: "Expenses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_Expenses_ExpenseId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_ExpenseId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "ExpenseId",
                table: "LoanApplications");
        }
    }
}
