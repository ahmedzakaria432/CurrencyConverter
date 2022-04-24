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
    //todo :: add validator for this class to defend methods
    //example for using :: validator.CheckIFCurrenciesExists( fromCurrency,toCurrency) to acheive SRP
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
            var currency = await _currencyRepository.GetByIdAsync(id);

            if (currency is null) throw new NotFoundException(nameof(currency),id);

            await UpdatedRateIfChanged(entity, currency);

            var updated = await base.UpdateAsync(id, entity);
            

            await _unitOfWork.CommitAsync();
            updated.CurrentRate = entity.CurrentRate;

            return updated;
        }

                private async Task UpdatedRateIfChanged(UpdateCurrencyDto entity, Currency currency)
                {
                    var lastExchange = currency.Exchanges.OrderByDescending(x => x.ExchangeDate).First();

                    if (lastExchange.Rate != entity.CurrentRate || lastExchange.ExchangeDate != entity.DateOfExchange)
                        await _historyRepository.InsertAsync(new()
                        {
                            Currency = currency,
                            CurrencyId = currency.Id,
                            Rate = entity.CurrentRate,
                            ExchangeDate= entity.DateOfExchange
                        });
                }

        public async Task<CurrencyDto> GetCurrencyByNameAsync(string name)
        {
            var (currency, lastExchange) = await _currencyRepository.GetCurrencyByNameAsync(name); 

            var dto = _mapper.Map<CurrencyDto>(currency);
            dto.CurrentRate = lastExchange.Rate;
            return dto;
        }
        //todo ::: may add dto for paginationRequest
        public override async Task<PagedResponse<CurrencyDto>> GetAllAsync(int pageNumber = 1, int pageSize = int.MaxValue)
        {
     
            var currencies = GetCurenciesWithItsLastRate();
           
            
           
            return (await PagedList<CurrencyDto>.ToPagedListAsync(currencies, pageNumber, pageSize)).ToPagedResponse();
        }

            
        public override async Task DeleteAsync(Guid id)
        {
            await base.DeleteAsync(id);
            await _unitOfWork.CommitAsync();
        }


        public async Task<PagedResponse<CurrencyDto>> GetHighestNCurrencies(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            IQueryable<CurrencyDto> highestCurrencies = GetCurenciesWithItsLastRate()
                                                                  .OrderBy(x => x.CurrentRate);

            var highestNCurrenciesPaged = await PagedList<CurrencyDto>.ToPagedListAsync(highestCurrencies, pageNumber, pageSize);

            return highestNCurrenciesPaged.ToPagedResponse();

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
            IQueryable<CurrencyDto> lowestCurrencies = GetCurenciesWithItsLastRate()
                                                                .OrderByDescending(x => x.CurrentRate);

            var lowestN = await PagedList<CurrencyDto>.ToPagedListAsync(lowestCurrencies, pageNumber, pageSize);

            return lowestN.ToPagedResponse();
        }

        public async Task<ConvertCurrencyResponseDto> ConvertFromCurrencyToAnother(ConvertCurrencyRequestDto convertCurrency)
        {
            var fromCurrencyWithLastRate = await GetCurenciesWithItsLastRate().SingleOrDefaultAsync(x => x.Id == convertCurrency.FromCurrency);
            var toCurrencyWithLastRate = await GetCurenciesWithItsLastRate().SingleOrDefaultAsync(x => x.Id == convertCurrency.ToCurrency);

            if (CheckIFCurrenciesExists(fromCurrencyWithLastRate, toCurrencyWithLastRate))
                throw new NotFoundException("one of your currencies or both was not found please check ids again");

            var ConvertedAmount =ConvertTo(convertCurrency, fromCurrencyWithLastRate, toCurrencyWithLastRate);

            return PrepareConvertCurrencyResponse(convertCurrency, fromCurrencyWithLastRate, toCurrencyWithLastRate, ConvertedAmount);

        }

                    private static bool CheckIFCurrenciesExists(CurrencyDto? fromCurrencyWithLastRate, CurrencyDto? toCurrencyWithLastRate)
                    {
                        return (fromCurrencyWithLastRate is null) || (toCurrencyWithLastRate is null);
                    }

                    //todo :: we may make this func as extension Method for ConvertCurrencyRequestDto class
                    private static ConvertCurrencyResponseDto PrepareConvertCurrencyResponse(ConvertCurrencyRequestDto convertCurrency, 
                        CurrencyDto fromCurrencyWithLastRate, CurrencyDto toCurrencyWithLastRate, double ConvertedAmount)
                    {
                        return new()
                        {
                            AmountOfFromCurrency = convertCurrency.Amount,
                            AmountOfToCurrency = ConvertedAmount,
                            FromCurrency = fromCurrencyWithLastRate.Name,
                            ToCurrency = toCurrencyWithLastRate.Name,
                            Summary = $"{convertCurrency.Amount} {fromCurrencyWithLastRate.Name}s = {ConvertedAmount} {toCurrencyWithLastRate.Name}s "

                        };
                    }

                    private static double ConvertTo(ConvertCurrencyRequestDto convertCurrency,
                        CurrencyDto fromCurrencyWithLastRate, CurrencyDto toCurrencyWithLastRate)
                    {
                        return Math.Round((Convert.ToDouble( convertCurrency.Amount) / fromCurrencyWithLastRate.CurrentRate)
                                                      * toCurrencyWithLastRate.CurrentRate,3);
                    }


        public async Task<PagedResponse<CurrencyImprovementOrFallenDto>> GetMostNImprovedCurrenciesByDate(GetMostImprovedRequest mostImprovedRequest, 
                                                       int pageNumber = 1, int pageSize = int.MaxValue) 
        {
            DateTime fromDate = mostImprovedRequest.FromDate;
            DateTime toDate = mostImprovedRequest.ToDate;

            var currenciesWithItsDifference = _currencyRepository.
                                                      GetMostNImprovedCurrenciesByDate(fromDate, toDate).
                                                      OfType<CurrencyImprovementOrFallenDto>();


            return ( await PagedList<CurrencyImprovementOrFallenDto>.
                ToPagedListAsync(currenciesWithItsDifference, pageNumber, pageSize)).ToPagedResponse();


        }

        public async Task<PagedResponse<CurrencyImprovementOrFallenDto>> GetLeastNImprovedCurrenciesByDate(GetMostImprovedRequest mostImprovedRequest,
                                                   int pageNumber = 1, int pageSize = int.MaxValue)
        {
            DateTime fromDate = mostImprovedRequest.FromDate;
            DateTime toDate = mostImprovedRequest.ToDate;

            var currenciesWithItsDifference = _currencyRepository.
                                                      GetLeastNImprovedCurrenciesByDate(fromDate, toDate)
                                                      .OfType<CurrencyImprovementOrFallenDto>();


            return (await PagedList<CurrencyImprovementOrFallenDto>.
                ToPagedListAsync(currenciesWithItsDifference, pageNumber, pageSize)).ToPagedResponse();


        }


    }

}
