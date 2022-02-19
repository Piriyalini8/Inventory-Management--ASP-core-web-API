using InventoryManagement.Models;
using InventoryManagement.Services;
using InventoryManagement.Services.ServiceImpl;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagement
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(Configuration["Data:InventData:ConnectionString"]));
            services.AddRazorPages();
            services.AddScoped<IInventoryService, InventoryServiceImpl>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (!env.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
