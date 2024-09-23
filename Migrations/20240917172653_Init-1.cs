using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class Init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId1",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Receipts_Customers_CustomerId1",
                table: "Receipts");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptsDetails_Products_ProductId1",
                table: "ReceiptsDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ReceiptsDetails_Receipts_ReceiptId1",
                table: "ReceiptsDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptsDetails_ProductId1",
                table: "ReceiptsDetails");

            migrationBuilder.DropIndex(
                name: "IX_ReceiptsDetails_ReceiptId1",
                table: "ReceiptsDetails");

            migrationBuilder.DropIndex(
                name: "IX_Receipts_CustomerId1",
                table: "Receipts");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductCategoryId1",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductId1",
                table: "ReceiptsDetails");

            migrationBuilder.DropColumn(
                name: "ReceiptId1",
                table: "ReceiptsDetails");

            migrationBuilder.DropColumn(
                name: "CustomerId1",
                table: "Receipts");

            migrationBuilder.DropColumn(
                name: "ProductCategoryId1",
                table: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId1",
                table: "ReceiptsDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReceiptId1",
                table: "ReceiptsDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId1",
                table: "Receipts",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductCategoryId1",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptsDetails_ProductId1",
                table: "ReceiptsDetails",
                column: "ProductId1");

            migrationBuilder.CreateIndex(
                name: "IX_ReceiptsDetails_ReceiptId1",
                table: "ReceiptsDetails",
                column: "ReceiptId1");

            migrationBuilder.CreateIndex(
                name: "IX_Receipts_CustomerId1",
                table: "Receipts",
                column: "CustomerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId1",
                table: "Products",
                column: "ProductCategoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId1",
                table: "Products",
                column: "ProductCategoryId1",
                principalTable: "ProductCategories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Receipts_Customers_CustomerId1",
                table: "Receipts",
                column: "CustomerId1",
                principalTable: "Customers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptsDetails_Products_ProductId1",
                table: "ReceiptsDetails",
                column: "ProductId1",
                principalTable: "Products",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceiptsDetails_Receipts_ReceiptId1",
                table: "ReceiptsDetails",
                column: "ReceiptId1",
                principalTable: "Receipts",
                principalColumn: "Id");
        }
    }
}
