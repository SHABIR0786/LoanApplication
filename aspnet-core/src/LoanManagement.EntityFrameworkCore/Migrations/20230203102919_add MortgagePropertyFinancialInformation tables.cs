using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class addMortgagePropertyFinancialInformationtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MortgagePropertyFinancialInformations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                    MortgagePropertyFinancialInformationId = table.Column<int>(type: "int", nullable: true),
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
                    table.ForeignKey(
                        name: "FK_MortgagePropertyAdditionalFinancialInformations_MortgageProp~",
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
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7652));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7679));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7680));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7682));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7703));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7705));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7706));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7707));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7710));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7711));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7713));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7714));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(7715));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8020));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8030));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8031));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8033));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 15, 59, 18, 520, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageLoanOnAdditionalPropertyFinancialInformations_Mortga~",
                table: "MortgageLoanOnAdditionalPropertyFinancialInformations",
                column: "MortgagePropertyFinancialInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageLoanOnProperyFinancialInformations_MortgagePropertyF~",
                table: "MortgageLoanOnProperyFinancialInformations",
                column: "MortgagePropertyFinancialInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgagePropertyAdditionalFinancialInformations_MortgageProp~",
                table: "MortgagePropertyAdditionalFinancialInformations",
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
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2165));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2182));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2184));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2185));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2186));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2187));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2188));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2406));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2410));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2411));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2412));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 11, 0, 14, 463, DateTimeKind.Local).AddTicks(2455));
        }
    }
}
