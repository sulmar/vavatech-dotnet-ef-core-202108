using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;

namespace Vavatech.EFCore.DbRepositories.Configurations
{
    public class LoyaltyCardConfiguration : IEntityTypeConfiguration<LoyaltyCard>
    {
        public void Configure(EntityTypeBuilder<LoyaltyCard> builder)
        {
            // builder.HasData(SeedData());
        }

        private IEnumerable<LoyaltyCard> SeedData()
        {
            yield return new LoyaltyCard { Id = 1, SerialNumber = "111111", ExpirationDate = DateTime.Today.AddDays(30), CreatedOn = DateTime.Now };
            yield return new LoyaltyCard { Id = 2, SerialNumber = "222222", ExpirationDate = DateTime.Today.AddDays(30), CreatedOn = DateTime.Now };
            yield return new LoyaltyCard { Id = 3, SerialNumber = "333333", ExpirationDate = DateTime.Today.AddDays(30), CreatedOn = DateTime.Now };
        }
    }
}
