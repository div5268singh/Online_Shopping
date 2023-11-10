using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Shopping_Domain_API.Data.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Contry",
                table: "Customers",
                newName: "Country");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Country",
                table: "Customers",
                newName: "Contry");
        }
    }
}
