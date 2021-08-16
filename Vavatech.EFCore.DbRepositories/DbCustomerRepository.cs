using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using Vavatech.EFCore.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Vavatech.EFCore.DbRepositories
{
    public class DbCustomerRepository : ICustomerRepository
    {
        private readonly ShopContext context;

        public DbCustomerRepository(ShopContext context)
        {
            this.context = context;
        }

        public void Add(Customer customer)
        {
            context.Customers.Add(customer);
            context.SaveChanges();
        }

        public void AddRange(IEnumerable<Customer> customers)
        {
            context.Customers.AddRange(customers);
            context.SaveChanges();
        }

        public IEnumerable<Customer> Get()
        {
            return context.Customers.ToList();
        }

        public Customer Get(int id)
        {
            return context.Customers.Find(id);
        }

        public Customer GetByPesel(string pesel)
        {
            // Wyłączenie lokalne globalnego filtrowania
            return context.Customers.IgnoreQueryFilters().SingleOrDefault(c => c.Pesel == pesel);
        }

        public void Remove(int id)
        {
            context.Customers.Remove(Get(id));
            context.SaveChanges();
        }

        public void Update(Customer customer)
        {
            context.Customers.Update(customer);
            context.SaveChanges();
        }
    }
}
