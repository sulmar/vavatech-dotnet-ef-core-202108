using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using Vavatech.EFCore.IRepositories;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Sulmar.EFCore.Models.SearchCriterias;

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

        public void Remove2(int id)
        {
            Customer customer = new Customer { Id = id };
            Debug.WriteLine(context.Entry(customer).State);

            context.Customers.Remove(customer);
            Debug.WriteLine(context.Entry(customer).State);

            context.SaveChanges();
            Debug.WriteLine(context.Entry(customer).State);
        }

        public void Remove(int id)
        {
            context.Customers.Remove(id);
            context.SaveChanges();
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

        public IEnumerable<Customer> GetByAge(int age)
        {
            //return context.Customers.FromSqlRaw("SELECT * FROM Customers WHERE year(getdate()) - year(DateOfBirth) > {0}", age)
            //    .Where(p => !p.IsRemoved)
            //    .OrderBy(p => p.DateOfBirth)
            //    .ToList();


            // Jawne przekazanie parametru
            //var ageParameter = new SqlParameter("age", age);            

            //return context.Customers.FromSqlRaw("SELECT * FROM Customers WHERE year(getdate()) - year(DateOfBirth) > @age", ageParameter)
            //    .Where(p => !p.IsRemoved)
            //    .OrderBy(p => p.DateOfBirth)
            //    .ToList();


            // Interpolacja
            return context.Customers.FromSqlInterpolated($"SELECT * FROM Customers WHERE year(getdate()) - year(DateOfBirth) > {age}")
                .Where(p => !p.IsRemoved)
                .OrderBy(p => p.DateOfBirth)
                .ToList();

            //var ageParameter = new SqlParameter("age", age); 

            //return context.Customers.FromSqlRaw("EXECUTE dbo.uspGetCustomersByAge {0}", age)
            //    //.Where(p => !p.IsRemoved)
            //    //.OrderBy(p => p.DateOfBirth)
            //    .ToList();


        }

        // zła praktyka
        //public IEnumerable<Customer> Get(string firstName, string lastName, DateTime? dateOfBirthFrom, DateTime? dateOfBirthTo, decimal? creditFrom, decimal? creditTo)
        //{
        //    throw new NotImplementedException();
        //}


        public IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria)
        {
            var query = context.Customers.AsQueryable();

            if (!string.IsNullOrEmpty(searchCriteria.FirstName))
            {
                query = query.Where(c => c.FirstName == searchCriteria.FirstName);
            }

            if (!string.IsNullOrEmpty(searchCriteria.LastName))
            {
                query = query.Where(c => c.LastName == searchCriteria.LastName);
            }

            if (searchCriteria.DateOfBirthFrom.HasValue)
            {
                query = query.Where(c => c.DateOfBirth >= searchCriteria.DateOfBirthFrom.Value);
            }

            if (searchCriteria.DateOfBirthTo.HasValue)
            {
                query = query.Where(c => c.DateOfBirth <= searchCriteria.DateOfBirthTo.Value);
            }

            if (searchCriteria.CreditFrom.HasValue)
            {
                query = query.Where(c => c.Credit >= searchCriteria.CreditFrom.Value);
            }

            if (searchCriteria.CreditTo.HasValue)
            {
                query = query.Where(c => c.Credit <= searchCriteria.CreditTo.Value);
            }

            return query.ToList(); // strzał do bazy danych

        }

        // Mapowania funkcji dostawcy Microsoft SQL Server danych
        // https://docs.microsoft.com/pl-pl/ef/core/providers/sql-server/functions

        public IEnumerable<Customer> GetByFirstName(int lenght)
        {
            // return context.Customers.Where(c => c.FirstName.Length > lenght).ToList();

            // return context.Customers.FromSqlInterpolated($"SELECT * FROM dbo.Customers WHERE DATALENGTH(FirstName) > {lenght}").ToList();

            return context.Customers.Where(c => EF.Functions.DataLength(c.FirstName) > lenght).ToList();

            // return context.Customers.AsEnumerable().Where(c => Extract(c.FirstName) == "h").ToList();

            // return context.Customers.Where(c => c.FirstName.Substring(0, 1) == "C").ToList();

           
        }

        public IEnumerable<Customer> GetCustomersWithLoyaltyCard()
        {
            throw new NotImplementedException();
        }
    }
}
