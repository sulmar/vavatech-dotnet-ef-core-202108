using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;

namespace Vavatech.EFCore.IRepositories
{
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        void Update(Customer customer);
        void Remove(int id);
        IEnumerable<Customer> Get();
        Customer Get(int id);

        Customer GetByPesel(string pesel);
    }
}
