using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddTableBorrowerType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "BorrowerTypeId",
                table: "BorrowerInformation",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BorrowerTypeId",
                table: "BorrowerEmploymentInformation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BorrowerType",
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
                    Type = table.Column<string>(nullable: true),
                    TenantId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BorrowerType", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerInformation_BorrowerTypeId",
                table: "BorrowerInformation",
                column: "BorrowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BorrowerEmploymentInformation_BorrowerTypeId",
                table: "BorrowerEmploymentInformation",
                column: "BorrowerTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerEmploymentInformation_BorrowerType_BorrowerTypeId",
                table: "BorrowerEmploymentInformation",
                column: "BorrowerTypeId",
                principalTable: "BorrowerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BorrowerInformation_BorrowerType_BorrowerTypeId",
                table: "BorrowerInformation",
                column: "BorrowerTypeId",
                principalTable: "BorrowerType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerEmploymentInformation_BorrowerType_BorrowerTypeId",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropForeignKey(
                name: "FK_BorrowerInformation_BorrowerType_BorrowerTypeId",
                table: "BorrowerInformation");

            migrationBuilder.DropTable(
                name: "BorrowerType");

            migrationBuilder.DropIndex(
                name: "IX_BorrowerInformation_BorrowerTypeId",
                table: "BorrowerInformation");

            migrationBuilder.DropIndex(
                name: "IX_BorrowerEmploymentInformation_BorrowerTypeId",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.DropColumn(
                name: "BorrowerTypeId",
                table: "BorrowerInformation");

            migrationBuilder.DropColumn(
                name: "BorrowerTypeId",
                table: "BorrowerEmploymentInformation");
        }
    }
}
