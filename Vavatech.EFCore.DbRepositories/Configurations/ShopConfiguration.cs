using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NetTopologySuite;
using nt = NetTopologySuite.Geometries;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.EFCore.DbRepositories.Configurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.Property(p => p.Location)
                .HasColumnType("geography");

            builder.Ignore(p => p.Distance);

            builder.HasData(SeedData());
        }

        private Shop[] SeedData()
        {
            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            Shop[] shops = new Shop[]
            {
                new Shop { Id = 1, Name = "Taj Mahal", Location = geometryFactory.CreatePoint(new nt.Coordinate(27.175015, 78.042155)) },
                new Shop { Id = 2, Name = "The Golden Temple of Amritsar", Location = geometryFactory.CreatePoint(new nt.Coordinate(31.619980, 74.876485)) },
                new Shop { Id = 3, Name = "The Red Fort, New Delhi", Location = geometryFactory.CreatePoint(new nt.Coordinate(28.656159, 77.241020)) },
                new Shop { Id = 4, Name = "The Gateway of India, Mumbai", Location = geometryFactory.CreatePoint(new nt.Coordinate(18.921984, 72.834654)) },
            };

            return shops;
        }
    }
}
