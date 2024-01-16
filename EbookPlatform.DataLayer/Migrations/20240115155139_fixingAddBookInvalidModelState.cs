using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbookPlatform.DataLayer.Migrations
{
    public partial class fixingAddBookInvalidModelState : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookCategories_books_bookID",
                table: "bookCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_bookCategories_categories_categoryID",
                table: "bookCategories");

            migrationBuilder.DropIndex(
                name: "IX_bookCategories_bookID",
                table: "bookCategories");

            migrationBuilder.DropIndex(
                name: "IX_bookCategories_categoryID",
                table: "bookCategories");

            migrationBuilder.DropColumn(
                name: "bookID",
                table: "bookCategories");

            migrationBuilder.AddColumn<int>(
                name: "categoryID",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_books_categoryID",
                table: "books",
                column: "categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_categoryID",
                table: "books",
                column: "categoryID",
                principalTable: "categories",
                principalColumn: "categoryID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_categoryID",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_categoryID",
                table: "books");

            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "bookID",
                table: "bookCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_bookCategories_bookID",
                table: "bookCategories",
                column: "bookID");

            migrationBuilder.CreateIndex(
                name: "IX_bookCategories_categoryID",
                table: "bookCategories",
                column: "categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_bookCategories_books_bookID",
                table: "bookCategories",
                column: "bookID",
                principalTable: "books",
                principalColumn: "bookID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookCategories_categories_categoryID",
                table: "bookCategories",
                column: "categoryID",
                principalTable: "categories",
                principalColumn: "categoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
