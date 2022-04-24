using Application.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Currencies.Dtos
{
    public class CurrencyImprovementOrFallenDto: BaseDto
    {

        public string Name { get; set; }
        public string Sign { get; set; }
        public double ChangeRate { get; set; }
    }
}
