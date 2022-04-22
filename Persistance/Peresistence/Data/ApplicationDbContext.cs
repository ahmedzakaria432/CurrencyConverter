using Core.Shared;
using CurrencyConverter.Core.Currencies;
using CurrencyConverter.Core.ExchangesHistory;
using CurrencyConverter.Infrastructure.Peresistence.Helpers;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Peresistence.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<ExchangeHistory> exchangeHistories { get; set; }


        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<BaseEntityWithDeleted>())
            {
                switch (entry.State)
                {
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.IsDeleted = true;
                        break;
                  
                    default:
                        break;
             
                }

            }


            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            DataSeeder.Seed(builder);
            
            base.OnModelCreating(builder);
        }
    }
}
