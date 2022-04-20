using Application.Shared;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Shared;
using Core.Shared.Exceptions;
using CurrencyConverter.Application.Currencies.Dtos;
using CurrencyConverter.Application.Currencies.Interfaces;
using CurrencyConverter.Application.Shared.Dtos;
using CurrencyConverter.Application.Shared.Helpers;
using CurrencyConverter.Core.Currencies;
using CurrencyConverter.Core.ExchangesHistory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Currencies
{
    public class CurrencyService : Service<Currency, CurrencyDto, CreateCurrencyDto, UpdateCurrencyDto>, ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IExchangeHistoryRepository _historyRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CurrencyService(ICurrencyRepository repository,
            IExchangeHistoryRepository historyRepository,
            IMapper mapper, IUnitOfWork unitOfWork) : base(repository, mapper)
        {
            _currencyRepository = repository;
            _historyRepository = historyRepository;
            this._mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public override async Task<CurrencyDto> CreateAsync(CreateCurrencyDto entity)
        {
            var createdCurrency = await base.CreateAsync(entity);
            await _historyRepository.InsertAsync(PrepareExchangeHistory(entity, createdCurrency));

            await _unitOfWork.CommitAsync();

            createdCurrency.CurrentRate = entity.Rate;
            

            return createdCurrency ;
        }

                private static ExchangeHistory PrepareExchangeHistory(CreateCurrencyDto entity, CurrencyDto createdCurrency)
                {
                    return new ExchangeHistory()
                    {
                        CurrencyId = createdCurrency.Id,
                        ExchangeDate = DateOnly.FromDateTime(DateTime.Now),
                        Rate = entity.Rate
                    };
                }
        public override async Task<CurrencyDto> UpdateAsync(Guid id, UpdateCurrencyDto entity)
        {
            var currency = await _currencyRepository.GetByIdAsync(id);

            var updated = await base.UpdateAsync(id, entity);
            
            await UpdatedRateIfChanged(entity, currency);
            updated.CurrentRate = entity.CurrentRate;

            await _unitOfWork.CommitAsync();

            return updated;
        }

                private async Task UpdatedRateIfChanged(UpdateCurrencyDto entity, Currency? currency)
                {
                    var lastExchange = currency?.Exchanges.MaxBy(x => x.ExchangeDate);

                    if (lastExchange?.Rate != entity.CurrentRate)
                        await _historyRepository.InsertAsync(new()
                        {
                            Currency = currency,
                            CurrencyId = currency.Id,
                            Rate = entity.CurrentRate
                        });
                }

        public async Task<CurrencyDto> GetCurrencyByNameAsync(string name)
        {
          var currency= (await _currencyRepository.GetRangeAsync()).FirstOrDefault(x=>x.Name==name);

            return _mapper.Map<CurrencyDto>(currency);
        }

        public override async Task<PagedResponse<CurrencyDto>> GetAllAsync(int pageNumber = 1, int pageSize = int.MaxValue)
        {



            var entities = (await _currencyRepository.GetRangeAsync());

           
            var pagedList = PagedList<CurrencyDto>.ToPagedList(_mapper.ProjectTo<CurrencyDto>(entities), pageNumber, pageSize);
           
            return PreparePagedResponse(pagedList);
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
    }

}
