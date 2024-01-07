using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbookPlatform.DataLayer.Migrations
{
    public partial class init3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_books_categories_categoryID",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_books_subCategories_subCategoryID",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "FK_subCategories_categories_categoryID",
                table: "subCategories");

            migrationBuilder.DropIndex(
                name: "IX_subCategories_categoryID",
                table: "subCategories");

            migrationBuilder.DropIndex(
                name: "IX_books_categoryID",
                table: "books");

            migrationBuilder.DropIndex(
                name: "IX_books_subCategoryID",
                table: "books");

            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "subCategories");

            migrationBuilder.DropColumn(
                name: "categoryID",
                table: "books");

            migrationBuilder.DropColumn(
                name: "subCategoryID",
                table: "books");

            migrationBuilder.AddColumn<int>(
                name: "parentID",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "bookCategories",
                columns: table => new
                {
                    bookCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    bookID = table.Column<int>(type: "int", nullable: false),
                    categoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookCategories", x => x.bookCategoryID);
                    table.ForeignKey(
                        name: "FK_bookCategories_books_bookID",
                        column: x => x.bookID,
                        principalTable: "books",
                        principalColumn: "bookID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_bookCategories_categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "categories",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_categories_parentID",
                table: "categories",
                column: "parentID");

            migrationBuilder.CreateIndex(
                name: "IX_bookCategories_bookID",
                table: "bookCategories",
                column: "bookID");

            migrationBuilder.CreateIndex(
                name: "IX_bookCategories_categoryID",
                table: "bookCategories",
                column: "categoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_categories_parentID",
                table: "categories",
                column: "parentID",
                principalTable: "categories",
                principalColumn: "categoryID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_categories_parentID",
                table: "categories");

            migrationBuilder.DropTable(
                name: "bookCategories");

            migrationBuilder.DropIndex(
                name: "IX_categories_parentID",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "parentID",
                table: "categories");

            migrationBuilder.AddColumn<int>(
                name: "categoryID",
                table: "subCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "categoryID",
                table: "books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "subCategoryID",
                table: "books",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_subCategories_categoryID",
                table: "subCategories",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_books_categoryID",
                table: "books",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_books_subCategoryID",
                table: "books",
                column: "subCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_books_categories_categoryID",
                table: "books",
                column: "categoryID",
                principalTable: "categories",
                principalColumn: "categoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_books_subCategories_subCategoryID",
                table: "books",
                column: "subCategoryID",
                principalTable: "subCategories",
                principalColumn: "subCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_subCategories_categories_categoryID",
                table: "subCategories",
                column: "categoryID",
                principalTable: "categories",
                principalColumn: "categoryID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
