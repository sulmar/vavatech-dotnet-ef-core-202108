using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.EFCore.DbRepositories.Configurations
{
    public class TotalAmountCountryConfiguration : IEntityTypeConfiguration<TotalAmountCountry>
    {
        public void Configure(EntityTypeBuilder<TotalAmountCountry> builder)
        {
            builder.HasNoKey();

            builder.ToView("vwTotalAmountByCountry", "dbo");
        }
    }
}
