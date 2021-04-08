using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TheBakingCentre.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;

namespace TheBakingCentre
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }
        
        // AI- added this code to inject appsettings.json and access it properties 
        //appsettings is configured in createHostbuilder method of program.cs
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // AI- This method gets called by the runtime. Use this method to add services to the container.

        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            //adds basic authentication into the system and specifies that EFCore store is used for storing Identity infomation using the corresponding dbcontext class

            services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppDbContext>();

            services.AddScoped<IPieRepository, PieRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            //creates a scoped instance of shopping cart through the static method of GetCart. It's coped because everytime a user makes a request, the shopping cart instance is created/retrieved through GetCart and through out that same request, this instance remains alive and associated with all operations in the request

            services.AddScoped<ShoppingCart>(sp => ShoppingCart.GetCart(sp));
            services.AddHttpContextAccessor();
            services.AddSession();

            //added support for MVC
            services.AddControllersWithViews();

            //added for identity razor pages
            services.AddRazorPages();

            //make changes in UI and webpage is updated without re-running app
            services.AddRazorPages().AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //ai
            app.UseHttpsRedirection();
            // ai added- looks nfor wwwroot folder 
            app.UseStaticFiles();
            app.UseSession(); //for shopping cart

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}" );
                
                //identity pages
                endpoints.MapRazorPages();

                /*endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });*/
            });
        }
    }
}
