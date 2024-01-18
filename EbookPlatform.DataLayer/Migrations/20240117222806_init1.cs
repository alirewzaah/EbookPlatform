using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EbookPlatform.DataLayer.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "authors",
                columns: table => new
                {
                    authorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    authorFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_authors", x => x.authorID);
                });

            migrationBuilder.CreateTable(
                name: "bookCategories",
                columns: table => new
                {
                    bookCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookCategories", x => x.bookCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    categoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    parentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.categoryID);
                    table.ForeignKey(
                        name: "FK_categories_categories_parentID",
                        column: x => x.parentID,
                        principalTable: "categories",
                        principalColumn: "categoryID");
                });

            migrationBuilder.CreateTable(
                name: "languages",
                columns: table => new
                {
                    languageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    languageTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    languageDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_languages", x => x.languageID);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    permissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permissionTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.permissionID);
                });

            migrationBuilder.CreateTable(
                name: "publishers",
                columns: table => new
                {
                    publisherID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    publisherFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_publishers", x => x.publisherID);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    roleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.roleID);
                });

            migrationBuilder.CreateTable(
                name: "subCategories",
                columns: table => new
                {
                    subCategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    subCategoryTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subCategories", x => x.subCategoryID);
                });

            migrationBuilder.CreateTable(
                name: "translators",
                columns: table => new
                {
                    translatorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    translatorFullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_translators", x => x.translatorID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    userID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Ssn = table.Column<int>(type: "int", nullable: true),
                    phoneNumber = table.Column<int>(type: "int", nullable: true),
                    email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sex = table.Column<bool>(type: "bit", nullable: true),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActiveCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.userID);
                });

            migrationBuilder.CreateTable(
                name: "rolePermissions",
                columns: table => new
                {
                    rolePermissionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    roleID = table.Column<int>(type: "int", nullable: false),
                    permissionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolePermissions", x => x.rolePermissionID);
                    table.ForeignKey(
                        name: "FK_rolePermissions_permissions_permissionID",
                        column: x => x.permissionID,
                        principalTable: "permissions",
                        principalColumn: "permissionID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_rolePermissions_roles_roleID",
                        column: x => x.roleID,
                        principalTable: "roles",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    cartID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isPayed = table.Column<bool>(type: "bit", nullable: false),
                    dateCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    finalPrice = table.Column<float>(type: "real", nullable: false),
                    refID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.cartID);
                    table.ForeignKey(
                        name: "FK_carts_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "favorites",
                columns: table => new
                {
                    favoriteID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    bookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorites", x => x.favoriteID);
                    table.ForeignKey(
                        name: "FK_favorites_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "libraries",
                columns: table => new
                {
                    libraryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_libraries", x => x.libraryID);
                    table.ForeignKey(
                        name: "FK_libraries_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "userRoles",
                columns: table => new
                {
                    userRoleID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userID = table.Column<int>(type: "int", nullable: false),
                    roleID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userRoles", x => x.userRoleID);
                    table.ForeignKey(
                        name: "FK_userRoles_roles_roleID",
                        column: x => x.roleID,
                        principalTable: "roles",
                        principalColumn: "roleID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_userRoles_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "shelves",
                columns: table => new
                {
                    shelfID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    shelfTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    libraryID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_shelves", x => x.shelfID);
                    table.ForeignKey(
                        name: "FK_shelves_libraries_libraryID",
                        column: x => x.libraryID,
                        principalTable: "libraries",
                        principalColumn: "libraryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    bookID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    productUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bookTitle = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    isDeleted = table.Column<bool>(type: "bit", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    discountPercentage = table.Column<byte>(type: "tinyint", nullable: true),
                    longDescription = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fileFormat = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    fileSize = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    pageCount = table.Column<int>(type: "int", nullable: false),
                    salesCount = table.Column<int>(type: "int", nullable: true),
                    engTitle = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    releaseDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    priceInDollar = table.Column<float>(type: "real", nullable: true),
                    physicalVersionPrice = table.Column<float>(type: "real", nullable: true),
                    bookEFile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    authorID = table.Column<int>(type: "int", nullable: false),
                    translatorID = table.Column<int>(type: "int", nullable: false),
                    publisherID = table.Column<int>(type: "int", nullable: false),
                    languageID = table.Column<int>(type: "int", nullable: false),
                    categoryID = table.Column<int>(type: "int", nullable: false),
                    shelfID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.bookID);
                    table.ForeignKey(
                        name: "FK_books_authors_authorID",
                        column: x => x.authorID,
                        principalTable: "authors",
                        principalColumn: "authorID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_books_categories_categoryID",
                        column: x => x.categoryID,
                        principalTable: "categories",
                        principalColumn: "categoryID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_books_languages_languageID",
                        column: x => x.languageID,
                        principalTable: "languages",
                        principalColumn: "languageID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_books_publishers_publisherID",
                        column: x => x.publisherID,
                        principalTable: "publishers",
                        principalColumn: "publisherID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_books_shelves_shelfID",
                        column: x => x.shelfID,
                        principalTable: "shelves",
                        principalColumn: "shelfID");
                    table.ForeignKey(
                        name: "FK_books_translators_translatorID",
                        column: x => x.translatorID,
                        principalTable: "translators",
                        principalColumn: "translatorID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "cartItems",
                columns: table => new
                {
                    cartItemID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    price = table.Column<float>(type: "real", nullable: false),
                    dateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    bookID = table.Column<int>(type: "int", nullable: false),
                    cartID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cartItems", x => x.cartItemID);
                    table.ForeignKey(
                        name: "FK_cartItems_books_bookID",
                        column: x => x.bookID,
                        principalTable: "books",
                        principalColumn: "bookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_cartItems_carts_cartID",
                        column: x => x.cartID,
                        principalTable: "carts",
                        principalColumn: "cartID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    commentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    timeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    commentBody = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    likesCount = table.Column<int>(type: "int", nullable: false),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    bookID = table.Column<int>(type: "int", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.commentID);
                    table.ForeignKey(
                        name: "FK_comments_books_bookID",
                        column: x => x.bookID,
                        principalTable: "books",
                        principalColumn: "bookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_comments_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ratings",
                columns: table => new
                {
                    ratingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    score = table.Column<byte>(type: "tinyint", nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    bookID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ratings", x => x.ratingID);
                    table.ForeignKey(
                        name: "FK_ratings_books_bookID",
                        column: x => x.bookID,
                        principalTable: "books",
                        principalColumn: "bookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ratings_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "subComments",
                columns: table => new
                {
                    subCommentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    isActive = table.Column<bool>(type: "bit", nullable: false),
                    timeCreated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    subCommentBody = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    userID = table.Column<int>(type: "int", nullable: false),
                    commentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_subComments", x => x.subCommentID);
                    table.ForeignKey(
                        name: "FK_subComments_comments_commentID",
                        column: x => x.commentID,
                        principalTable: "comments",
                        principalColumn: "commentID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_subComments_users_userID",
                        column: x => x.userID,
                        principalTable: "users",
                        principalColumn: "userID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_authorID",
                table: "books",
                column: "authorID");

            migrationBuilder.CreateIndex(
                name: "IX_books_categoryID",
                table: "books",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_books_languageID",
                table: "books",
                column: "languageID");

            migrationBuilder.CreateIndex(
                name: "IX_books_publisherID",
                table: "books",
                column: "publisherID");

            migrationBuilder.CreateIndex(
                name: "IX_books_shelfID",
                table: "books",
                column: "shelfID");

            migrationBuilder.CreateIndex(
                name: "IX_books_translatorID",
                table: "books",
                column: "translatorID");

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_bookID",
                table: "cartItems",
                column: "bookID");

            migrationBuilder.CreateIndex(
                name: "IX_cartItems_cartID",
                table: "cartItems",
                column: "cartID");

            migrationBuilder.CreateIndex(
                name: "IX_carts_userID",
                table: "carts",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_categories_parentID",
                table: "categories",
                column: "parentID");

            migrationBuilder.CreateIndex(
                name: "IX_comments_bookID",
                table: "comments",
                column: "bookID");

            migrationBuilder.CreateIndex(
                name: "IX_comments_userID",
                table: "comments",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_favorites_userID",
                table: "favorites",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_libraries_userID",
                table: "libraries",
                column: "userID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ratings_bookID",
                table: "ratings",
                column: "bookID");

            migrationBuilder.CreateIndex(
                name: "IX_ratings_userID",
                table: "ratings",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_rolePermissions_permissionID",
                table: "rolePermissions",
                column: "permissionID");

            migrationBuilder.CreateIndex(
                name: "IX_rolePermissions_roleID",
                table: "rolePermissions",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_shelves_libraryID",
                table: "shelves",
                column: "libraryID");

            migrationBuilder.CreateIndex(
                name: "IX_subComments_commentID",
                table: "subComments",
                column: "commentID");

            migrationBuilder.CreateIndex(
                name: "IX_subComments_userID",
                table: "subComments",
                column: "userID");

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_roleID",
                table: "userRoles",
                column: "roleID");

            migrationBuilder.CreateIndex(
                name: "IX_userRoles_userID",
                table: "userRoles",
                column: "userID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bookCategories");

            migrationBuilder.DropTable(
                name: "cartItems");

            migrationBuilder.DropTable(
                name: "favorites");

            migrationBuilder.DropTable(
                name: "ratings");

            migrationBuilder.DropTable(
                name: "rolePermissions");

            migrationBuilder.DropTable(
                name: "subCategories");

            migrationBuilder.DropTable(
                name: "subComments");

            migrationBuilder.DropTable(
                name: "userRoles");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "authors");

            migrationBuilder.DropTable(
                name: "categories");

            migrationBuilder.DropTable(
                name: "languages");

            migrationBuilder.DropTable(
                name: "publishers");

            migrationBuilder.DropTable(
                name: "shelves");

            migrationBuilder.DropTable(
                name: "translators");

            migrationBuilder.DropTable(
                name: "libraries");

            migrationBuilder.DropTable(
                name: "users");
        }
    }
}
