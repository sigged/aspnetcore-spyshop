using CoreCourse.Spyshop.Domain.Settings;
using CoreCourse.Spyshop.Web.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoreCourse.Spyshop.Web
{
    public class Startup
    {
        IConfigurationRoot configuration = null;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            configuration = builder.Build();
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            services.Configure<SpyShopConfig>(configuration.GetSection("SpyShopConfig"));

            services.AddDbContext<SpyShopContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("SpyShopDb")));
    
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //Middleware #1: Has an exception occurred? Show detailed error message.
                app.UseDeveloperExceptionPage();

                //create a scope with which to get the DbContext service (yuck!)
                using (var serviceScope = app.ApplicationServices
                                                .GetRequiredService<IServiceScopeFactory>()
                                                .CreateScope())
                {
                    var context = serviceScope.ServiceProvider.GetService<SpyShopContext>(); //get DbContext
                    DataSeeder.Seed(context);
                }
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areaRoute",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );

                routes.MapRoute(
                    name: "searchByIdRoute",
                    template: "Search/{id:long}",
                    defaults: new { Controller = "Home", action = "SearchById" }
                );
                routes.MapRoute(
                    name: "searchByKeyRoute",
                    template: "Search/{searchkey}",
                    defaults: new { Controller = "Home", action = "SearchByKey" }
                );
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });

        }
    }
}
