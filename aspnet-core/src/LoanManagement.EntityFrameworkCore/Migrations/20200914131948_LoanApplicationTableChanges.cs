using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class LoanApplicationTableChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EstateWillHeldIn",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "RefinanceAmountExistingLiens",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "RefinanceImprovements",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "RefinanceImprovementsExtras",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "RefinanceOriginalCost",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "RefinancePurpose",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "RefinanceYearAcquired",
                table: "PropertyInformation");

            migrationBuilder.AddColumn<double>(
                name: "AmountExistingLiensRefinance",
                table: "PropertyInformation",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "EstateHeldIn",
                table: "PropertyInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImprovementCostRefinance",
                table: "PropertyInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImprovementsRefinance",
                table: "PropertyInformation",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OriginalCostRefinance",
                table: "PropertyInformation",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "PurposeOfRefinance",
                table: "PropertyInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "YearAcquiredRefinance",
                table: "PropertyInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AmountExistingLiensRefinance",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "EstateHeldIn",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "ImprovementCostRefinance",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "ImprovementsRefinance",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "OriginalCostRefinance",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "PurposeOfRefinance",
                table: "PropertyInformation");

            migrationBuilder.DropColumn(
                name: "YearAcquiredRefinance",
                table: "PropertyInformation");

            migrationBuilder.AddColumn<string>(
                name: "EstateWillHeldIn",
                table: "PropertyInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RefinanceAmountExistingLiens",
                table: "PropertyInformation",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "RefinanceImprovements",
                table: "PropertyInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefinanceImprovementsExtras",
                table: "PropertyInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "RefinanceOriginalCost",
                table: "PropertyInformation",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "RefinancePurpose",
                table: "PropertyInformation",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RefinanceYearAcquired",
                table: "PropertyInformation",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
