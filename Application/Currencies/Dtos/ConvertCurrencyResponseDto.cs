using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Currencies.Dtos
{
    public class ConvertCurrencyResponseDto
    {
        public decimal AmountOfFromCurrency { get; set; }
        public string FromCurrency { get; set; }
        public double AmountOfToCurrency { get; set; }
        public string ToCurrency { get; set; }
        public string Summary { get; set; }
    }
}
