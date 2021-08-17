using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.EFCore.IRepositories
{
    public interface IOrderRepository
    {
        void Add(Order order);
        IEnumerable<Order> GetByCustomer(int customerId);

        IEnumerable<Order> Get();
    }
}
