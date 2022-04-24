
using CurrencyConverter.Application.Currencies;
using CurrencyConverter.Application.Currencies.Interfaces;
using CurrencyConverter.Application.Shared.Helpers;
using CurrencyConverter.Application.Shared.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace CurrencyConverter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IDateTimeService, DateTimeService>();


            return services;
        }
    }
}
