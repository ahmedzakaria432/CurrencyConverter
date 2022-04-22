using Application.Shared;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Shared;
using Core.Shared.Exceptions;
using CurrencyConverter.Application.Currencies.Dtos;
using CurrencyConverter.Application.Currencies.Interfaces;
using CurrencyConverter.Application.Shared.Dtos;
using CurrencyConverter.Application.Shared.Helpers;
using CurrencyConverter.Application.Shared.Interfaces;
using CurrencyConverter.Core.Currencies;
using CurrencyConverter.Core.ExchangesHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CurrencyConverter.Application.Extensions;
namespace CurrencyConverter.Application.Currencies
{
    public class CurrencyService : Service<Currency, CurrencyDto, CreateCurrencyDto, UpdateCurrencyDto>, ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IExchangeHistoryRepository _historyRepository;
        private readonly IDateTimeService _dateTimeService;

        public CurrencyService(ICurrencyRepository currencyRepository,
            IExchangeHistoryRepository historyRepository,
            IMapper mapper, IUnitOfWork unitOfWork, IDateTimeService dateTimeService) : base(currencyRepository, mapper,unitOfWork)
        {
            this._currencyRepository = currencyRepository;
            _historyRepository = historyRepository;
            this._dateTimeService = dateTimeService;
        }

        public override async Task<CurrencyDto> CreateAsync(CreateCurrencyDto entity)
        {
            var createdCurrency = await base.CreateAsync(entity);
            await _historyRepository.InsertAsync(PrepareExchangeHistory(entity, createdCurrency));

            await _unitOfWork.CommitAsync();

            createdCurrency.CurrentRate = entity.Rate;
            

            return createdCurrency ;
        }

                private  ExchangeHistory PrepareExchangeHistory(CreateCurrencyDto entity, CurrencyDto createdCurrency)
                {
                    return new ExchangeHistory()
                    {
                        CurrencyId = createdCurrency.Id,
                        ExchangeDate = _dateTimeService.Now,
                        Rate = entity.Rate
                    };
                }
        public override async Task<CurrencyDto> UpdateAsync(Guid id, UpdateCurrencyDto entity)
        {
            var currency = await _repository.GetByIdAsync(id);

            var updated = await base.UpdateAsync(id, entity);
            
            await UpdatedRateIfChanged(entity, currency);

            await _unitOfWork.CommitAsync();
            updated.CurrentRate = entity.CurrentRate;

            return updated;
        }

                private async Task UpdatedRateIfChanged(UpdateCurrencyDto entity, Currency? currency)
                {
                    var lastExchange = currency.Exchanges.OrderByDescending(x => x.ExchangeDate).First();

                    if (lastExchange?.Rate != entity.CurrentRate)
                        await _historyRepository.InsertAsync(new()
                        {
                            Currency = currency,
                            CurrencyId = currency.Id,
                            Rate = entity.CurrentRate,
                            ExchangeDate= _dateTimeService.Now
                        });
                }

        public async Task<CurrencyDto> GetCurrencyByNameAsync(string name)
        {
            var (currency, lastExchange) = await _currencyRepository.GetCurrencyByNameAsync(name); 

            var dto = _mapper.Map<CurrencyDto>(currency);
            dto.CurrentRate = lastExchange.Rate;
            return dto;
        }

        public override async Task<PagedResponse<CurrencyDto>> GetAllAsync(int pageNumber = 1, int pageSize = int.MaxValue)
        {
     
            var currencies= _repository.GetAsQueryable().Select(x => new CurrencyDto()
            {
                CurrentRate = x.Exchanges.OrderByDescending(o => o.ExchangeDate).First().Rate,
                Id = x.Id,
                Name = x.Name,
                Sign = x.Sign

            });
           
            var pagedList = await PagedList<CurrencyDto>.ToPagedListAsync(currencies, pageNumber, pageSize);
           
            return pagedList.ToPagedResponse();
        }

                private static PagedResponse<CurrencyDto> PreparePagedResponse(PagedList<CurrencyDto> pagedList)
                {
                    return new PagedResponse<CurrencyDto>()
                    {

                        TotalCount = pagedList.TotalCount,
                        CountOfItems = pagedList.Count,
                        PageNumber = pagedList.CurrentPage,
                        PageSize = pagedList.PageSize,
                        Items = pagedList
                    };
                }
        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }


        public async Task<PagedResponse<CurrencyDto>> GetHighestNCurrencies(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            IQueryable<CurrencyDto> currenciesWithHighst = GetCurenciesWithItsLastRate()
                                                                  .OrderByDescending(x => x.CurrentRate);

            var pagedList = await PagedList<CurrencyDto>.ToPagedListAsync(currenciesWithHighst, pageNumber, pageSize);

            return pagedList.ToPagedResponse();

        }

                private IQueryable<CurrencyDto> GetCurenciesWithItsLastRate()
                {
                    return _currencyRepository.GetAsQueryable().AsNoTracking().Select(x => new CurrencyDto()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Sign = x.Sign,
                        CurrentRate = x.Exchanges.OrderByDescending(o => o.ExchangeDate).First().Rate,

                    });
                }

        public async Task<PagedResponse<CurrencyDto>> GetLowestNCurrencies(int pageNumber, int pageSize)
        {
            IQueryable<CurrencyDto> currenciesWithHighst = GetCurenciesWithItsLastRate()
                                                                .OrderBy(x => x.CurrentRate);

            var pagedList = await PagedList<CurrencyDto>.ToPagedListAsync(currenciesWithHighst, pageNumber, pageSize);

            return pagedList.ToPagedResponse();
        }
    }

}
