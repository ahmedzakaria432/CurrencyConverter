using CurrencyConverter.Core.ExchangesHistory;
using CurrencyConverter.Core.Shared;
using CurrencyConverter.Infrastructure.Peresistence.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infrastructure.Peresistence.ExchangesHistory
{
    public class ExchangeHistoryConfiguration : IEntityTypeConfiguration<ExchangeHistory>
    {
         
        public void Configure(EntityTypeBuilder<ExchangeHistory> builder)
        {
            builder.Property(x => x.ExchangeDate).IsRequired();
            builder.Property(x => x.Rate).IsRequired();
            builder.HasIndex(x => x.ExchangeDate);
            builder.HasQueryFilter(x=>!x.Currency.IsDeleted);
        
        }
    }
}
