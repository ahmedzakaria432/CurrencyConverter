using Application.Samples;
using Application.Samples.Interfaces;
using CurrencyConverter.Application.Currencies;
using CurrencyConverter.Application.Currencies.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ISampleService, SampleService>();

            services.AddScoped<ICurrencyService, CurrencyService>();


            return services;
        }
    }
}
