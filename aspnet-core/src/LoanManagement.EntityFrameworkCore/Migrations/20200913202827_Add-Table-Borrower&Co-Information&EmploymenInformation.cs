using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddTableBorrowerCoInformationEmploymenInformation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BorrowerEmploymentInformations",
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
                    EmployersName1 = table.Column<string>(maxLength: 100, nullable: false),
                    EmployersAddress1 = table.Column<string>(maxLength: 100, nullable: true),
                    IsSelfEmployer1 = table.Column<bool>(nullable: false),
                    YearOnThisJob1 = table.Column<int>(nullable: true),
                    YearInThisLineOfWork1 = table.Column<int>(nullable: true),
                    Position1 = table.Column<string>(nullable: true),
                    BusinessPhone1 = table.Column<string>(nullable: true),
                    EmployersName2 = table.Column<string>(nullable: true),
                    EmployersAddress2 = table.Column<string>(maxLength: 100, nullable: true),
                    IsSelfEmployer2 = table.Column<bool>(nullable: false),
                    DateFromTo2 = table.Column<DateTime>(nullable: false),
                    MonthlyIncome2 = table.Column<decimal>(nullable: true),
                    Position2 = table.Column<string>(nullable: true),
                    BusinessPhone2 = table.Column<string>(nullable: true),
                    EmployersName3 = table.Column<string>(nullable: true),
                    EmployersAddress3 = table.Column<string>(maxLength: 100, nullable: true),
                    IsSelfEmployer3 = table.Column<bool>(nullable: false),
                    DateFromTo3 = table.Column<DateTime>(nullable: false),
                    MonthlyIncome3 = table.Column<decimal>(nullable: true),
                    Position3 = table.Column<string>(nullable: true),
                    BusinessPhone3 = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowerEmploymentInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BorrowerInformations",
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
                    table.PrimaryKey("PK_BorrowerInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoBorrowerEmploymentInformations",
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
                    CoEmployersName1 = table.Column<string>(maxLength: 100, nullable: false),
                    CoEmployersAddress1 = table.Column<string>(maxLength: 100, nullable: true),
                    CoIsSelfEmployer1 = table.Column<bool>(nullable: false),
                    CoYearOnThisJob1 = table.Column<int>(nullable: true),
                    CoYearInThisLineOfWork1 = table.Column<int>(nullable: true),
                    CoPosition1 = table.Column<string>(nullable: true),
                    CoBusinessPhone1 = table.Column<string>(nullable: true),
                    CoEmployersName2 = table.Column<string>(nullable: true),
                    CoEmployersAddress2 = table.Column<string>(maxLength: 100, nullable: true),
                    CoIsSelfEmployer2 = table.Column<bool>(nullable: false),
                    CoDateFromTo2 = table.Column<DateTime>(nullable: false),
                    CoMonthlyIncome2 = table.Column<decimal>(nullable: true),
                    CoPosition2 = table.Column<string>(nullable: true),
                    CoBusinessPhone2 = table.Column<string>(nullable: true),
                    CoEmployersName3 = table.Column<string>(nullable: true),
                    CoEmployersAddress3 = table.Column<string>(maxLength: 100, nullable: true),
                    CoIsSelfEmployer3 = table.Column<bool>(nullable: false),
                    CoDateFromTo3 = table.Column<DateTime>(nullable: false),
                    CoMonthlyIncome3 = table.Column<decimal>(nullable: true),
                    CoPosition3 = table.Column<string>(nullable: true),
                    CoBusinessPhone3 = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoBorrowerEmploymentInformations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoBorrowerInformations",
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
                    CoBorrowersName = table.Column<string>(maxLength: 100, nullable: false),
                    CoSocialSecurityNumber = table.Column<string>(maxLength: 100, nullable: true),
                    CoHomePhone = table.Column<string>(nullable: true),
                    CoDOB = table.Column<DateTime>(nullable: false),
                    CoYearsSchool = table.Column<int>(nullable: true),
                    CoMarital = table.Column<string>(nullable: true),
                    CoPresentAddress = table.Column<string>(nullable: true),
                    CoPresentAddressType = table.Column<string>(nullable: true),
                    CoPresentAddressNoOfYears = table.Column<int>(nullable: true),
                    CoMailingAddress = table.Column<string>(nullable: true),
                    CoFormerAddress = table.Column<string>(nullable: true),
                    CoFormerAddressType = table.Column<string>(nullable: true),
                    CoFormerAddressNoOfYears = table.Column<int>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoBorrowerInformations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BorrowerEmploymentInformations");

            migrationBuilder.DropTable(
                name: "BorrowerInformations");

            migrationBuilder.DropTable(
                name: "CoBorrowerEmploymentInformations");

            migrationBuilder.DropTable(
                name: "CoBorrowerInformations");
        }
    }
}
