using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class AddedMortgageApplicationLoanPropertyAddres_rentalIncome_gifts_mortgageLoansTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MortgageApplicationLoanPropertyAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    street = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    city = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    state = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    zip = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    country = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numberOfUnits = table.Column<int>(type: "int", nullable: true),
                    propertyValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
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
                    table.PrimaryKey("PK_MortgageApplicationLoanPropertyAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageApplicationLoanPropertyAddresses_MortgageApplication~",
                        column: x => x.PersonalInformationId,
                        principalTable: "MortgageApplicationPersonalInformation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MortgageApplicationLoanPropertyGiftsOrGrants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    assetType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    isDeposited = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    source = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    marketValue = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
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
                    table.PrimaryKey("PK_MortgageApplicationLoanPropertyGiftsOrGrants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageApplicationLoanPropertyGiftsOrGrants_MortgageApplica~",
                        column: x => x.PersonalInformationId,
                        principalTable: "MortgageApplicationPersonalInformation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    creditorName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    lienType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    monthlyPayment = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    loanAmount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    creditLimit = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
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
                    table.PrimaryKey("PK_MortgageApplicationLoanPropertyOtherNewMortgageLoans", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageApplicationLoanPropertyOtherNewMortgageLoans_Mortgag~",
                        column: x => x.PersonalInformationId,
                        principalTable: "MortgageApplicationPersonalInformation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MortgageApplicationLoanPropertyRentalIncomes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    PersonalInformationId = table.Column<int>(type: "int", nullable: true),
                    incomeType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
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
                    table.PrimaryKey("PK_MortgageApplicationLoanPropertyRentalIncomes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageApplicationLoanPropertyRentalIncomes_MortgageApplica~",
                        column: x => x.PersonalInformationId,
                        principalTable: "MortgageApplicationPersonalInformation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3472));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3486));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3487));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3488));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3489));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3490));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3491));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3493));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3494));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3495));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3496));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3497));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3499));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3675));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3678));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3679));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3680));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 53, 25, 719, DateTimeKind.Local).AddTicks(3791));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationLoanPropertyAddresses_PersonalInformation~",
                table: "MortgageApplicationLoanPropertyAddresses",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationLoanPropertyGiftsOrGrants_PersonalInforma~",
                table: "MortgageApplicationLoanPropertyGiftsOrGrants",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationLoanPropertyOtherNewMortgageLoans_Persona~",
                table: "MortgageApplicationLoanPropertyOtherNewMortgageLoans",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationLoanPropertyRentalIncomes_PersonalInforma~",
                table: "MortgageApplicationLoanPropertyRentalIncomes",
                column: "PersonalInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MortgageApplicationLoanPropertyAddresses");

            migrationBuilder.DropTable(
                name: "MortgageApplicationLoanPropertyGiftsOrGrants");

            migrationBuilder.DropTable(
                name: "MortgageApplicationLoanPropertyOtherNewMortgageLoans");

            migrationBuilder.DropTable(
                name: "MortgageApplicationLoanPropertyRentalIncomes");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(281));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(282));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(285));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(286));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(287));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(288));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(292));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(293));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(294));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(523));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(527));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(528));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(529));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 5, 14, 16, 31, 414, DateTimeKind.Local).AddTicks(560));
        }
    }
}
