using ItServiceApp.Entity;
using ItServiceApp.Models.Entities;
using ItServiceApp.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ItServiceApp.Data //Mycontext'te veritabanına bağlı bilgilerin ayarlarının yapıldığı alan
{
    public class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>//primary keyleri string diye string yazdık. ApplicationUser'dan IdentityUser'a F12 yazarak görebilirsin.
    {

        public MyContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        public DbSet<Deneme> Denemeler { get; set; }
    }
}
