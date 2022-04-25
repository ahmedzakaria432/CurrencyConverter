using Core.Shared.Exceptions;
using CurrencyConverter.Application.Currencies.Dtos;
using CurrencyConverter.Core.Currencies;
using CurrencyConverter.Core.ExchangesHistory;
using Infrastructure.Peresistence.Data;
using Infrastructure.Peresistence.Shared;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infrastructure.Peresistence.Currencies
{
    public class CurrencyRepository:Repository<Currency>,ICurrencyRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public CurrencyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            
        }
        
        public  IQueryable GetCurrencyByNameAsync(string name)
        {
            var currencies = SearchCurrenciesByNameGetLastRate(name);

            return currencies;

        }
        IQueryable<CurrencyDto> SearchCurrenciesByNameGetLastRate(string name)
        {
            return GetAsQueryable().AsNoTracking().Where(x => x.Name.ToLower().Contains(name.ToLower()))
                .Select(x => new CurrencyDto()
            {
                Id = x.Id,
                Name = x.Name,
                Sign = x.Sign,
                CurrentRate = x.Exchanges.OrderByDescending(o => o.ExchangeDate).First().Rate,

            });
        }
        public IQueryable GetMostNImprovedCurrenciesByDate(DateTime fromDate, DateTime toDate)
        {
            var currenciesWithItsDifference = GetCurrenciesWithDifferences(fromDate, toDate);
            
            currenciesWithItsDifference = currenciesWithItsDifference.Where(x => x.ChangeRate < 0)
                                                                     .OrderBy(x => x.ChangeRate);

            return currenciesWithItsDifference;
        }

        public IQueryable GetLeastNImprovedCurrenciesByDate(DateTime fromDate, DateTime toDate)
        {
            IQueryable<CurrencyImprovementOrFallenDto> currenciesWithItsDifference = 
                                                         GetCurrenciesWithDifferences(fromDate, toDate);

            currenciesWithItsDifference = currenciesWithItsDifference.Where(x => x.ChangeRate > 0)
                                                                     .OrderByDescending(x => x.ChangeRate);

            return currenciesWithItsDifference;
        }

        private IQueryable<CurrencyImprovementOrFallenDto> GetCurrenciesWithDifferences(DateTime fromDate, DateTime toDate)
        {
                                 return GetAsQueryable()
                                     .Select(x => new CurrencyImprovementOrFallenDto()
                                     {
                                         Id = x.Id,
                                         Name = x.Name,
                                         Sign = x.Sign,
                                         ChangeRate = x.Exchanges.Where(x => x.ExchangeDate >= fromDate && 
                                                                             x.ExchangeDate <= toDate)
                                                                 .OrderByDescending(o => o.ExchangeDate).First().Rate

                                                     - (x.Exchanges.Where(x => x.ExchangeDate >= fromDate && 
                                                                               x.ExchangeDate <= toDate)
                                                                 .OrderByDescending(o => o.ExchangeDate).Last().Rate),

                                     });
        }

   
    }
}
