using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class AddedMortgageApplicationDemographicInfo_DemographicInfoByFinancialInstitution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MortgageApplicaitonDempgraphicInfoByFinancialInstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsEthnicityByObservation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsGenderByObservation = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsRaceByObservation = table.Column<bool>(type: "tinyint(1)", nullable: true),
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
                    table.PrimaryKey("PK_MortgageApplicaitonDempgraphicInfoByFinancialInstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageApplicaitonDempgraphicInfoByFinancialInstitutions_Mo~",
                        column: x => x.PersonalInformationId,
                        principalTable: "MortgageApplicationPersonalInformation",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MortgageApplicationDemographicInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IsHispanicOrLatino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMexican = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsPuertoRican = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsCuban = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOtherHispanicOrLatino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    Origin = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsNotHispanicOrLatino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CanNotProvideEthnicInfo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsAmericanIndianOrAlaskaNative = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    NameOfEnrolledOrPrincipalTribe = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsAsian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsAsianIndian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsChinese = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsFilipino = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsJapanese = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsKorean = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsVietnamese = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOtherAsian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    OtherAsianRace = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsBlackOrAfricanAmerican = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsNativeHawaiianOrOtherPacificIslander = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsNativeHawaiian = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsGuamanianOrChamorro = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsSamoan = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsOtherPacificIslander = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    OtherPacificIslanderRace = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsWhite = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CanNotProvideRaceInfo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsMale = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsFemale = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    CanNotProvideSexInfo = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    demographicInfoSource = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
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
                    table.PrimaryKey("PK_MortgageApplicationDemographicInformation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MortgageApplicationDemographicInformation_MortgageApplicatio~",
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
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4585));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4596));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4598));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4599));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4601));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4602));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4603));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4604));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4605));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4606));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4607));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4608));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4609));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4876));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4881));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4882));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4883));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 15, 18, 4, 45, DateTimeKind.Local).AddTicks(4913));

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicaitonDempgraphicInfoByFinancialInstitutions_Pe~",
                table: "MortgageApplicaitonDempgraphicInfoByFinancialInstitutions",
                column: "PersonalInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_MortgageApplicationDemographicInformation_PersonalInformatio~",
                table: "MortgageApplicationDemographicInformation",
                column: "PersonalInformationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MortgageApplicaitonDempgraphicInfoByFinancialInstitutions");

            migrationBuilder.DropTable(
                name: "MortgageApplicationDemographicInformation");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(987));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1003));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1004));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1005));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1012));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1015));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1016));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1019));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1021));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1022));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1204));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1209));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1210));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 6, 12, 1, 51, 76, DateTimeKind.Local).AddTicks(1247));
        }
    }
}
