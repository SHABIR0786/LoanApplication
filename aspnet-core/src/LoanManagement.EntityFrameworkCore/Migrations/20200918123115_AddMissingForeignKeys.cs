using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddMissingForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "AssetAndLiablityId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DetailsOfTransactionId",
                table: "LoanApplications",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_AssetAndLiablityId",
                table: "LoanApplications",
                column: "AssetAndLiablityId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_DetailsOfTransactionId",
                table: "LoanApplications",
                column: "DetailsOfTransactionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_AssetAndLiablities_AssetAndLiablityId",
                table: "LoanApplications",
                column: "AssetAndLiablityId",
                principalTable: "AssetAndLiablities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanApplications_DetailsOfTransactions_DetailsOfTransactionId",
                table: "LoanApplications",
                column: "DetailsOfTransactionId",
                principalTable: "DetailsOfTransactions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_AssetAndLiablities_AssetAndLiablityId",
                table: "LoanApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanApplications_DetailsOfTransactions_DetailsOfTransactionId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_AssetAndLiablityId",
                table: "LoanApplications");

            migrationBuilder.DropIndex(
                name: "IX_LoanApplications_DetailsOfTransactionId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "AssetAndLiablityId",
                table: "LoanApplications");

            migrationBuilder.DropColumn(
                name: "DetailsOfTransactionId",
                table: "LoanApplications");
        }
    }
}
