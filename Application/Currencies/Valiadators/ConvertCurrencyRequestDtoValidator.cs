using CurrencyConverter.Application.Currencies.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Application.Currencies.Valiadators
{
    public class ConvertCurrencyRequestDtoValidator : AbstractValidator<ConvertCurrencyRequestDto>
    {
        public ConvertCurrencyRequestDtoValidator()
        {
            RuleFor(x=>x.FromCurrency).NotEmpty().NotNull();
            RuleFor(x=>x.ToCurrency).NotEmpty().NotNull();
            RuleFor(x=>x.Amount).NotEmpty().NotNull();
        }
    }
}
