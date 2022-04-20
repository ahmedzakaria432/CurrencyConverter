using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Peresistence.Data;

using Microsoft.EntityFrameworkCore;
using Core.Shared;
using Infrastructure.Peresistence.Shared;
using Application.Identity;
using Infrastructure.Infrastructure.Helpers.Middlewares;
using CurrencyConverter.Core.ExchangesHistory;
using CurrencyConverter.Infrastructure.Peresistence.Currencies;
using CurrencyConverter.Infrastructure.Peresistence.ExchangesHistory;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<Jwt>(cfg => configuration.GetSection("JWT"));
            services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            );
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ExceptionHandlingMiddleware>();
            services.AddScoped<IIdentityService,IdentityService>();
           
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IExchangeHistoryRepository, ExchangeHistoryRepository>();

           




            return services;
        }
    }
}
