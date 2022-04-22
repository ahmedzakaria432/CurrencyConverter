using CurrencyConverter.Core.Currencies;
using CurrencyConverter.Core.ExchangesHistory;
using CurrencyConverter.Core.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infrastructure.Peresistence.Helpers
{
    internal class DataSeeder
    {
       internal static ModelBuilder Seed(ModelBuilder builder) 
        {
            builder.Entity<Currency>().HasData(new Currency()
            {

                Id = CurrencyConverterDefaults.BaseCurrencyId,
                IsDeleted = false,
                Name = CurrencyConverterDefaults.CurrencyName,
                Sign = CurrencyConverterDefaults.Sign,

            });

            builder.Entity<ExchangeHistory>().HasData(new ExchangeHistory
            {

                Id = new Guid("498531C9-AF8C-41A4-9530-D0CAD1FA3674"),
                Rate = CurrencyConverterDefaults.Rate,
                CurrencyId = CurrencyConverterDefaults.BaseCurrencyId,
                ExchangeDate =DateTime.Parse("2022-04-19 14:50:39.9980887"),

            });

            return builder;
        }
    }
}
