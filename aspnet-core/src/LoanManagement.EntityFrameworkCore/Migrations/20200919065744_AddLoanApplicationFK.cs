using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddLoanApplicationFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MonthlyIncomeAndCombinedHousingExpenseId",
                table: "LoanApplications",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "GrossMonthlyIncome",
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
                    BasicIncome = table.Column<decimal>(nullable: false),
                    Overtime = table.Column<decimal>(nullable: false),
                    Bonuses = table.Column<decimal>(nullable: false),
                    Commissions = table.Column<decimal>(nullable: false),
                    DividendAndInterest = table.Column<decimal>(nullable: false),
                    NetRentalIncome = table.Column<decimal>(nullable: false),
                    Other = table.Column<decimal>(nullable: false),
                    BorrowerTypeId = table.Column<int>(nullable: false),
                    LoanApplicationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrossMonthlyIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrossMonthlyIncome_BorrowerType_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "BorrowerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GrossMonthlyIncome_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HousingExpenseType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HousingExpenseType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CombinedMonthlyHousingExpense",
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
                    Rental = table.Column<decimal>(nullable: false),
                    FirstMortage = table.Column<decimal>(nullable: false),
                    OtherMortage = table.Column<decimal>(nullable: false),
                    HazardInsurance = table.Column<decimal>(nullable: false),
                    RealEstateTaxes = table.Column<decimal>(nullable: false),
                    MortgageInsurance = table.Column<decimal>(nullable: false),
                    HomeOwnerAssociationDue = table.Column<decimal>(nullable: false),
                    Other = table.Column<decimal>(nullable: false),
                    HousingExpenseTypeId = table.Column<int>(nullable: false),
                    LoanApplicationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CombinedMonthlyHousingExpense", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CombinedMonthlyHousingExpense_HousingExpenseType_HousingExpe~",
                        column: x => x.HousingExpenseTypeId,
                        principalTable: "HousingExpenseType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CombinedMonthlyHousingExpense_LoanApplications_LoanApplicati~",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HousingExpenseType",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
                values: new object[] { 1, new DateTime(2020, 9, 19, 11, 57, 43, 633, DateTimeKind.Local).AddTicks(2668), null, null, null, false, null, null, "Present" });

            migrationBuilder.InsertData(
                table: "HousingExpenseType",
                columns: new[] { "Id", "CreationTime", "CreatorUserId", "DeleterUserId", "DeletionTime", "IsDeleted", "LastModificationTime", "LastModifierUserId", "Name" },
                values: new object[] { 2, new DateTime(2020, 9, 19, 11, 57, 43, 633, DateTimeKind.Local).AddTicks(6646), null, null, null, false, null, null, "Proposed" });

            migrationBuilder.CreateIndex(
                name: "IX_CombinedMonthlyHousingExpense_HousingExpenseTypeId",
                table: "CombinedMonthlyHousingExpense",
                column: "HousingExpenseTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_CombinedMonthlyHousingExpense_LoanApplicationId",
                table: "CombinedMonthlyHousingExpense",
                column: "LoanApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_GrossMonthlyIncome_BorrowerTypeId",
                table: "GrossMonthlyIncome",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_GrossMonthlyIncome_LoanApplicationId",
                table: "GrossMonthlyIncome",
                column: "LoanApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CombinedMonthlyHousingExpense");

            migrationBuilder.DropTable(
                name: "GrossMonthlyIncome");

            migrationBuilder.DropTable(
                name: "HousingExpenseType");

            migrationBuilder.DropColumn(
                name: "MonthlyIncomeAndCombinedHousingExpenseId",
                table: "LoanApplications");
        }
    }
}
