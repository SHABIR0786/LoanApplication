using Microsoft.EntityFrameworkCore.Migrations;

namespace LoanManagement.Migrations
{
    public partial class AddCoBorrowerIsMailingAddressSameAsResidential : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CoBorrowerResidentialAddressSameAsBorrowerResidential",
                table: "PersonalDetails",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoBorrowerResidentialAddressSameAsBorrowerResidential",
                table: "PersonalDetails");
        }
    }
}
