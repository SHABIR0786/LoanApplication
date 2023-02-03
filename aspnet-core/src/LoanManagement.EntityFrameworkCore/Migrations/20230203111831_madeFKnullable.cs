using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class madeFKnullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationAdditionalEmploymentDetails_MortgageAppli~",
                table: "MortgageApplicationAdditionalEmploymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationAdditionalEmploymentIncomeDetails_Mortgag~",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationAlternateNames_MortgageApplicationPersona~",
                table: "MortgageApplicationAlternateNames");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationContactInformation_MortgageApplicationPer~",
                table: "MortgageApplicationContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationCurrentAddresses_MortgageApplicationPerso~",
                table: "MortgageApplicationCurrentAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationEmploymentDetails_MortgageApplicationPers~",
                table: "MortgageApplicationEmploymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationEmploymentIncomeDetails_MortgageApplicati~",
                table: "MortgageApplicationEmploymentIncomeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationFormerAddresses_MortgageApplicationPerson~",
                table: "MortgageApplicationFormerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationIncomeSources_MortgageApplicationPersonal~",
                table: "MortgageApplicationIncomeSources");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationMailingAddresses_MortgageApplicationPerso~",
                table: "MortgageApplicationMailingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationOtherBorrowers_MortgageApplicationPersona~",
                table: "MortgageApplicationOtherBorrowers");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationPersonalInformation_MortgageApplications_~",
                table: "MortgageApplicationPersonalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationPreviousEmploymentDetails_MortgageApplica~",
                table: "MortgageApplicationPreviousEmploymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationSources_MortgageApplicationIncomeSources_~",
                table: "MortgageApplicationSources");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationTypeOfCredits_MortgageApplicationPersonal~",
                table: "MortgageApplicationTypeOfCredits");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationTypeOfCredits",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IncomeSourceId",
                table: "MortgageApplicationSources",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationPreviousEmploymentDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MortgageApplicationId",
                table: "MortgageApplicationPersonalInformation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationOtherBorrowers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationMailingAddresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationIncomeSources",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationFormerAddresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EmploymentDetailId",
                table: "MortgageApplicationEmploymentIncomeDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationEmploymentDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationCurrentAddresses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationContactInformation",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationAlternateNames",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "AdditionalEmploymentDetailId",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(138));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(152));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(154));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(155));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(164));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(165));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(167));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(168));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(169));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(170));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(172));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(173));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(363));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(368));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(369));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(370));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 16, 48, 30, 311, DateTimeKind.Local).AddTicks(400));

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationAdditionalEmploymentDetails_MortgageAppli~",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationAdditionalEmploymentIncomeDetails_Mortgag~",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                column: "AdditionalEmploymentDetailId",
                principalTable: "MortgageApplicationAdditionalEmploymentDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationAlternateNames_MortgageApplicationPersona~",
                table: "MortgageApplicationAlternateNames",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationContactInformation_MortgageApplicationPer~",
                table: "MortgageApplicationContactInformation",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationCurrentAddresses_MortgageApplicationPerso~",
                table: "MortgageApplicationCurrentAddresses",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationEmploymentDetails_MortgageApplicationPers~",
                table: "MortgageApplicationEmploymentDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationEmploymentIncomeDetails_MortgageApplicati~",
                table: "MortgageApplicationEmploymentIncomeDetails",
                column: "EmploymentDetailId",
                principalTable: "MortgageApplicationEmploymentDetails",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationFormerAddresses_MortgageApplicationPerson~",
                table: "MortgageApplicationFormerAddresses",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationIncomeSources_MortgageApplicationPersonal~",
                table: "MortgageApplicationIncomeSources",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationMailingAddresses_MortgageApplicationPerso~",
                table: "MortgageApplicationMailingAddresses",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationOtherBorrowers_MortgageApplicationPersona~",
                table: "MortgageApplicationOtherBorrowers",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationPersonalInformation_MortgageApplications_~",
                table: "MortgageApplicationPersonalInformation",
                column: "MortgageApplicationId",
                principalTable: "MortgageApplications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationPreviousEmploymentDetails_MortgageApplica~",
                table: "MortgageApplicationPreviousEmploymentDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationSources_MortgageApplicationIncomeSources_~",
                table: "MortgageApplicationSources",
                column: "IncomeSourceId",
                principalTable: "MortgageApplicationIncomeSources",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationTypeOfCredits_MortgageApplicationPersonal~",
                table: "MortgageApplicationTypeOfCredits",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationAdditionalEmploymentDetails_MortgageAppli~",
                table: "MortgageApplicationAdditionalEmploymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationAdditionalEmploymentIncomeDetails_Mortgag~",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationAlternateNames_MortgageApplicationPersona~",
                table: "MortgageApplicationAlternateNames");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationContactInformation_MortgageApplicationPer~",
                table: "MortgageApplicationContactInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationCurrentAddresses_MortgageApplicationPerso~",
                table: "MortgageApplicationCurrentAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationEmploymentDetails_MortgageApplicationPers~",
                table: "MortgageApplicationEmploymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationEmploymentIncomeDetails_MortgageApplicati~",
                table: "MortgageApplicationEmploymentIncomeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationFormerAddresses_MortgageApplicationPerson~",
                table: "MortgageApplicationFormerAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationIncomeSources_MortgageApplicationPersonal~",
                table: "MortgageApplicationIncomeSources");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationMailingAddresses_MortgageApplicationPerso~",
                table: "MortgageApplicationMailingAddresses");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationOtherBorrowers_MortgageApplicationPersona~",
                table: "MortgageApplicationOtherBorrowers");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationPersonalInformation_MortgageApplications_~",
                table: "MortgageApplicationPersonalInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationPreviousEmploymentDetails_MortgageApplica~",
                table: "MortgageApplicationPreviousEmploymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationSources_MortgageApplicationIncomeSources_~",
                table: "MortgageApplicationSources");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationTypeOfCredits_MortgageApplicationPersonal~",
                table: "MortgageApplicationTypeOfCredits");

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationTypeOfCredits",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "IncomeSourceId",
                table: "MortgageApplicationSources",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationPreviousEmploymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MortgageApplicationId",
                table: "MortgageApplicationPersonalInformation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationOtherBorrowers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationMailingAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationIncomeSources",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationFormerAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EmploymentDetailId",
                table: "MortgageApplicationEmploymentIncomeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationEmploymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationCurrentAddresses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationContactInformation",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationAlternateNames",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AdditionalEmploymentDetailId",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonalInformationId",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8437));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8450));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8452));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8453));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8454));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8456));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8457));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8458));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8460));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8462));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8463));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8464));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8466));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8699));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8707));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8709));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8710));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 35, 52, 383, DateTimeKind.Local).AddTicks(8747));

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationAdditionalEmploymentDetails_MortgageAppli~",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationAdditionalEmploymentIncomeDetails_Mortgag~",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                column: "AdditionalEmploymentDetailId",
                principalTable: "MortgageApplicationAdditionalEmploymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationAlternateNames_MortgageApplicationPersona~",
                table: "MortgageApplicationAlternateNames",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationContactInformation_MortgageApplicationPer~",
                table: "MortgageApplicationContactInformation",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationCurrentAddresses_MortgageApplicationPerso~",
                table: "MortgageApplicationCurrentAddresses",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationEmploymentDetails_MortgageApplicationPers~",
                table: "MortgageApplicationEmploymentDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationEmploymentIncomeDetails_MortgageApplicati~",
                table: "MortgageApplicationEmploymentIncomeDetails",
                column: "EmploymentDetailId",
                principalTable: "MortgageApplicationEmploymentDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationFormerAddresses_MortgageApplicationPerson~",
                table: "MortgageApplicationFormerAddresses",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationIncomeSources_MortgageApplicationPersonal~",
                table: "MortgageApplicationIncomeSources",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationMailingAddresses_MortgageApplicationPerso~",
                table: "MortgageApplicationMailingAddresses",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationOtherBorrowers_MortgageApplicationPersona~",
                table: "MortgageApplicationOtherBorrowers",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationPersonalInformation_MortgageApplications_~",
                table: "MortgageApplicationPersonalInformation",
                column: "MortgageApplicationId",
                principalTable: "MortgageApplications",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationPreviousEmploymentDetails_MortgageApplica~",
                table: "MortgageApplicationPreviousEmploymentDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationSources_MortgageApplicationIncomeSources_~",
                table: "MortgageApplicationSources",
                column: "IncomeSourceId",
                principalTable: "MortgageApplicationIncomeSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationTypeOfCredits_MortgageApplicationPersonal~",
                table: "MortgageApplicationTypeOfCredits",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
