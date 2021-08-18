using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;

namespace Vavatech.EFCore.IRepositories
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        Customer GetByPesel(string pesel);
        void UpdateDateOfBirth(Customer customer);

        IEnumerable<Customer> GetByAge(int age);
    }
}
