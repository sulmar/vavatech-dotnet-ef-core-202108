using Sulmar.EFCore.Models;
using Sulmar.EFCore.Models.SearchCriterias;
using System;
using System.Collections.Generic;

namespace Vavatech.EFCore.IRepositories
{
    public interface ICustomerRepository : IEntityRepository<Customer>
    {
        Customer GetByPesel(string pesel);
        void UpdateDateOfBirth(Customer customer);

        IEnumerable<Customer> GetByAge(int age);

        // IEnumerable<Customer> Get(string firstName, string lastName, DateTime? dateOfBirthFrom, DateTime? dateOfBirthTo, decimal? creditFrom, decimal? creditTo, bool? isRemoved);

        IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria);
    }
}
