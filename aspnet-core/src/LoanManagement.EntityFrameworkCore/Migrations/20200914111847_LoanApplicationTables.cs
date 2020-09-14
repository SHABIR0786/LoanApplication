using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class LoanApplicationTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowerInformations");

            migrationBuilder.DropTable(
                name: "CoBorrowerEmploymentInformations");

            migrationBuilder.DropTable(
                name: "CoBorrowerInformations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowerEmploymentInformations",
                table: "BorrowerEmploymentInformations");

            migrationBuilder.RenameTable(
                name: "BorrowerEmploymentInformations",
                newName: "BorrowerEmploymentInformation");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowerEmploymentInformation",
                table: "BorrowerEmploymentInformation",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BorrowerInformation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    BorrowersName = table.Column<string>(maxLength: 100, nullable: false),
                    SocialSecurityNumber = table.Column<string>(maxLength: 100, nullable: true),
                    HomePhone = table.Column<string>(nullable: true),
                    DOB = table.Column<DateTime>(nullable: false),
                    YearsSchool = table.Column<int>(nullable: true),
                    Marital = table.Column<string>(nullable: true),
                    PresentAddress = table.Column<string>(nullable: true),
                    PresentAddressType = table.Column<string>(nullable: true),
                    PresentAddressNoOfYears = table.Column<int>(nullable: true),
                    MailingAddress = table.Column<string>(nullable: true),
                    FormerAddressModel = table.Column<string>(nullable: true),
                    FormerAddressType = table.Column<string>(nullable: true),
                    FormerAddressNoOfYears = table.Column<int>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowerInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MortgageTypes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 100, nullable: false),
                    TypeExplain = table.Column<string>(nullable: true),
                    AppliedFor = table.Column<string>(nullable: true),
                    AgencyCaseNumber = table.Column<string>(nullable: true),
                    LenderCaseNumber = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    InterestRate = table.Column<double>(nullable: false),
                    NumberOfMonths = table.Column<int>(nullable: true),
                    AmortizationType = table.Column<string>(nullable: true),
                    AmortizationTypeExplain = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MortgageTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PropertyInformation",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    NumberOfUnits = table.Column<string>(nullable: true),
                    LegalDescription = table.Column<string>(nullable: true),
                    YearBuilt = table.Column<string>(nullable: true),
                    PurposeOfLoan = table.Column<string>(nullable: true),
                    PurposeOfLoanExplain = table.Column<string>(nullable: true),
                    PropertyWillBe = table.Column<string>(nullable: true),
                    YearLotAcquired = table.Column<string>(nullable: true),
                    OriginalCost = table.Column<double>(nullable: false),
                    AmountExistingLiens = table.Column<double>(nullable: false),
                    PresentValueOfLot = table.Column<double>(nullable: false),
                    CostOfImprovements = table.Column<double>(nullable: false),
                    RefinanceYearAcquired = table.Column<string>(nullable: true),
                    RefinanceOriginalCost = table.Column<double>(nullable: false),
                    RefinanceAmountExistingLiens = table.Column<double>(nullable: false),
                    RefinancePurpose = table.Column<string>(nullable: true),
                    RefinanceImprovements = table.Column<string>(nullable: true),
                    RefinanceImprovementsExtras = table.Column<string>(nullable: true),
                    TitleHeldNames = table.Column<string>(nullable: true),
                    TitleHeldManner = table.Column<string>(nullable: true),
                    SourceOfPayment = table.Column<string>(nullable: true),
                    EstateWillHeldIn = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PropertyInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanApplications",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    MortgageTypeId = table.Column<long>(nullable: false),
                    PropertyInfoId = table.Column<long>(nullable: false),
                    BorrowerInfoId = table.Column<long>(nullable: false),
                    CoBorrowerInfoId = table.Column<long>(nullable: false),
                    BorrowerEmploymentInfoId = table.Column<long>(nullable: false),
                    CoBorrowerEmploymentInfoId = table.Column<long>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LoanApplications_BorrowerEmploymentInformation_BorrowerEmploymentInfoId",
                        column: x => x.BorrowerEmploymentInfoId,
                        principalTable: "BorrowerEmploymentInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanApplications_BorrowerInformation_BorrowerInfoId",
                        column: x => x.BorrowerInfoId,
                        principalTable: "BorrowerInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanApplications_BorrowerEmploymentInformation_CoBorrowerEmploymentInfoId",
                        column: x => x.CoBorrowerEmploymentInfoId,
                        principalTable: "BorrowerEmploymentInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanApplications_BorrowerInformation_CoBorrowerInfoId",
                        column: x => x.CoBorrowerInfoId,
                        principalTable: "BorrowerInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanApplications_MortgageTypes_MortgageTypeId",
                        column: x => x.MortgageTypeId,
                        principalTable: "MortgageTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanApplications_PropertyInformation_PropertyInfoId",
                        column: x => x.PropertyInfoId,
                        principalTable: "PropertyInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BorrowerEmploymentInfoId",
                table: "LoanApplications",
                column: "BorrowerEmploymentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_BorrowerInfoId",
                table: "LoanApplications",
                column: "BorrowerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CoBorrowerEmploymentInfoId",
                table: "LoanApplications",
                column: "CoBorrowerEmploymentInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_CoBorrowerInfoId",
                table: "LoanApplications",
                column: "CoBorrowerInfoId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_MortgageTypeId",
                table: "LoanApplications",
                column: "MortgageTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoanApplications_PropertyInfoId",
                table: "LoanApplications",
                column: "PropertyInfoId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanApplications");

            migrationBuilder.DropTable(
                name: "BorrowerInformation");

            migrationBuilder.DropTable(
                name: "MortgageTypes");

            migrationBuilder.DropTable(
                name: "PropertyInformation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BorrowerEmploymentInformation",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.RenameTable(
                name: "BorrowerEmploymentInformation",
                newName: "BorrowerEmploymentInformations");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BorrowerEmploymentInformations",
                table: "BorrowerEmploymentInformations",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "BorrowerInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowersName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FormerAddressModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormerAddressNoOfYears = table.Column<int>(type: "int", nullable: true),
                    FormerAddressType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    MailingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Marital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PresentAddressNoOfYears = table.Column<int>(type: "int", nullable: true),
                    PresentAddressType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SocialSecurityNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    YearsSchool = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowerInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoBorrowerEmploymentInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoBusinessPhone1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoBusinessPhone2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoBusinessPhone3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoDateFromTo2 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoDateFromTo3 = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoEmployersAddress1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CoEmployersAddress2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CoEmployersAddress3 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CoEmployersName1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoEmployersName2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoEmployersName3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoIsSelfEmployer1 = table.Column<bool>(type: "bit", nullable: false),
                    CoIsSelfEmployer2 = table.Column<bool>(type: "bit", nullable: false),
                    CoIsSelfEmployer3 = table.Column<bool>(type: "bit", nullable: false),
                    CoMonthlyIncome2 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CoMonthlyIncome3 = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CoPosition1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoPosition2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoPosition3 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoYearInThisLineOfWork1 = table.Column<int>(type: "int", nullable: true),
                    CoYearOnThisJob1 = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoBorrowerEmploymentInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoBorrowerInformations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoBorrowersName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CoDOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CoFormerAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoFormerAddressNoOfYears = table.Column<int>(type: "int", nullable: true),
                    CoFormerAddressType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoHomePhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoMailingAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoMarital = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoPresentAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoPresentAddressNoOfYears = table.Column<int>(type: "int", nullable: true),
                    CoPresentAddressType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CoSocialSecurityNumber = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CoYearsSchool = table.Column<int>(type: "int", nullable: true),
                    CreationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoBorrowerInformations", x => x.Id);
                });
        }
    }
}
