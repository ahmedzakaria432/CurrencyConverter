using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Core.Shared
{
    public static class CurrencyConverterDefaults
    {
        public static Guid BaseCurrencyId => new Guid("9C37C1E5-5E1B-4F06-AD7C-16E7A10D212D");
        public static string CurrencyName => "dollar";
        public static string Sign => "$";
        public static double Rate => 1;
    }
}
