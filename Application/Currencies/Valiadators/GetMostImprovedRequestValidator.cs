using CurrencyConverter.Application.Currencies.Dtos;
using CurrencyConverter.Application.Shared.Interfaces;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Currencies.Valiadators
{
    public class GetMostImprovedRequestValidator: AbstractValidator<GetMostImprovedRequest>
    {

        public GetMostImprovedRequestValidator(IDateTimeService dateTimeService)
        {
            RuleFor(x=>x.FromDate).LessThanOrEqualTo(x=>dateTimeService.Now).NotEmpty().NotNull();
            RuleFor(x=>x.ToDate).LessThanOrEqualTo(x=>dateTimeService.Now).NotEmpty().NotNull();
        }
    }
}
