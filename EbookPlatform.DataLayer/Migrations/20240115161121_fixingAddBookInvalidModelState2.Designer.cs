﻿// <auto-generated />
using System;
using EbookPlatform;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EbookPlatform.DataLayer.Migrations
{
    [DbContext(typeof(MyEbookPlatformContext))]
    [Migration("20240115161121_fixingAddBookInvalidModelState2")]
    partial class fixingAddBookInvalidModelState2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.25")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("EbookPlatform.AdminUser", b =>
                {
                    b.Property<int>("adminUserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("adminUserID"), 1L, 1);

                    b.Property<string>("adminUserEmail")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("adminUserName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("adminUserPassword")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("roleID")
                        .HasColumnType("int");

                    b.HasKey("adminUserID");

                    b.HasIndex("roleID");

                    b.ToTable("adminUsers");

                    b.HasData(
                        new
                        {
                            adminUserID = 1,
                            adminUserEmail = "admin@admin.ir",
                            adminUserName = "admin",
                            adminUserPassword = "admin",
                            roleID = 1
                        });
                });

            modelBuilder.Entity("EbookPlatform.Author", b =>
                {
                    b.Property<int>("authorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("authorID"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("authorFullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("authorID");

                    b.ToTable("authors");
                });

            modelBuilder.Entity("EbookPlatform.Book", b =>
                {
                    b.Property<int>("bookID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookID"), 1L, 1);

                    b.Property<int>("authorID")
                        .HasColumnType("int");

                    b.Property<string>("bookEFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("bookTitle")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<int>("categoryID")
                        .HasColumnType("int");

                    b.Property<byte?>("discountPercentage")
                        .HasColumnType("tinyint");

                    b.Property<string>("engTitle")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("fileFormat")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("fileSize")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("languageID")
                        .HasColumnType("int");

                    b.Property<string>("longDescription")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("pageCount")
                        .HasColumnType("int");

                    b.Property<float?>("physicalVersionPrice")
                        .HasColumnType("real");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.Property<float?>("priceInDollar")
                        .HasColumnType("real");

                    b.Property<DateTime>("productCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("productUpdated")
                        .HasColumnType("datetime2");

                    b.Property<int>("publisherID")
                        .HasColumnType("int");

                    b.Property<DateTime?>("releaseDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("salesCount")
                        .HasColumnType("int");

                    b.Property<int?>("shelfID")
                        .HasColumnType("int");

                    b.Property<int>("translatorID")
                        .HasColumnType("int");

                    b.HasKey("bookID");

                    b.HasIndex("authorID");

                    b.HasIndex("categoryID");

                    b.HasIndex("languageID");

                    b.HasIndex("publisherID");

                    b.HasIndex("shelfID");

                    b.HasIndex("translatorID");

                    b.ToTable("books");
                });

            modelBuilder.Entity("EbookPlatform.BookCategory", b =>
                {
                    b.Property<int>("bookCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("bookCategoryID"), 1L, 1);

                    b.Property<int>("categoryID")
                        .HasColumnType("int");

                    b.HasKey("bookCategoryID");

                    b.ToTable("bookCategories");
                });

            modelBuilder.Entity("EbookPlatform.Cart", b =>
                {
                    b.Property<int>("cartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cartID"), 1L, 1);

                    b.Property<DateTime>("dateCreated")
                        .HasColumnType("datetime2");

                    b.Property<float>("finalPrice")
                        .HasColumnType("real");

                    b.Property<bool>("isPayed")
                        .HasColumnType("bit");

                    b.Property<int>("refID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("cartID");

                    b.HasIndex("userID");

                    b.ToTable("carts");
                });

            modelBuilder.Entity("EbookPlatform.CartItem", b =>
                {
                    b.Property<int>("cartItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("cartItemID"), 1L, 1);

                    b.Property<int>("bookID")
                        .HasColumnType("int");

                    b.Property<int>("cartID")
                        .HasColumnType("int");

                    b.Property<DateTime>("dateAdded")
                        .HasColumnType("datetime2");

                    b.Property<float>("price")
                        .HasColumnType("real");

                    b.HasKey("cartItemID");

                    b.HasIndex("bookID");

                    b.HasIndex("cartID");

                    b.ToTable("cartItems");
                });

            modelBuilder.Entity("EbookPlatform.Category", b =>
                {
                    b.Property<int>("categoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("categoryID"), 1L, 1);

                    b.Property<string>("description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("parentID")
                        .HasColumnType("int");

                    b.Property<string>("title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("categoryID");

                    b.HasIndex("parentID");

                    b.ToTable("categories");
                });

            modelBuilder.Entity("EbookPlatform.Comment", b =>
                {
                    b.Property<int>("commentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("commentID"), 1L, 1);

                    b.Property<int>("bookID")
                        .HasColumnType("int");

                    b.Property<string>("commentBody")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<int>("likesCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("timeCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("commentID");

                    b.HasIndex("bookID");

                    b.HasIndex("userID");

                    b.ToTable("comments");
                });

            modelBuilder.Entity("EbookPlatform.DataLayer.Entities.AdminArea.Role.Permission", b =>
                {
                    b.Property<int>("permissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("permissionID"), 1L, 1);

                    b.Property<string>("permissionTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("permissionID");

                    b.ToTable("permissions");

                    b.HasData(
                        new
                        {
                            permissionID = 1,
                            permissionTitle = "ContentManager"
                        },
                        new
                        {
                            permissionID = 2,
                            permissionTitle = "UserManager"
                        },
                        new
                        {
                            permissionID = 3,
                            permissionTitle = "AdminUserManager"
                        },
                        new
                        {
                            permissionID = 4,
                            permissionTitle = "CommentsManager"
                        },
                        new
                        {
                            permissionID = 5,
                            permissionTitle = "ReportsManager"
                        });
                });

            modelBuilder.Entity("EbookPlatform.DataLayer.Entities.AdminArea.Role.Role", b =>
                {
                    b.Property<int>("roleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("roleID"), 1L, 1);

                    b.Property<string>("roleTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("roleID");

                    b.ToTable("roles");

                    b.HasData(
                        new
                        {
                            roleID = 1,
                            roleTitle = "sa"
                        });
                });

            modelBuilder.Entity("EbookPlatform.DataLayer.Entities.AdminArea.Role.RolePermission", b =>
                {
                    b.Property<int>("rolePermissionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("rolePermissionID"), 1L, 1);

                    b.Property<int>("permissionid")
                        .HasColumnType("int");

                    b.Property<int>("roleid")
                        .HasColumnType("int");

                    b.HasKey("rolePermissionID");

                    b.HasIndex("permissionid");

                    b.HasIndex("roleid");

                    b.ToTable("rolePermissions");

                    b.HasData(
                        new
                        {
                            rolePermissionID = 1,
                            permissionid = 1,
                            roleid = 1
                        },
                        new
                        {
                            rolePermissionID = 2,
                            permissionid = 2,
                            roleid = 1
                        },
                        new
                        {
                            rolePermissionID = 3,
                            permissionid = 3,
                            roleid = 1
                        },
                        new
                        {
                            rolePermissionID = 4,
                            permissionid = 4,
                            roleid = 1
                        },
                        new
                        {
                            rolePermissionID = 5,
                            permissionid = 5,
                            roleid = 1
                        });
                });

            modelBuilder.Entity("EbookPlatform.Favorite", b =>
                {
                    b.Property<int>("favoriteID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("favoriteID"), 1L, 1);

                    b.Property<int>("bookID")
                        .HasColumnType("int");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("favoriteID");

                    b.HasIndex("userID");

                    b.ToTable("favorites");
                });

            modelBuilder.Entity("EbookPlatform.Language", b =>
                {
                    b.Property<int>("languageID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("languageID"), 1L, 1);

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("languageDescription")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("languageTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("languageID");

                    b.ToTable("languages");
                });

            modelBuilder.Entity("EbookPlatform.Library", b =>
                {
                    b.Property<int>("libraryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("libraryID"), 1L, 1);

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("libraryID");

                    b.HasIndex("userID")
                        .IsUnique();

                    b.ToTable("libraries");
                });

            modelBuilder.Entity("EbookPlatform.Publisher", b =>
                {
                    b.Property<int>("publisherID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("publisherID"), 1L, 1);

                    b.Property<string>("description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("publisherFullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("publisherID");

                    b.ToTable("publishers");
                });

            modelBuilder.Entity("EbookPlatform.Rating", b =>
                {
                    b.Property<int>("ratingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ratingID"), 1L, 1);

                    b.Property<int>("bookID")
                        .HasColumnType("int");

                    b.Property<byte>("score")
                        .HasColumnType("tinyint");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("ratingID");

                    b.HasIndex("bookID");

                    b.HasIndex("userID");

                    b.ToTable("ratings");
                });

            modelBuilder.Entity("EbookPlatform.Shelf", b =>
                {
                    b.Property<int>("shelfID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("shelfID"), 1L, 1);

                    b.Property<int>("libraryID")
                        .HasColumnType("int");

                    b.Property<string>("shelfTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("shelfID");

                    b.HasIndex("libraryID");

                    b.ToTable("shelves");
                });

            modelBuilder.Entity("EbookPlatform.SubCategory", b =>
                {
                    b.Property<int>("subCategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("subCategoryID"), 1L, 1);

                    b.Property<string>("description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("subCategoryTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("subCategoryID");

                    b.ToTable("subCategories");
                });

            modelBuilder.Entity("EbookPlatform.SubComment", b =>
                {
                    b.Property<int>("subCommentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("subCommentID"), 1L, 1);

                    b.Property<int>("commentID")
                        .HasColumnType("int");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<string>("subCommentBody")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("timeCreated")
                        .HasColumnType("datetime2");

                    b.Property<int>("userID")
                        .HasColumnType("int");

                    b.HasKey("subCommentID");

                    b.HasIndex("commentID");

                    b.HasIndex("userID");

                    b.ToTable("subComments");
                });

            modelBuilder.Entity("EbookPlatform.Translator", b =>
                {
                    b.Property<int>("translatorID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("translatorID"), 1L, 1);

                    b.Property<string>("description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("translatorFullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("translatorID");

                    b.ToTable("translators");
                });

            modelBuilder.Entity("EbookPlatform.User", b =>
                {
                    b.Property<int>("userID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("userID"), 1L, 1);

                    b.Property<bool>("Sex")
                        .HasColumnType("bit");

                    b.Property<int>("Ssn")
                        .HasColumnType("int");

                    b.Property<DateTime>("birthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("firstName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<bool>("isActive")
                        .HasColumnType("bit");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("lastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("phoneNumber")
                        .HasColumnType("int");

                    b.HasKey("userID");

                    b.ToTable("users");
                });

            modelBuilder.Entity("EbookPlatform.AdminUser", b =>
                {
                    b.HasOne("EbookPlatform.DataLayer.Entities.AdminArea.Role.Role", "role")
                        .WithMany("adminUsers")
                        .HasForeignKey("roleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("role");
                });

            modelBuilder.Entity("EbookPlatform.Book", b =>
                {
                    b.HasOne("EbookPlatform.Author", "author")
                        .WithMany("books")
                        .HasForeignKey("authorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookPlatform.Category", "category")
                        .WithMany("books")
                        .HasForeignKey("categoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookPlatform.Language", "language")
                        .WithMany("books")
                        .HasForeignKey("languageID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookPlatform.Publisher", "publisher")
                        .WithMany("books")
                        .HasForeignKey("publisherID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookPlatform.Shelf", null)
                        .WithMany("books")
                        .HasForeignKey("shelfID");

                    b.HasOne("EbookPlatform.Translator", "translator")
                        .WithMany("books")
                        .HasForeignKey("translatorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("author");

                    b.Navigation("category");

                    b.Navigation("language");

                    b.Navigation("publisher");

                    b.Navigation("translator");
                });

            modelBuilder.Entity("EbookPlatform.Cart", b =>
                {
                    b.HasOne("EbookPlatform.User", "user")
                        .WithMany()
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("EbookPlatform.CartItem", b =>
                {
                    b.HasOne("EbookPlatform.Book", "book")
                        .WithMany()
                        .HasForeignKey("bookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookPlatform.Cart", "cart")
                        .WithMany("cartItems")
                        .HasForeignKey("cartID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("cart");
                });

            modelBuilder.Entity("EbookPlatform.Category", b =>
                {
                    b.HasOne("EbookPlatform.Category", "category")
                        .WithMany("children")
                        .HasForeignKey("parentID");

                    b.Navigation("category");
                });

            modelBuilder.Entity("EbookPlatform.Comment", b =>
                {
                    b.HasOne("EbookPlatform.Book", null)
                        .WithMany("comments")
                        .HasForeignKey("bookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookPlatform.User", "user")
                        .WithMany("comments")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("EbookPlatform.DataLayer.Entities.AdminArea.Role.RolePermission", b =>
                {
                    b.HasOne("EbookPlatform.DataLayer.Entities.AdminArea.Role.Permission", "permission")
                        .WithMany("rolePermissions")
                        .HasForeignKey("permissionid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookPlatform.DataLayer.Entities.AdminArea.Role.Role", "role")
                        .WithMany("rolePermissions")
                        .HasForeignKey("roleid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("permission");

                    b.Navigation("role");
                });

            modelBuilder.Entity("EbookPlatform.Favorite", b =>
                {
                    b.HasOne("EbookPlatform.User", "User")
                        .WithMany("favorites")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("EbookPlatform.Library", b =>
                {
                    b.HasOne("EbookPlatform.User", "user")
                        .WithOne("library")
                        .HasForeignKey("EbookPlatform.Library", "userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("EbookPlatform.Rating", b =>
                {
                    b.HasOne("EbookPlatform.Book", "book")
                        .WithMany("ratings")
                        .HasForeignKey("bookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookPlatform.User", "user")
                        .WithMany("ratings")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("book");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EbookPlatform.Shelf", b =>
                {
                    b.HasOne("EbookPlatform.Library", null)
                        .WithMany("Shelves")
                        .HasForeignKey("libraryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EbookPlatform.SubComment", b =>
                {
                    b.HasOne("EbookPlatform.Comment", "comment")
                        .WithMany("subComments")
                        .HasForeignKey("commentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EbookPlatform.User", "user")
                        .WithMany("subComments")
                        .HasForeignKey("userID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("comment");

                    b.Navigation("user");
                });

            modelBuilder.Entity("EbookPlatform.Author", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("EbookPlatform.Book", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("ratings");
                });

            modelBuilder.Entity("EbookPlatform.Cart", b =>
                {
                    b.Navigation("cartItems");
                });

            modelBuilder.Entity("EbookPlatform.Category", b =>
                {
                    b.Navigation("books");

                    b.Navigation("children");
                });

            modelBuilder.Entity("EbookPlatform.Comment", b =>
                {
                    b.Navigation("subComments");
                });

            modelBuilder.Entity("EbookPlatform.DataLayer.Entities.AdminArea.Role.Permission", b =>
                {
                    b.Navigation("rolePermissions");
                });

            modelBuilder.Entity("EbookPlatform.DataLayer.Entities.AdminArea.Role.Role", b =>
                {
                    b.Navigation("adminUsers");

                    b.Navigation("rolePermissions");
                });

            modelBuilder.Entity("EbookPlatform.Language", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("EbookPlatform.Library", b =>
                {
                    b.Navigation("Shelves");
                });

            modelBuilder.Entity("EbookPlatform.Publisher", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("EbookPlatform.Shelf", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("EbookPlatform.Translator", b =>
                {
                    b.Navigation("books");
                });

            modelBuilder.Entity("EbookPlatform.User", b =>
                {
                    b.Navigation("comments");

                    b.Navigation("favorites");

                    b.Navigation("library")
                        .IsRequired();

                    b.Navigation("ratings");

                    b.Navigation("subComments");
                });
#pragma warning restore 612, 618
        }
    }
}
