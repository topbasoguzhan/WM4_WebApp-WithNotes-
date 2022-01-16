using ItServiceApp.Data;
using ItServiceApp.Extensions;
using ItServiceApp.InjectOrnek;
using ItServiceApp.MapperProfiles;
using ItServiceApp.Models.Identity;
using ItServiceApp.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace ItServiceApp
{
    public class Startup //Konfig�rasyon ayarlar�m�z� burada yap�yoruz.
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MyContext>(options => //burda da context'i ba�l�yoruz.
            {
                options.UseSqlServer(Configuration.GetConnectionString("SqlConnection")); //appsettings.com veritaban� connection ayar�n� yapm�� oluyoruz burada.
            });
            services.AddIdentity<ApplicationUser, ApplicationRole>(options => //burda servis ayar� yapm�� oluyoruz. Injection yapm�� oluyoruz bu g�rd���n yap�da ApplicationUser'� ve ApplicationRole'u.
             {
                 options.Password.RequireDigit = true;
                 options.Password.RequireLowercase = false;
                 options.Password.RequiredLength = 5;
                 options.Password.RequireUppercase = false;
                 options.Password.RequireNonAlphanumeric = false;

                 options.Lockout.MaxFailedAccessAttempts = 3;
                 options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                 options.Lockout.AllowedForNewUsers = false;

                 options.User.RequireUniqueEmail = true;
                 options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ-._@+";

             }).AddEntityFrameworkStores<MyContext>().AddDefaultTokenProviders();
            services.AddApplicationServices(this.Configuration);
            services.AddControllersWithViews();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
           
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
