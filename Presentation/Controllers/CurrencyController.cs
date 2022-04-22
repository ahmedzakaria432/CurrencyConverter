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
            _currencyService = currencyService;
        }
        [HttpPost("AddCurrency")]
        public async Task<ActionResult<CurrencyDto>> Create(CreateCurrencyDto entity)
        {
           return Ok( await _currencyService.CreateAsync(entity));
        }
        [HttpDelete("DeleteCurrency")]
        public async Task< ActionResult> Delete(Guid id)
        {
            await _currencyService.DeleteAsync(id);
            return NoContent();
        }
        [HttpGet("GetAllCurrencies")]
        public async Task<ActionResult<PagedResponse<CurrencyDto>>> GetAll(int pageNumber = 1, int pageSize = int.MaxValue)
        {
           return Ok((await _currencyService.GetAllAsync(pageNumber, pageSize)));
        }


        [HttpGet("GetCurrencyByName")]
        public async Task<ActionResult< CurrencyDto>> GetCurrencyByName(string name)
        {
            return Ok( await _currencyService.GetCurrencyByNameAsync(name));
        }
        [HttpPut("UpdateCurrency")]
        public async Task<ActionResult< CurrencyDto>> Update(Guid id, UpdateCurrencyDto entity)
        {
            return Ok(await _currencyService.UpdateAsync(id, entity));
        }
        [HttpGet("GetHighestNCurrencies")]
        public async Task<ActionResult<PagedResponse<CurrencyDto>>> GetHighestNCurrencies(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            return Ok(await _currencyService.GetHighestNCurrencies(pageNumber,pageSize));
        }

        [HttpGet("GetLowestNCurrencies")]
        public async Task<ActionResult<PagedResponse<CurrencyDto>>> GetLowestNCurrencies(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            return Ok(await _currencyService.GetLowestNCurrencies(pageNumber, pageSize));
        }


    }
}
