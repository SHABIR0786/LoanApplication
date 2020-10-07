using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddManualAssetEntry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManualAssetEntries",
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
                    Type = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    CashValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Address2 = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    ZipCode = table.Column<string>(maxLength: 9, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    BankName = table.Column<string>(nullable: true),
                    PropertyStatus = table.Column<string>(nullable: true),
                    PropertyIsUsedAs = table.Column<string>(nullable: true),
                    PropertyType = table.Column<string>(nullable: true),
                    PresentMarketValue = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    OutstandingMortgageBalance = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    MonthlyMortgagePayment = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PurchasePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    GrossRentalIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TaxesInsuranceAndOther = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    LoanApplicationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManualAssetEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManualAssetEntries_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StockAndBond",
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
                    CompanyName = table.Column<string>(nullable: true),
                    AccountNumber = table.Column<string>(nullable: true),
                    Value = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ManualAssetEntryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockAndBond", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StockAndBond_ManualAssetEntries_ManualAssetEntryId",
                        column: x => x.ManualAssetEntryId,
                        principalTable: "ManualAssetEntries",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ManualAssetEntries_LoanApplicationId",
                table: "ManualAssetEntries",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_StockAndBond_ManualAssetEntryId",
                table: "StockAndBond",
                column: "ManualAssetEntryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StockAndBond");

            migrationBuilder.DropTable(
                name: "ManualAssetEntries");
        }
    }
}
