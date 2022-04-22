using Core.Shared.Exceptions;
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
        
        public async Task<(Currency, ExchangeHistory)> GetCurrencyByNameAsync(string name)
        {
            var currency = await _dbContext.Currencies.FirstOrDefaultAsync(x => x.Name.ToLower().Contains(name.ToLower()));
            if (currency is null) throw new NotFoundException(nameof(currency), name);
            var lastExchange = currency.Exchanges.OrderByDescending(currency => currency.ExchangeDate).
                FirstOrDefault();
            if (lastExchange is null) throw new BadRequestException("this currency has no Exchanges");

            return (currency, lastExchange);

        }


    }
}
