using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AssetAndLiablity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AutomobileOwned",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "JobRelatedExpense",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "NetWorth",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "OtherAssests",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "PaymentMethod1",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "PaymentMethod2",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "PaymentMethod3",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "PaymentMethod4",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "PaymentMethod5",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "PaymentMethod6",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "SeparateMaintenancePaymentsOwedTo",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "StockBondCompanyDescription",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "TotalAssests",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "TotalLiablities",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "TotalMoneyPayment",
                table: "AssetAndLiablities");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnpaidBalance5",
                table: "AssetAndLiablities",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnpaidBalance2",
                table: "AssetAndLiablities",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(65,30)");

            migrationBuilder.AddColumn<decimal>(
                name: "AutomobileAmount",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutomobileMake",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AutomobileYear",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "JobRelatedExpenses",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "JobRelatedExpensesPayment",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaintenancePayment",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MaintenancePaymentOwedTo",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPayment1",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPayment2",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPayment3",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPayment4",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPayment5",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MonthlyPayment6",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsLeft1",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsLeft2",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsLeft3",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsLeft4",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsLeft5",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MonthsLeft6",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OtherAssets",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OtherAssetsAmount",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "StockAmount",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockCompanyDescription",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockCompanyName",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockCompanyNumber",
                table: "AssetAndLiablities",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "OtherIncome",
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
                    BorrowerTypeId = table.Column<int>(nullable: false),
                    Type = table.Column<string>(nullable: true),
                    MonthlyAmount = table.Column<decimal>(nullable: false),
                    LoanApplicationId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OtherIncome", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OtherIncome_LoanApplications_LoanApplicationId",
                        column: x => x.LoanApplicationId,
                        principalTable: "LoanApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 15, 14, 23, 437, DateTimeKind.Local).AddTicks(3467));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 15, 14, 23, 439, DateTimeKind.Local).AddTicks(2627));

            migrationBuilder.CreateIndex(
                name: "IX_OtherIncome_LoanApplicationId",
                table: "OtherIncome",
                column: "LoanApplicationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OtherIncome");

            migrationBuilder.DropColumn(
                name: "AutomobileAmount",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "AutomobileMake",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "AutomobileYear",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "JobRelatedExpenses",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "JobRelatedExpensesPayment",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MaintenancePayment",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MaintenancePaymentOwedTo",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthlyPayment1",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthlyPayment2",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthlyPayment3",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthlyPayment4",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthlyPayment5",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthlyPayment6",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthsLeft1",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthsLeft2",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthsLeft3",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthsLeft4",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthsLeft5",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "MonthsLeft6",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "OtherAssets",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "OtherAssetsAmount",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "StockAmount",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "StockCompanyDescription",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "StockCompanyName",
                table: "AssetAndLiablities");

            migrationBuilder.DropColumn(
                name: "StockCompanyNumber",
                table: "AssetAndLiablities");

            migrationBuilder.AlterColumn<decimal>(
                name: "UnpaidBalance5",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "UnpaidBalance2",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "AutomobileOwned",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "JobRelatedExpense",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "NetWorth",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "OtherAssests",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod1",
                table: "AssetAndLiablities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod2",
                table: "AssetAndLiablities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod3",
                table: "AssetAndLiablities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod4",
                table: "AssetAndLiablities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod5",
                table: "AssetAndLiablities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod6",
                table: "AssetAndLiablities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "SeparateMaintenancePaymentsOwedTo",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StockBondCompanyDescription",
                table: "AssetAndLiablities",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalAssests",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalLiablities",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalMoneyPayment",
                table: "AssetAndLiablities",
                type: "decimal(65,30)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 20, 6, 29, 42, 572, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 20, 6, 29, 42, 573, DateTimeKind.Local).AddTicks(3611));
        }
    }
}
