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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p=>p.OrderDate).HasColumnType("datetime2").HasPrecision(3);


            // Konfiguracja jeden-do-wielu + wymaganie, że FK jest not null
            builder
                .HasOne(p => p.Customer)
                .WithMany(p => p.Orders)
                .IsRequired();

            // usuwanie kaskadowe
            builder.HasMany(p => p.Details)
                .WithOne(p => p.Order)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
