using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace LoanManagement.Migrations
{
    public partial class RemoveBorrowerType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "BorrowerType",
                table: "BorrowerInformation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BorrowerType",
                table: "BorrowerEmploymentInformation",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BorrowerType",
                table: "BorrowerInformation");

            migrationBuilder.DropColumn(
                name: "BorrowerType",
                table: "BorrowerEmploymentInformation");

            migrationBuilder.AddColumn<long>(
                name: "BorrowerTypeId",
                table: "BorrowerInformation",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "BorrowerTypeId",
                table: "BorrowerEmploymentInformation",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "BorrowerType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    CreatorUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeleterUserId = table.Column<long>(type: "bigint", nullable: true),
                    DeletionTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LastModificationTime = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    LastModifierUserId = table.Column<long>(type: "bigint", nullable: true),
                    TenantId = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
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
    }
}
