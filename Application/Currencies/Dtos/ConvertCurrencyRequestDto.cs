using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Currencies.Dtos
{
    public class ConvertCurrencyRequestDto
    {
        public Guid FromCurrency { get; set; }
        public Guid ToCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
