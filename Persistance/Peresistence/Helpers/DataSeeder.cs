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

                Id = Guid.NewGuid(),
                Rate = CurrencyConverterDefaults.Rate,
                CurrencyId = CurrencyConverterDefaults.BaseCurrencyId,
                ExchangeDate = new DateOnly(2022, 4, 19)

            });

            return builder;
        }
    }
}
