using Application.Shared.Dtos;
using Core.Shared;
using CurrencyConverter.Application.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Shared.Interfaces
{
    public interface IService<TEntity,TDto, TCreateDto, TUpdateDto> where TEntity : BaseEntity 
                                            where  TDto : BaseDto
    {
        Task<TDto?> GetByIdAsync(Guid id);
        Task<TDto> CreateAsync(TCreateDto entity);
        Task<TDto> UpdateAsync(Guid id , TUpdateDto entity);
        Task DeleteAsync(Guid id);
        Task<PagedResponse<TDto>> GetAllAsync(int pageNumber = 1, int pageSize = int.MaxValue);

    }
}
