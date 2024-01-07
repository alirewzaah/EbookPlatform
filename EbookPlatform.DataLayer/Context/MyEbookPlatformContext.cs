using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EbookPlatform.DataLayer.Entities.AdminArea.Role;
using Microsoft.EntityFrameworkCore;

namespace EbookPlatform
{
    public class MyEbookPlatformContext : DbContext
    {
        public MyEbookPlatformContext(DbContextOptions<MyEbookPlatformContext> options) : base(options)
        {

        }
        public DbSet<Author> authors { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<Cart> carts { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<CartItem> cartItems { get; set; }
        public DbSet<Favorite> favorites { get; set; }
        public DbSet<Language> languages { get; set; }
        public DbSet<Publisher> publishers { get; set; }
        public DbSet<Rating> ratings { get; set; }
        public DbSet<SubCategory> subCategories { get; set; }
        public DbSet<Translator> translators { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<SubComment> subComments { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<RolePermission> rolePermissions { get; set; }
        public DbSet<AdminUser> adminUsers { get; set; }
        public DbSet<Shelf> shelves { get; set; }
        public DbSet<Library> libraries { get; set; }
        public DbSet<BookCategory> bookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region[SeedData-adminArea]
            modelBuilder.Entity<Permission>().HasData(new Permission()
            {
                permissionID = 1,
                permissionTitle = "ContentManager",

            },
            new Permission()
            {
                permissionID = 2,
                permissionTitle = "UserManager"
            },
            new Permission()
            {
                permissionID = 3,
                permissionTitle = "AdminUserManager"
            },
            new Permission()
            {
                permissionID = 4,
                permissionTitle = "CommentsManager"
            },
            new Permission()
            {
                permissionID = 5,
                permissionTitle = "ReportsManager"
            }
);
            modelBuilder.Entity<Role>().HasData(new Role
            {
                roleID = 1,
                roleTitle = "sa",

            });


            modelBuilder.Entity<RolePermission>().HasData(new RolePermission()
            {
                rolePermissionID = 1,
                roleid = 1,
                permissionid = 1
            },
            new RolePermission()
            {
                rolePermissionID = 2,
                roleid = 1,
                permissionid = 2
            },
            new RolePermission()
            {
                rolePermissionID = 3,
                roleid = 1,
                permissionid = 3
            },
            new RolePermission()
            {
                rolePermissionID = 4,
                roleid = 1,
                permissionid = 4
            },
            new RolePermission()
            {
                rolePermissionID = 5,
                roleid = 1,
                permissionid = 5
            }
            );
            modelBuilder.Entity<AdminUser>().HasData(new AdminUser()
            {
                adminUserID = 1,
                adminUserName = "admin",
                adminUserEmail = "admin@admin.ir",
                adminUserPassword = "admin",
                roleID = 1,

            }
);
            #endregion


            #region[SeedData-Category]
            /*
            modelBuilder.Entity<Category>().HasData(new Category()
            {
                categoryID = 1,
                title = "داستان و رمان خارجی",
                isDeleted = false

            },
            new Category()
            {
                categoryID = 1,
                title = "داستان و رمان ایرانی",
                isDeleted = false
            },
            );

            */
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
