using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.DbRepositories
{

    public class DbProductRepository : DbEntityRepository<Product>, IProductRepository
    {
        public DbProductRepository(ShopContext context) : base(context)
        {
        }

        public override IEnumerable<Product> Get()
        {
            return context.Products.AsNoTracking().ToList();
        }
    }
}
