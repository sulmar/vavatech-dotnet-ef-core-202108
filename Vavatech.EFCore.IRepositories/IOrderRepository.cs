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
        IEnumerable<Order> GetByCustomer(int customerId);
    }
}
