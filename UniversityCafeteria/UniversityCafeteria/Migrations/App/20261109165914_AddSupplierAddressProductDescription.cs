using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UniversityCafeteria.Migrations.App
{
    /// <inheritdoc />
    public partial class AddSupplierAddressProductDescription : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Supplier",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Product");
        }
    }
}
