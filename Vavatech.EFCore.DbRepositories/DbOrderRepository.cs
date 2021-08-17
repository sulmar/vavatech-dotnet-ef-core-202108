using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.DbRepositories
{
    public class DbOrderRepository : IOrderRepository
    {
        private readonly ShopContext context;

        public DbOrderRepository(ShopContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            context.Orders.Add(order);

            context.SaveChanges();
        }

        public IEnumerable<Order> GetByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
