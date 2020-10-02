using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class Izhan_changes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "ConsentDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "ConsentDetails",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "ConsentDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "ConsentDetails");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "ConsentDetails");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "ConsentDetails");
        }
    }
}
