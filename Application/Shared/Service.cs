using Application.Shared.Dtos;
using Application.Shared.Interfaces;
using AutoMapper;
using Core.Shared;
using Core.Shared.Exceptions;
using CurrencyConverter.Application.Shared.Dtos;
using CurrencyConverter.Application.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared
{
    public class Service<TEntity,TDto,TCreateDto,TUpdateDto> : IService<TEntity,TDto, TCreateDto, TUpdateDto> where TEntity : BaseEntity
                                                                where TDto : BaseDto
    {
        protected readonly IRepository<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public Service(IRepository<TEntity> repository,IMapper mapper,IUnitOfWork unitOfWork)
        {
            this._repository = repository;
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity= await GetByIdAsync(id);
            
            await _repository.DeleteAsync(_mapper.Map<TEntity>(entity));
        }

        public virtual async Task<PagedResponse<TDto>> GetAllAsync(int pageNumber = 1, int pageSize = int.MaxValue)
        {
            Expression<Func<TEntity, bool>>? expression = null;


            var entities = (await _repository.GetRangeAsync(expression));

            var pagedList = await PagedList<TEntity>.ToPagedListAsync(entities, pageNumber, pageSize);


            return PreparePagedResponse(pagedList);
        }

                protected PagedResponse<TDto> PreparePagedResponse(PagedList<TEntity> pagedList)
                {
                    return new()
                    {

                        TotalCount = pagedList.TotalCount,
                        CountOfItems = pagedList.Count,
                        PageNumber = pagedList.CurrentPage,
                        PageSize = pagedList.PageSize,
                        Items = _mapper.Map<List<TEntity>, List<TDto>>(pagedList)

                    };
                }

        public virtual async Task<TDto?> GetByIdAsync(Guid id)
        {
            var entity=await _repository.GetByIdAsync(id);
            if(entity is null) throw new NotFoundException(nameof(entity),id);
            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> CreateAsync(TCreateDto entity)
        {
            
            var crearedEntity = await _repository.InsertAsync(_mapper.Map<TEntity>(entity));
            return _mapper.Map<TDto>(crearedEntity);
           
        }

        public virtual async Task<TDto> UpdateAsync(Guid id, TUpdateDto entity)
        {
            var EntityToUpdate = await _repository.GetByIdAsync(id);
            if (EntityToUpdate is null) throw new NotFoundException();
            var updatedEntity = await _repository.UpdateAsync(_mapper.Map(entity,EntityToUpdate));
            return _mapper.Map<TDto>( updatedEntity);

        }
    }
}
