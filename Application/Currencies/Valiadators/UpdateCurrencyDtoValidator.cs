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
    public class UpdateCurrencyDtoValidator:AbstractValidator<UpdateCurrencyDto>
    {
        public UpdateCurrencyDtoValidator(IDateTimeService dateTime)
        {
            RuleFor(x => x.Name)
                .MaximumLength(100)
                .NotNull().NotEmpty();

            RuleFor(x=>x.Sign).MaximumLength(15)
                .NotEmpty().NotNull();

            RuleFor(x=>x.CurrentRate).NotEmpty().NotNull();

            RuleFor(x=>x.DateOfExchange).LessThanOrEqualTo(x=>dateTime.Now).NotNull().NotEmpty();
        }
    }
}
