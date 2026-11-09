using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityCafeteria.Migrations.Employees
{
    /// <inheritdoc />
    public partial class FixTypesEmployeeFieldsSupplierProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrder_Supplier_SupplierId",
                table: "PurchaseOrder");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItem_Product_ProductId",
                table: "PurchaseOrderItem");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseOrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrderItem",
                table: "PurchaseOrderItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrder",
                table: "PurchaseOrder");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "phoneNumber",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Supplier",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "PurchaseOrderItem",
                newName: "PurchaseOrderItemes");

            migrationBuilder.RenameTable(
                name: "PurchaseOrder",
                newName: "PurchaseOrderes");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderItem_PurchaseOrderId",
                table: "PurchaseOrderItemes",
                newName: "IX_PurchaseOrderItemes_PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderItem_ProductId",
                table: "PurchaseOrderItemes",
                newName: "IX_PurchaseOrderItemes_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrder_SupplierId",
                table: "PurchaseOrderes",
                newName: "IX_PurchaseOrderes_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_SupplierId",
                table: "Products",
                newName: "IX_Products_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrderItemes",
                table: "PurchaseOrderItemes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrderes",
                table: "PurchaseOrderes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderes_Suppliers_SupplierId",
                table: "PurchaseOrderes",
                column: "SupplierId",
                principalTable: "Suppliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItemes_Products_ProductId",
                table: "PurchaseOrderItemes",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItemes_PurchaseOrderes_PurchaseOrderId",
                table: "PurchaseOrderItemes",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrderes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Suppliers_SupplierId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderes_Suppliers_SupplierId",
                table: "PurchaseOrderes");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItemes_Products_ProductId",
                table: "PurchaseOrderItemes");

            migrationBuilder.DropForeignKey(
                name: "FK_PurchaseOrderItemes_PurchaseOrderes_PurchaseOrderId",
                table: "PurchaseOrderItemes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrderItemes",
                table: "PurchaseOrderItemes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PurchaseOrderes",
                table: "PurchaseOrderes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Supplier");

            migrationBuilder.RenameTable(
                name: "PurchaseOrderItemes",
                newName: "PurchaseOrderItem");

            migrationBuilder.RenameTable(
                name: "PurchaseOrderes",
                newName: "PurchaseOrder");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderItemes_PurchaseOrderId",
                table: "PurchaseOrderItem",
                newName: "IX_PurchaseOrderItem_PurchaseOrderId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderItemes_ProductId",
                table: "PurchaseOrderItem",
                newName: "IX_PurchaseOrderItem_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_PurchaseOrderes_SupplierId",
                table: "PurchaseOrder",
                newName: "IX_PurchaseOrder_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_SupplierId",
                table: "Product",
                newName: "IX_Product_SupplierId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "phoneNumber",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Supplier",
                table: "Supplier",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrderItem",
                table: "PurchaseOrderItem",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PurchaseOrder",
                table: "PurchaseOrder",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Category_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Supplier_SupplierId",
                table: "Product",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrder_Supplier_SupplierId",
                table: "PurchaseOrder",
                column: "SupplierId",
                principalTable: "Supplier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItem_Product_ProductId",
                table: "PurchaseOrderItem",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PurchaseOrderItem_PurchaseOrder_PurchaseOrderId",
                table: "PurchaseOrderItem",
                column: "PurchaseOrderId",
                principalTable: "PurchaseOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
