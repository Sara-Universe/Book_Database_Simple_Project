using DataBaseExample.Models;
using Microsoft.EntityFrameworkCore;

namespace DataBaseExample.Data
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Relation one-to-many between Category and Book
            modelBuilder.Entity<User>  ()
                .HasMany (u => u.FavoriteBooks)
                . WithMany(b => b.FavoriteByUsers)
                .UsingEntity(t => t.ToTable("UserFavoriteBooks")); 
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
