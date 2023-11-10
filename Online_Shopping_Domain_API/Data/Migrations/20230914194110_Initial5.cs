using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Online_Shopping_Domain_API.Data.Migrations
{
    public partial class Initial5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catagories_CatagoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatagoryId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "CatagoryId",
                table: "Products",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "Orders",
                newName: "OrderId");

            migrationBuilder.RenameColumn(
                name: "CatagoryType",
                table: "Catagories",
                newName: "CategoryType");

            migrationBuilder.RenameColumn(
                name: "CatagoryName",
                table: "Catagories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "CatagoryId",
                table: "Catagories",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catagories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Catagories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Products_ProductId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catagories_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Products",
                newName: "CatagoryId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "Orders",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "CategoryType",
                table: "Catagories",
                newName: "CatagoryType");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Catagories",
                newName: "CatagoryName");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Catagories",
                newName: "CatagoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatagoryId",
                table: "Products",
                column: "CatagoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catagories_CatagoryId",
                table: "Products",
                column: "CatagoryId",
                principalTable: "Catagories",
                principalColumn: "CatagoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
