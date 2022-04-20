using CurrencyConverter.Core.Currencies;
using CurrencyConverter.Core.ExchangesHistory;
using Infrastructure.Peresistence.Data;
using Infrastructure.Peresistence.Shared;
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

       
    }
}
