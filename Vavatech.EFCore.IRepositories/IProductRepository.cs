using Sulmar.EFCore.Models;
using System.Collections.Generic;

namespace Vavatech.EFCore.IRepositories
{
    public interface IProductRepository : IEntityRepository<Product>
    {
        IEnumerable<Product> GetByColor(string color);

        IEnumerable<Product> GetByColors(params string[] colors);
    }
}
