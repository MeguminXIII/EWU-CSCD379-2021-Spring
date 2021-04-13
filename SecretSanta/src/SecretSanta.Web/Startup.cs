using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace SecretSanta.Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Cal:Add the hooks that allow us to use controllers with views
            services.AddControllersWithViews();
            //Cal:in the Api we dont return a view so only addControllers
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseStaticFiles();//cal: add to match lecture, unsure its purpose yet.

            app.UseEndpoints(endpoints =>
            {
                /*cal:removing this default. Is used to set things up manually
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello from Web!");
                });
                //end default
                */

                //cal:added this
                endpoints.MapDefaultControllerRoute();//cal: this sets things up in a default way
                
            });
        }
    }
}
