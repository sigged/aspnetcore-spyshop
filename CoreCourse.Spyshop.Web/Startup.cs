using CoreCourse.Spyshop.Domain;
using CoreCourse.Spyshop.Domain.Catalog;
using CoreCourse.Spyshop.Domain.Settings;
using CoreCourse.Spyshop.Domain.Shopping;
using CoreCourse.Spyshop.Web.Data;
using CoreCourse.Spyshop.Web.Globalization;
using CoreCourse.Spyshop.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;

namespace CoreCourse.Spyshop.Web
{
    public class Startup
    {
        private IHostingEnvironment env = null;

        public Startup(IConfiguration configuration, IHostingEnvironment environment)
        {
            Configuration = configuration;
            env = environment;
        }

        public IConfiguration Configuration { get; }      
  
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<SpyShopConfig>(Configuration.GetSection("SpyShopConfig"));

            services.AddDbContext<SpyShopContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SpyShopDb")));

            //Register repositories, so IRepository can be injected
            services.AddTransient<IRepository<Product, long>, EfRepository<Product, long>>();
            services.AddTransient<IRepository<Category, long>, EfRepository<Category, long>>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ICartService, CookieCartService>();

            //Configure request localization
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var globalizationService = new GlobalizationService(env);
                var supportedCultures = globalizationService.GetSupportedCldrLocales();
                options.DefaultRequestCulture = new RequestCulture(globalizationService.GetFallbackCulture());
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            //enable Request Locatization Middleware
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);

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
