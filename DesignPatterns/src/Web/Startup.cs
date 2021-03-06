using ApplicationCore.Interfaces;
using ApplicationCore.Rules;
using DesignPatternsInCSharp.ApplicationCore.Proxies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Web
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IItem, ItemProxy>();
            services.AddScoped<IGildedRose, IGildedRose>();

            services.AddScoped<IRule, AgedBrieRule>();
            services.AddScoped<IRule, BackstagePassRule>();
            services.AddScoped<IRule, ConjuredRule>();
            services.AddScoped<IRule, SulfurasRule>();
            services.AddScoped<IRule, NormalRule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
