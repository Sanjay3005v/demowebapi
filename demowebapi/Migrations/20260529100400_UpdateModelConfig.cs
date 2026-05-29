using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demowebapi.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModelConfig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Products_CatId",
                table: "Products",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CatId",
                table: "Products",
                column: "CatId",
                principalTable: "Categories",
                principalColumn: "CatId",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CatId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatId",
                table: "Products");
        }
    }
}
