using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrchardCore.Modules;
using System;
using Hosting = Microsoft.AspNetCore.Hosting;


namespace JZSoft.OrchardCore.AmisEditor
{
    public class Startup : StartupBase
    {
        private readonly Hosting.IWebHostEnvironment env;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration, Hosting.IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public override void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            { 
                configuration.RootPath = "ClientApp/build";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public override void Configure(IApplicationBuilder app, IEndpointRouteBuilder routes, IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller}/{action=Index}/{id?}");
            //}); 
            routes.MapAreaControllerRoute(
               name: "Home",
               areaName: "JZSoft.OrchardCore.Amis",
               pattern: "Home/Index",
               defaults: new { controller = "Home", action = "Index" }
           );

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";
                //if (env.IsDevelopment())
                //{
                //    spa.UseReactDevelopmentServer(npmScript: "start");
                //}
            });
        }
    }
}
