using CoreCourse.Spyshop.Domain.Catalog;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreCourse.Spyshop.Web.Data
{
    public class SpyShopContext : DbContext
    {
        public SpyShopContext(DbContextOptions<SpyShopContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
