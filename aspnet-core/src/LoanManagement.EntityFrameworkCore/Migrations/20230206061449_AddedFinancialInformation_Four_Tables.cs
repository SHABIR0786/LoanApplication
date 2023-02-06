using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class AddedFinancialInformation_Four_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MortgagePropertyAdditionalFinancialInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    street = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    unit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    state = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    zip = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    propertyValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    intendedOccupancy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    monthlyInsurance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    monthlyRentalIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    netMonthlyRentalIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgagePropertyAdditionalFinancialInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgagePropertyAdditionalFinancialInformations_MortgageAppl~",
                        column: x => x.PersonalInformationId,
                        principalTable: "MortgageApplicationPersonalInformation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MortgagePropertyFinancialInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    street = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    unit = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    state = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    zip = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    propertyValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    intendedOccupancy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    monthlyInsurance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    monthlyRentalIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    netMonthlyRentalIncome = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgagePropertyFinancialInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgagePropertyFinancialInformations_MortgageApplicationPer~",
                        column: x => x.PersonalInformationId,
                        principalTable: "MortgageApplicationPersonalInformation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    creditorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    accountNumber = table.Column<long>(type: "bigint", nullable: false),
                    monthlyMortagagePayment = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    unpaidBalance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creditLimit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    isApplied = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    MortgagePropertyFinancialInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageLoanOnAdditionalPropertyFinancialInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageLoanOnAdditionalPropertyFinancialInformations_Mortga~",
                        column: x => x.MortgagePropertyFinancialInformationId,
                        principalTable: "MortgagePropertyFinancialInformations",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MortgageLoanOnProperyFinancialInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    creditorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    accountNumber = table.Column<long>(type: "bigint", nullable: false),
                    monthlyMortagagePayment = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    unpaidBalance = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    creditLimit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    isApplied = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    MortgagePropertyFinancialInformationId = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageLoanOnProperyFinancialInformations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageLoanOnProperyFinancialInformations_MortgagePropertyF~",
                        column: x => x.MortgagePropertyFinancialInformationId,
                        principalTable: "MortgagePropertyFinancialInformations",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9392));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9410));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9413));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9414));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9423));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9425));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9428));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9429));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9431));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9432));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9434));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9515));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9741));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9748));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9749));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9751));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 11, 44, 47, 961, DateTimeKind.Local).AddTicks(9785));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageLoanOnAdditionalPropertyFinancialInformations_Mortga~",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                column: "MortgagePropertyFinancialInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageLoanOnProperyFinancialInformations_MortgagePropertyF~",
                table: "MortgageLoanOnProperyFinancialInformations",
                column: "MortgagePropertyFinancialInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgagePropertyAdditionalFinancialInformations_PersonalInfo~",
                table: "MortgagePropertyAdditionalFinancialInformations",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgagePropertyFinancialInformations_PersonalInformationId",
                table: "MortgagePropertyFinancialInformations",
                column: "PersonalInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MortgageLoanOnAdditionalPropertyFinancialInformations");

            migrationBuilder.DropTable(
                name: "MortgageLoanOnProperyFinancialInformations");

            migrationBuilder.DropTable(
                name: "MortgagePropertyAdditionalFinancialInformations");

            migrationBuilder.DropTable(
                name: "MortgagePropertyFinancialInformations");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1657));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1670));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1672));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1673));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1675));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1676));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1677));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1679));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1680));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1681));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1683));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1684));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1915));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1920));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1921));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1923));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 18, 35, 47, 695, DateTimeKind.Local).AddTicks(1959));
        }
    }
}
