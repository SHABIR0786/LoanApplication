using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class changedTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationAdditionalEmployementDetails_MortgageAppl~",
                table: "MortgageApplicationAdditionalEmployementDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationAdditionalEmployementIncomeDetails_Mortga~",
                table: "MortgageApplicationAdditionalEmployementIncomeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationEmployementDetails_MortgageApplicationPer~",
                table: "MortgageApplicationEmployementDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationEmployementIncomeDetails_MortgageApplicat~",
                table: "MortgageApplicationEmployementIncomeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationPreviousEmployementDetails_MortgageApplic~",
                table: "MortgageApplicationPreviousEmployementDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationPreviousEmployementDetails",
                table: "MortgageApplicationPreviousEmployementDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationEmployementIncomeDetails",
                table: "MortgageApplicationEmployementIncomeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationEmployementDetails",
                table: "MortgageApplicationEmployementDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationAdditionalEmployementIncomeDetails",
                table: "MortgageApplicationAdditionalEmployementIncomeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationAdditionalEmployementDetails",
                table: "MortgageApplicationAdditionalEmployementDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationPreviousEmployementDetails",
                newName: "MortgageApplicationPreviousEmploymentDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationEmployementIncomeDetails",
                newName: "MortgageApplicationEmploymentIncomeDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationEmployementDetails",
                newName: "MortgageApplicationEmploymentDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationAdditionalEmployementIncomeDetails",
                newName: "MortgageApplicationAdditionalEmploymentIncomeDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationAdditionalEmployementDetails",
                newName: "MortgageApplicationAdditionalEmploymentDetails");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationPreviousEmployementDetails_PersonalInform~",
                table: "MortgageApplicationPreviousEmploymentDetails",
                newName: "IX_MortgageApplicationPreviousEmploymentDetails_PersonalInforma~");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationEmployementIncomeDetails_EmploymentDetail~",
                table: "MortgageApplicationEmploymentIncomeDetails",
                newName: "IX_MortgageApplicationEmploymentIncomeDetails_EmploymentDetailId");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationEmployementDetails_PersonalInformationId",
                table: "MortgageApplicationEmploymentDetails",
                newName: "IX_MortgageApplicationEmploymentDetails_PersonalInformationId");

            migrationBuilder.RenameColumn(
                name: "other",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "others");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationAdditionalEmployementIncomeDetails_Additi~",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "IX_MortgageApplicationAdditionalEmploymentIncomeDetails_Additio~");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationAdditionalEmployementDetails_PersonalInfo~",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "IX_MortgageApplicationAdditionalEmploymentDetails_PersonalInfor~");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationPreviousEmploymentDetails",
                table: "MortgageApplicationPreviousEmploymentDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationEmploymentIncomeDetails",
                table: "MortgageApplicationEmploymentIncomeDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationEmploymentDetails",
                table: "MortgageApplicationEmploymentDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationAdditionalEmploymentIncomeDetails",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationAdditionalEmploymentDetails",
                table: "MortgageApplicationAdditionalEmploymentDetails",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6925));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6946));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6947));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6948));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6949));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6953));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7129));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7133));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7135));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7136));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 20, 50, 598, DateTimeKind.Local).AddTicks(7168));

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
                name: "FK_MortgageApplicationPreviousEmploymentDetails_MortgageApplica~",
                table: "MortgageApplicationPreviousEmploymentDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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
                name: "FK_MortgageApplicationEmploymentDetails_MortgageApplicationPers~",
                table: "MortgageApplicationEmploymentDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationEmploymentIncomeDetails_MortgageApplicati~",
                table: "MortgageApplicationEmploymentIncomeDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_MortgageApplicationPreviousEmploymentDetails_MortgageApplica~",
                table: "MortgageApplicationPreviousEmploymentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationPreviousEmploymentDetails",
                table: "MortgageApplicationPreviousEmploymentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationEmploymentIncomeDetails",
                table: "MortgageApplicationEmploymentIncomeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationEmploymentDetails",
                table: "MortgageApplicationEmploymentDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationAdditionalEmploymentIncomeDetails",
                table: "MortgageApplicationAdditionalEmploymentIncomeDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MortgageApplicationAdditionalEmploymentDetails",
                table: "MortgageApplicationAdditionalEmploymentDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationPreviousEmploymentDetails",
                newName: "MortgageApplicationPreviousEmployementDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationEmploymentIncomeDetails",
                newName: "MortgageApplicationEmployementIncomeDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationEmploymentDetails",
                newName: "MortgageApplicationEmployementDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationAdditionalEmploymentIncomeDetails",
                newName: "MortgageApplicationAdditionalEmployementIncomeDetails");

            migrationBuilder.RenameTable(
                name: "MortgageApplicationAdditionalEmploymentDetails",
                newName: "MortgageApplicationAdditionalEmployementDetails");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationPreviousEmploymentDetails_PersonalInforma~",
                table: "MortgageApplicationPreviousEmployementDetails",
                newName: "IX_MortgageApplicationPreviousEmployementDetails_PersonalInform~");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationEmploymentIncomeDetails_EmploymentDetailId",
                table: "MortgageApplicationEmployementIncomeDetails",
                newName: "IX_MortgageApplicationEmployementIncomeDetails_EmploymentDetail~");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationEmploymentDetails_PersonalInformationId",
                table: "MortgageApplicationEmployementDetails",
                newName: "IX_MortgageApplicationEmployementDetails_PersonalInformationId");

            migrationBuilder.RenameColumn(
                name: "others",
                table: "MortgageApplicationAdditionalEmployementIncomeDetails",
                newName: "other");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationAdditionalEmploymentIncomeDetails_Additio~",
                table: "MortgageApplicationAdditionalEmployementIncomeDetails",
                newName: "IX_MortgageApplicationAdditionalEmployementIncomeDetails_Additi~");

            migrationBuilder.RenameIndex(
                name: "IX_MortgageApplicationAdditionalEmploymentDetails_PersonalInfor~",
                table: "MortgageApplicationAdditionalEmployementDetails",
                newName: "IX_MortgageApplicationAdditionalEmployementDetails_PersonalInfo~");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationPreviousEmployementDetails",
                table: "MortgageApplicationPreviousEmployementDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationEmployementIncomeDetails",
                table: "MortgageApplicationEmployementIncomeDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationEmployementDetails",
                table: "MortgageApplicationEmployementDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationAdditionalEmployementIncomeDetails",
                table: "MortgageApplicationAdditionalEmployementIncomeDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MortgageApplicationAdditionalEmployementDetails",
                table: "MortgageApplicationAdditionalEmployementDetails",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(57));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(73));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(75));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(76));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(77));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(78));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(79));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(80));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(81));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(82));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(83));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(84));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(86));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(284));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(289));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(290));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(291));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2023, 2, 3, 12, 17, 2, 808, DateTimeKind.Local).AddTicks(322));

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationAdditionalEmployementDetails_MortgageAppl~",
                table: "MortgageApplicationAdditionalEmployementDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationAdditionalEmployementIncomeDetails_Mortga~",
                table: "MortgageApplicationAdditionalEmployementIncomeDetails",
                column: "AdditionalEmploymentDetailId",
                principalTable: "MortgageApplicationAdditionalEmployementDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationEmployementDetails_MortgageApplicationPer~",
                table: "MortgageApplicationEmployementDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationEmployementIncomeDetails_MortgageApplicat~",
                table: "MortgageApplicationEmployementIncomeDetails",
                column: "EmploymentDetailId",
                principalTable: "MortgageApplicationEmployementDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MortgageApplicationPreviousEmployementDetails_MortgageApplic~",
                table: "MortgageApplicationPreviousEmployementDetails",
                column: "PersonalInformationId",
                principalTable: "MortgageApplicationPersonalInformation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
