﻿using Core.Shared;
using CurrencyConverter.Core.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.ExchangesHistory
{
    public interface ICurrencyRepository:IRepository<Currency>
    {
        Task<(Currency, ExchangeHistory)> GetCurrencyByNameAsync(string name);
        IQueryable GetMostNImprovedCurrenciesByDate(DateTime fromDate,DateTime toDate);
    }
}
