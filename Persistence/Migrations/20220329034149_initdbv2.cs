using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    public partial class initdbv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ImageStorage_ProductDetail_ProductDetailId",
                table: "ImageStorage");

            migrationBuilder.DropIndex(
                name: "IX_ImageStorage_ProductDetailId",
                table: "ImageStorage");

            migrationBuilder.DropColumn(
                name: "ProductDetailId",
                table: "ImageStorage");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductDetailId",
                table: "ImageStorage",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ImageStorage_ProductDetailId",
                table: "ImageStorage",
                column: "ProductDetailId");

            migrationBuilder.AddForeignKey(
                name: "FK_ImageStorage_ProductDetail_ProductDetailId",
                table: "ImageStorage",
                column: "ProductDetailId",
                principalTable: "ProductDetail",
                principalColumn: "Id");
        }
    }
}
