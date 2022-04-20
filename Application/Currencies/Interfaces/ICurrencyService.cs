using Application.Shared.Interfaces;
using CurrencyConverter.Application.Currencies.Dtos;
using CurrencyConverter.Core.Currencies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Currencies.Interfaces
{
    public interface ICurrencyService:IService<Currency,CurrencyDto,CreateCurrencyDto,UpdateCurrencyDto>
    {
        Task<CurrencyDto> GetCurrencyByNameAsync(string name);
    }
}
