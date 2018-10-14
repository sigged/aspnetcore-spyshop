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
            DataSeeder.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
