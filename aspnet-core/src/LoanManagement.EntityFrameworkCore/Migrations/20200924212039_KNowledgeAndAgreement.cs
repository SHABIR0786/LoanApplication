using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class KNowledgeAndAgreement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AcknowledgementAndAgreements",
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
                    Signature = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    BorrowerTypeId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AcknowledgementAndAgreements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AcknowledgementAndAgreements_BorrowerType_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "BorrowerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Declarations",
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
                    IsOutstandingJudgmentsAgainstYou = table.Column<string>(nullable: true),
                    IsDeclaredBankruptWithin7Years = table.Column<string>(nullable: true),
                    IsPropertyForeClosedWithin7Years = table.Column<string>(nullable: true),
                    IsPartyLawsuit = table.Column<string>(nullable: true),
                    IsObligatedOnAnyLoan = table.Column<string>(nullable: true),
                    IsPresentlyDelinquentOrInDefaultFederal = table.Column<string>(nullable: true),
                    IsObligatedToPayOrChildSupport = table.Column<string>(nullable: true),
                    IsAnyPartPaymentBorrowed = table.Column<string>(nullable: true),
                    IsCoMakerOrEndorserOnANote = table.Column<string>(nullable: true),
                    IsUsCitizen = table.Column<string>(nullable: true),
                    IsPermenentResidentAlien = table.Column<string>(nullable: true),
                    IsIntendToOccuppyTheProperty = table.Column<string>(nullable: true),
                    IsOwnedPropertyLastThreeYears = table.Column<string>(nullable: true),
                    WhatTypeOfPropertyYouOwned = table.Column<string>(nullable: true),
                    HowYouHoldTitleHome = table.Column<string>(nullable: true),
                    BorrowerTypeId = table.Column<int>(nullable: false),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Declarations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Declarations_BorrowerType_BorrowerTypeId",
                        column: x => x.BorrowerTypeId,
                        principalTable: "BorrowerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InformationForGovermentMonitoringPurposes",
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
                    InterviewHeldedThrough = table.Column<string>(nullable: true),
                    LoanOriginatorsSignature = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    LoanOriginatorsName = table.Column<string>(nullable: true),
                    LoanOriginatorIdentifier = table.Column<string>(nullable: true),
                    LoanOriginatorsPhoneNumber = table.Column<string>(nullable: true),
                    LoanOriginationCompanysName = table.Column<string>(nullable: true),
                    LoanOriginationCompanyIdentifier = table.Column<string>(nullable: true),
                    LoanOriginationCompanysAddress = table.Column<string>(nullable: true),
                    AgencyCaseNumber = table.Column<int>(nullable: true),
                    LenderCaseNumber = table.Column<int>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationForGovermentMonitoringPurposes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InformationForGovermentMonitoringPurposeBorrowerAndCos",
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
                    LoanOriginatorsSignature = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: true),
                    LoanOriginatorsName = table.Column<string>(nullable: true),
                    LoanOriginatorIdentifier = table.Column<string>(nullable: true),
                    LoanOriginatorsPhoneNumber = table.Column<string>(nullable: true),
                    LoanOriginationCompanysName = table.Column<string>(nullable: true),
                    LoanOriginationCompanyIdentifier = table.Column<string>(nullable: true),
                    LoanOriginationCompanysAddress = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true),
                    BorrowerTypeId = table.Column<int>(nullable: false),
                    InformationForGovermentMonitoringPurposeId = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InformationForGovermentMonitoringPurposeBorrowerAndCos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InformationForGovermentMonitoringPurposeBorrowerAndCos_Borro~",
                        column: x => x.BorrowerTypeId,
                        principalTable: "BorrowerType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InformationForGovermentMonitoringPurposeBorrowerAndCos_Infor~",
                        column: x => x.InformationForGovermentMonitoringPurposeId,
                        principalTable: "InformationForGovermentMonitoringPurposes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 14, 20, 38, 260, DateTimeKind.Local).AddTicks(3755));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 14, 20, 38, 264, DateTimeKind.Local).AddTicks(3937));

            migrationBuilder.CreateIndex(
                name: "IX_AcknowledgementAndAgreements_BorrowerTypeId",
                table: "AcknowledgementAndAgreements",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Declarations_BorrowerTypeId",
                table: "Declarations",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationForGovermentMonitoringPurposeBorrowerAndCos_Borro~",
                table: "InformationForGovermentMonitoringPurposeBorrowerAndCos",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_InformationForGovermentMonitoringPurposeBorrowerAndCos_Infor~",
                table: "InformationForGovermentMonitoringPurposeBorrowerAndCos",
                column: "InformationForGovermentMonitoringPurposeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AcknowledgementAndAgreements");

            migrationBuilder.DropTable(
                name: "Declarations");

            migrationBuilder.DropTable(
                name: "InformationForGovermentMonitoringPurposeBorrowerAndCos");

            migrationBuilder.DropTable(
                name: "InformationForGovermentMonitoringPurposes");

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 12, 4, 20, 340, DateTimeKind.Local).AddTicks(7072));

            migrationBuilder.UpdateData(
                table: "HousingExpenseType",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2020, 9, 24, 12, 4, 20, 343, DateTimeKind.Local).AddTicks(7974));
        }
    }
}
