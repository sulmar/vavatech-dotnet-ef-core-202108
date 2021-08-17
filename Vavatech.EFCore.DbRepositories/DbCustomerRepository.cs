using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using Vavatech.EFCore.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
            Debug.WriteLine(context.Entry(customer).State);

            context.Customers.Add(customer);

            Debug.WriteLine(context.Entry(customer).State);

            context.SaveChanges();

            Debug.WriteLine(context.Entry(customer).State);

            customer.IsRemoved = !customer.IsRemoved;

            // customer.IsRemoved = !customer.IsRemoved;

            var property = context.Entry(customer).Property(p => p.IsRemoved);

            Debug.WriteLine($"{property.Metadata.Name} IsModified={property.IsModified} OriginalValue={property.OriginalValue} CurrentValue={property.CurrentValue}");

            Debug.WriteLine(context.Entry(customer).State);

            context.SaveChanges();

            Debug.WriteLine(context.Entry(customer).State);
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

        //public void Remove(int id)
        //{
        //    Customer customer = Get(id);
        //    Debug.WriteLine(context.Entry(customer).State);

        //    context.Customers.Remove(customer);
        //    Debug.WriteLine(context.Entry(customer).State);

        //    context.SaveChanges();
        //    Debug.WriteLine(context.Entry(customer).State);
        //}

        public void Remove(int id)
        {
            Customer customer = new Customer { Id = id };
            Debug.WriteLine(context.Entry(customer).State);

            context.Customers.Remove(customer);
            Debug.WriteLine(context.Entry(customer).State);

            context.SaveChanges();
            Debug.WriteLine(context.Entry(customer).State);
        }

        public void Update(Customer customer)
        {
            Debug.WriteLine(context.Entry(customer).State);

            context.Customers.Update(customer);

            Debug.WriteLine(context.Entry(customer).State);

            context.SaveChanges();

            Debug.WriteLine(context.Entry(customer).State);
        }

        public void UpdateDateOfBirth(Customer customer)
        {
            Debug.WriteLine(context.Entry(customer).State);

            context.Entry(customer).Property(p => p.DateOfBirth).IsModified = true;

            Debug.WriteLine(context.Entry(customer).State);

            context.SaveChanges();

            Debug.WriteLine(context.Entry(customer).State);
        }
    }
}
