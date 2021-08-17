using Sulmar.EFCore.Models;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.DbRepositories
{
    public class DbServiceRepository : DbEntityRepository<Service>, IServiceRepository
    {
        public DbServiceRepository(ShopContext context) : base(context)
        {
        }
    }
}
