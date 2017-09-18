using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CoreCourse.Spyshop.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //Middleware #1: Has an exception occurred? Show detailed error message.
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            //Middleware #2: show "Spy Shop" for URL /spyshop
            app.Use(async (context, next) => {
                //check Request URL Path
                if (context.Request.Path == "/spyshop")
                    await context.Response.WriteAsync("Spy Shop!");
                //pass request to the next Middleware
                await next.Invoke();
            });
            //Middleware #3: in all other cases, show "Hello World"
            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
