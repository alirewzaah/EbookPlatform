using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public DbSet<Role> roles { get; set; }
        public DbSet<Permission> permissions { get; set; }
        public DbSet<RolePermission> rolePermissions { get; set; }
        public DbSet<UserRole> userRoles { get; set; }  
       // public DbSet<AdminUser> adminUsers { get; set; }
        public DbSet<Shelf> shelves { get; set; }
        public DbSet<Library> libraries { get; set; }
        public DbSet<BookCategory> bookCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
                fk.DeleteBehavior = DeleteBehavior.Restrict;

            base.OnModelCreating(modelBuilder);
        }



    }
}
