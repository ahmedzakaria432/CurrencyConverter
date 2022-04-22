using CurrencyConverter.Core.Currencies;
using CurrencyConverter.Core.ExchangesHistory;
using CurrencyConverter.Core.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyConverter.Infrastructure.Peresistence.Currencies
{
    public class CurrencyConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> builder)
        {
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Sign).IsRequired().HasMaxLength(100);
            builder.HasMany(x => x.Exchanges).WithOne(x => x.Currency).HasForeignKey(x => x.CurrencyId);
            builder.HasQueryFilter(x => !x.IsDeleted);


        }

        
    }
}
