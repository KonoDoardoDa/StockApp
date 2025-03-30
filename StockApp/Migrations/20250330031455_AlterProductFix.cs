using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StockApp.Migrations
{
    public partial class AlterProductFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "ProviderId",
                table: "Products",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "ProductId",
                table: "Products",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProviderId",
                table: "Products");

            migrationBuilder.AddColumn<string>(
                name: "ProviderId",
                table: "Products",
                type: "longtext",
                nullable: false);
        }
    }
}
