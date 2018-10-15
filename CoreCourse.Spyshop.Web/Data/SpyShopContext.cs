using CoreCourse.Spyshop.Domain.Catalog;
using Microsoft.EntityFrameworkCore;

namespace CoreCourse.Spyshop.Web.Data
{
    public class SpyShopContext : DbContext
    {
        public SpyShopContext(DbContextOptions<SpyShopContext> options) : base(options)
        {
        }
        
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Product>()
                .Property(e => e.Name)
                .HasMaxLength(50)               //max 50 chars
                .IsRequired();                  //not nullable

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasColumnType("money");        //SQL datatype

            modelBuilder.Entity<Product>()
                .Property(e => e.PhotoUrl)
                .HasMaxLength(250);             //max 250 chars

            modelBuilder.Entity<Category>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Category>()
                .Property(e => e.Name)
                .HasMaxLength(50)               //max 50 chars
                .IsRequired();                  //not nullable

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)       //category has multiple products...
                .WithOne(p => p.Category)       //...which have only category
                .IsRequired()                   //product must always have a category
                .OnDelete(DeleteBehavior.Cascade); //automatically delete all products
                                                    //when category is deleted

            DataSeeder.Seed(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
    }
}
