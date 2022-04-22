using CurrencyConverter.Application.Currencies.Dtos;
using CurrencyConverter.Application.Shared.Dtos;
using CurrencyConverter.Application.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Extensions
{
    public static class DtosExtensions
    {

        public static PagedResponse<T> ToPagedResponse<T>(this PagedList<T> pagedList)
        {
            return new PagedResponse<T>()
            {

                TotalCount = pagedList.TotalCount,
                CountOfItems = pagedList.Count,
                PageNumber = pagedList.CurrentPage,
                PageSize = pagedList.PageSize,
                Items = pagedList
            };
        }
    }
}
