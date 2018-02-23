using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CoreCourse.Spyshop.Web.Data
{

    public class SpyContextFactory : IDesignTimeDbContextFactory<SpyShopContext>
    {
        public SpyShopContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<SpyShopContext>();
            var connectionString = configuration.GetConnectionString("SpyShopDb");
            builder.UseSqlServer(connectionString);
            return new SpyShopContext(builder.Options);
        }
    }
}
