﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Shared.Dtos
{
    public class PagedResponse<T>
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
        public int CountOfItems { get; set; }
        public int TotalPages =>(int) Math.Ceiling(TotalCount /(double) PageSize);
        public List<T> Items { get; set; }


    }
}
