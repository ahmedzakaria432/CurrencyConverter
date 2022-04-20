using CurrencyConverter.Core.ExchangesHistory;
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
           
        }
    }
}
