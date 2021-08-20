using NetTopologySuite.Geometries;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.DbRepositories
{
    public class DbShopRepository : IShopRepository
    {
        private readonly ShopContext context;

        public DbShopRepository(ShopContext context)
        {
            this.context = context;
        }

        public IEnumerable<Shop> Get()
        {
            return context.Shops.ToList();
        }

        public IEnumerable<Shop> Get(Point point, int distance)
        {
            var query = context.Shops
                    .Select(s => new { s.Id, s.Name, Distance = s.Location.Distance(point) }).ToList();

            return context.Shops.Where(p => p.Location.IsWithinDistance(point, distance)).ToList();
        }
    }
}
