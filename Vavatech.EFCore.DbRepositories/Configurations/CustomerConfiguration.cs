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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.OwnsOne(p => p.InvoiceAddress);
            builder.OwnsOne(p => p.ShipAddress);
            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.Pesel).IsRequired().HasMaxLength(11).IsFixedLength().IsUnicode(false);

            builder.Property(p => p.Nickname).IsRequired().HasMaxLength(50);

            // Konfiguracja jeden-do-wielu + wymaganie, że FK jest not null
            //builder.HasMany(p => p.Orders)
            //    .WithOne(p => p.Customer)
            //    .IsRequired();

            // relacja jeden-do-jeden
            builder.HasOne(p => p.LoyaltyCard)
                .WithOne(p => p.Owner)
                .HasForeignKey<LoyaltyCard>(p=>p.OwnerId);

            builder.HasQueryFilter(p => !p.IsRemoved);

        }
    }
}
