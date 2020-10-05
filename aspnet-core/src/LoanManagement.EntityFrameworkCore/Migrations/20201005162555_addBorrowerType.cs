using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class addBorrowerType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BorrowerTypeId",
                table: "Borrowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PersonalDetailId",
                table: "Borrowers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Borrowers_BorrowerTypeId",
                table: "Borrowers",
                column: "BorrowerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Borrowers_BorrowerTypes_BorrowerTypeId",
                table: "Borrowers",
                column: "BorrowerTypeId",
                principalTable: "BorrowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Borrowers_BorrowerTypes_BorrowerTypeId",
                table: "Borrowers");

            migrationBuilder.DropIndex(
                name: "IX_Borrowers_BorrowerTypeId",
                table: "Borrowers");

            migrationBuilder.DropColumn(
                name: "BorrowerTypeId",
                table: "Borrowers");

            migrationBuilder.DropColumn(
                name: "PersonalDetailId",
                table: "Borrowers");
        }
    }
}
