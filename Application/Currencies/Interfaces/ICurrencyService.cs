using Application.Shared.Interfaces;
using CurrencyConverter.Application.Currencies.Dtos;
using CurrencyConverter.Application.Shared.Dtos;
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
        Task<PagedResponse<CurrencyDto>> GetHighestNCurrencies(int pageNumber = 1, int pageSize = int.MaxValue);
        Task<PagedResponse<CurrencyDto>> GetLowestNCurrencies(int pageNumber, int pageSize);
    }
}
