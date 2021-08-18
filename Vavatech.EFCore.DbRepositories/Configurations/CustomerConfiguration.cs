using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Newtonsoft.Json;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
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


            // Konwersja za pomocą wyrażeń lambda
            //builder.Property(p => p.Location)
            //    .HasConversion(
            //        coordinate => coordinate.ToGeoHash(),
            //        value => Coordinate.FromGeoHash(value)
            //    );

            // Konwersja za pomocą klasy
            //builder.Property(p => p.Location)
            //    .HasConversion(new GeoHashConverter());

            builder.Property(p => p.Location)
                .HasGeoHash();

            builder.Property(p => p.CustomerType)
                .HasConversion(new EnumToStringConverter<CustomerType>());

            //builder.Property(p => p.Location)
            //    .HasConversion(
            //      coordinate => JsonConvert.SerializeObject(coordinate),
            //        value => JsonConvert.DeserializeObject<Coordinate>(value)
            //    );


            builder.Property(p => p.CreatedOn)
               .HasDefaultValueSql("getdate()")
               .ValueGeneratedOnAdd();

            builder.Property(p => p.ModifiedOn)
                .HasDefaultValueSql("getdate()")
                .ValueGeneratedOnUpdate();


            builder.Property(p => p.Credit).HasDefaultValue(100);


        }
    }



    public class GeoHashConverter : ValueConverter<Coordinate, string>
    {
        public GeoHashConverter()
            : base(
                  coordinate => coordinate.ToGeoHash(),
                    value => Coordinate.FromGeoHash(value)
                  )
        {
        }
    }

    public static class GeoHashExtensions
    {
        public static PropertyBuilder HasGeoHash(this PropertyBuilder propertyBuilder)
        {
            propertyBuilder.HasConversion(new GeoHashConverter());

            return propertyBuilder;
        }
    }


}
