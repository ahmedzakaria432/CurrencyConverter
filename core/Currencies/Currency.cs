using Core.Shared;
using CurrencyConverter.Core.ExchangesHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.Currencies
{
    public class Currency:BaseEntityWithDeleted
    {
      
        public string Name { get; set; }
        public string Sign { get; set; }

        public virtual List<ExchangeHistory> Exchanges { get; set; }

    }
}
