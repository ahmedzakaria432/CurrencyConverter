﻿using Core.Shared;
using CurrencyConverter.Core.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.ExchangesHistory
{
    public class ExchangeHistory:BaseEntity
    {
        public Guid CurrencyId { get; set; }
        public DateOnly ExchangeDate { get; set; }
        public double Rate { get; set; }
        public Currency Currency { get; set; }
    }
}
