using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace UpSkillingTask.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                          .HasMany(e => e.Books)
                          .WithOne(e => e.Category)
                          .HasForeignKey("CategoryId")
                          .IsRequired();

            modelBuilder.Entity<Book>()
                .HasCheckConstraint("CK_Book_Price_NonNegative", "[Price] >= 0");
            modelBuilder.Entity<Book>()
                .HasCheckConstraint("CK_Book_Stock_NonNegative", "[Stock] >= 0");


            base.OnModelCreating(modelBuilder);

        }
    }
}
