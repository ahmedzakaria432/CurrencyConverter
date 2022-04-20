using AutoMapper;
using CurrencyConverter.Application.Currencies.Dtos;
using CurrencyConverter.Core.Currencies;
using CurrencyConverter.Core.ExchangesHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Currencies
{
    public class CurrencyProfile:Profile
    {
        public CurrencyProfile()
        {
            CreateMap<CreateCurrencyDto, Currency>();
            CreateMap<UpdateCurrencyDto, Currency>();
            CreateMap<Currency, CurrencyDto>();
             
        }
    }
}
