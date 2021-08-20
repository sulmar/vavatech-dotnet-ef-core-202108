using LinqKit;
using Microsoft.Data.SqlClient;
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

        //public override IEnumerable<Product> Get()
        //{
        //    return context.Products.AsNoTracking().ToList();
        //}

        public IEnumerable<Product> GetByColor(string color)
        {
            var colorParameter = new SqlParameter("Color", color);

            return context.Products.FromSqlRaw("EXECUTE uspGetProductsByColor @Color", colorParameter).ToList();
        }

        // Predicate Builder
        // http://www.albahari.com/nutshell/predicatebuilder.aspx
        // dotnet add package LinqKit.Microsoft.EntityFrameworkCore
        public IEnumerable<Product> GetByColors(params string[] colors)
        {
            var predicate = PredicateBuilder.New<Product>();

            foreach (var color in colors)
            {
                predicate = predicate.Or(p => p.Color == color);
            }

            return context.Products.AsExpandable().Where(predicate).ToList();
        }
    }
}
