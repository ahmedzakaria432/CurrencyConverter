using CurrencyConverter.Application.Currencies.Dtos;
using CurrencyConverter.Application.Currencies.Interfaces;
using CurrencyConverter.Application.Shared.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CurrencyConverter.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            this._currencyService = currencyService;
        }
        public Task<CurrencyDto> CreateAsync(CreateCurrencyDto entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<PagedResponse<CurrencyDto>> GetAllAsync(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            throw new NotImplementedException();
        }

        public Task<CurrencyDto?> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<CurrencyDto> GetCurrencyByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<CurrencyDto> UpdateAsync(Guid id, UpdateCurrencyDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
