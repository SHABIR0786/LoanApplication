using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanManagement.Migrations
{
    public partial class remove_adminuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminLoanapplicationdocuments_AdminUsers_UserId",
                table: "AdminLoanapplicationdocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminLoandetails_AdminUsers_UserId",
                table: "AdminLoandetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserenableddevices_AdminUsers_UserId",
                table: "AdminUserenableddevices");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsernotifications_AdminNotificationtypes_NotificationTy~",
                table: "AdminUsernotifications");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsernotifications_AdminUsers_UserId",
                table: "AdminUsernotifications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminUsers",
                table: "AdminUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminUsernotifications",
                table: "AdminUsernotifications");

            migrationBuilder.RenameTable(
                name: "AdminUsers",
                newName: "AdminUser");

            migrationBuilder.RenameTable(
                name: "AdminUsernotifications",
                newName: "AdminUsernotification");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUsernotifications_UserId",
                table: "AdminUsernotification",
                newName: "IX_AdminUsernotification_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUsernotifications_NotificationTypeId",
                table: "AdminUsernotification",
                newName: "IX_AdminUsernotification_NotificationTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminUser",
                table: "AdminUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminUsernotification",
                table: "AdminUsernotification",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8641));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8657));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8659));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8660));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8662));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8978));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8981));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8984));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8986));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8987));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8989));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8990));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(8992));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9307));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9311));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9313));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9314));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9855));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9357));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9361));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9363));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9365));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9367));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9369));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9370));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9372));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9374));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9449));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9450));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9481));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9498));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9500));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9502));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9504));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9506));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9508));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9510));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9512));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9514));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9516));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9517));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9519));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9539));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9547));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9550));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9554));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9556));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9558));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9560));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9561));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9563));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9565));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9567));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9635));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9637));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9639));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9641));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9642));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9646));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9647));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9650));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9652));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9655));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9657));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9661));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9665));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9666));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9669));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9671));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreationTime",
                value: new DateTime(2022, 10, 26, 18, 25, 55, 488, DateTimeKind.Local).AddTicks(9673));

            migrationBuilder.AddForeignKey(
                name: "FK_AdminLoanapplicationdocuments_AdminUser_UserId",
                table: "AdminLoanapplicationdocuments",
                column: "UserId",
                principalTable: "AdminUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminLoandetails_AdminUser_UserId",
                table: "AdminLoandetails",
                column: "UserId",
                principalTable: "AdminUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUserenableddevices_AdminUser_UserId",
                table: "AdminUserenableddevices",
                column: "UserId",
                principalTable: "AdminUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsernotification_AdminNotificationtypes_NotificationTyp~",
                table: "AdminUsernotification",
                column: "NotificationTypeId",
                principalTable: "AdminNotificationtypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsernotification_AdminUser_UserId",
                table: "AdminUsernotification",
                column: "UserId",
                principalTable: "AdminUser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminLoanapplicationdocuments_AdminUser_UserId",
                table: "AdminLoanapplicationdocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminLoandetails_AdminUser_UserId",
                table: "AdminLoandetails");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUserenableddevices_AdminUser_UserId",
                table: "AdminUserenableddevices");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsernotification_AdminNotificationtypes_NotificationTyp~",
                table: "AdminUsernotification");

            migrationBuilder.DropForeignKey(
                name: "FK_AdminUsernotification_AdminUser_UserId",
                table: "AdminUsernotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminUsernotification",
                table: "AdminUsernotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdminUser",
                table: "AdminUser");

            migrationBuilder.RenameTable(
                name: "AdminUsernotification",
                newName: "AdminUsernotifications");

            migrationBuilder.RenameTable(
                name: "AdminUser",
                newName: "AdminUsers");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUsernotification_UserId",
                table: "AdminUsernotifications",
                newName: "IX_AdminUsernotifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdminUsernotification_NotificationTypeId",
                table: "AdminUsernotifications",
                newName: "IX_AdminUsernotifications_NotificationTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminUsernotifications",
                table: "AdminUsernotifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdminUsers",
                table: "AdminUsers",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6598));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6616));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6619));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 4L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6620));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 5L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6622));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 6L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6623));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 7L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6624));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 8L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6625));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 9L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6626));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 10L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6627));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 11L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6629));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 12L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6630));

            migrationBuilder.UpdateData(
                table: "Assettypes",
                keyColumn: "Id",
                keyValue: 13L,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6631));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6842));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6847));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "IncomeSources",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6850));

            migrationBuilder.UpdateData(
                table: "Sitesettings",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7082));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6889));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6893));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6894));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6896));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6897));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6898));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 7,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6900));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 8,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6901));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 9,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6902));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 10,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 11,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 12,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6907));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 13,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6934));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 14,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6950));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 15,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6951));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 16,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6952));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 17,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6954));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 18,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6955));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 19,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6956));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 20,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6957));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 21,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 22,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6960));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 23,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6961));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 24,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6968));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 25,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6969));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 26,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6983));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 27,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6988));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 28,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6990));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 29,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6991));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 30,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6992));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 31,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6994));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 32,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6995));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 33,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6996));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 34,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6997));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 35,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(6998));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 36,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7000));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 37,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7001));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 38,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7003));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 39,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7004));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 40,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7005));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 41,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7006));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 42,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7008));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 43,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7009));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 44,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7010));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 45,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7012));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 46,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7013));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 47,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7014));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 48,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7015));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 49,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7017));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 50,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7018));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 51,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7019));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 52,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7020));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 53,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7022));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 54,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7028));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 55,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7029));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 56,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7031));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 57,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7032));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 58,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "States",
                keyColumn: "Id",
                keyValue: 59,
                column: "CreationTime",
                value: new DateTime(2022, 10, 18, 23, 44, 47, 548, DateTimeKind.Local).AddTicks(7034));

            migrationBuilder.AddForeignKey(
                name: "FK_AdminLoanapplicationdocuments_AdminUsers_UserId",
                table: "AdminLoanapplicationdocuments",
                column: "UserId",
                principalTable: "AdminUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminLoandetails_AdminUsers_UserId",
                table: "AdminLoandetails",
                column: "UserId",
                principalTable: "AdminUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUserenableddevices_AdminUsers_UserId",
                table: "AdminUserenableddevices",
                column: "UserId",
                principalTable: "AdminUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsernotifications_AdminNotificationtypes_NotificationTy~",
                table: "AdminUsernotifications",
                column: "NotificationTypeId",
                principalTable: "AdminNotificationtypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdminUsernotifications_AdminUsers_UserId",
                table: "AdminUsernotifications",
                column: "UserId",
                principalTable: "AdminUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
