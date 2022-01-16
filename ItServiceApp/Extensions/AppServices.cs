using ItServiceApp.InjectOrnek;
using ItServiceApp.MapperProfiles;
using ItServiceApp.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace ItServiceApp.Extensions
{
    public static class AppServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Cookie Settings
            services.ConfigureApplicationCookie(options => //Çerez ayarları
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.SlidingExpiration = true;
            });

            services.AddAutoMapper(options =>
            {
                options.AddProfile(typeof(AccountProfile));
                options.AddProfile(typeof(PaymentProfile));
            });

            services.AddTransient<IEmailSender, EmailSender>(); //Transient ihtiyaç anında kullanılıyor.
            services.AddScoped<IPaymentService,IyzicoPaymentService>();
            services.AddScoped<IMyDependency, NewMyDependency>(); //loose couplin, Scoped tanımlayınca proje boyunca kullanılıyor.
            //services.AddTransient<EmailSender>();

            return services;
        }
    }
}
