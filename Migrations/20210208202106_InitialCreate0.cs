using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerce.Migrations
{
    public partial class InitialCreate0 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Categories_Parent",
                table: "Categories",
                column: "Parent");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_Parent",
                table: "Categories",
                column: "Parent",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_Parent",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_Parent",
                table: "Categories");
        }
    }
}
