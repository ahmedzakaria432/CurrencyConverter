using CurrencyConverter.Core.ExchangesHistory;
using Infrastructure.Peresistence.Data;
using Infrastructure.Peresistence.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infrastructure.Peresistence.ExchangesHistory
{
    public class ExchangeHistoryRepository:Repository<ExchangeHistory>,IExchangeHistoryRepository
    {
        public ExchangeHistoryRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
