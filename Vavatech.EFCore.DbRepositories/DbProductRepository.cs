using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
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
    }
}
