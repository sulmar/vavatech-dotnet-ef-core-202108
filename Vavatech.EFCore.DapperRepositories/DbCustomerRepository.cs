using Dapper;
using Sulmar.EFCore.Models;
using Sulmar.EFCore.Models.SearchCriterias;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.DapperRepositories
{

    // dotnet add package Dapper
    public class DbCustomerRepository : ICustomerRepository
    {
        private readonly IDbConnection connection;

        public DbCustomerRepository(IDbConnection connection)
        {
            this.connection = connection;
        }

        public void Add(Customer entity)
        {
            string sql = "INSERT INTO dbo.Customers VALUES (@FirstName, @LastName)";

            connection.Execute(sql, new { entity.FirstName, entity.LastName });
        }

        public void AddRange(IEnumerable<Customer> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get(CustomerSearchCriteria searchCriteria)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> Get()
        {
            string sql = "SELECT [FirstName],[LastName] FROM dbo.Customers";

            return connection.Query<Customer>(sql).ToList();
        }

        public Customer Get(int id)
        {
            string sql = "SELECT [FirstName],[LastName] FROM dbo.Customers WHERE Id = @id";

            return connection.QuerySingleOrDefault<Customer>(sql, new { @id = id });
        }

        public IEnumerable<Customer> GetByAge(int age)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetByFirstName(int lenght)
        {
            throw new NotImplementedException();
        }

        public Customer GetByPesel(string pesel)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersWithLoyaltyCard()
        {
            string sql = "select c.Id, FirstName, LastName, InvoiceAddress_City as City, InvoiceAddress_Country as Country, InvoiceAddress_Street as Street, InvoiceAddress_ZipCode as ZipCode, lc.Id as LoyaltyCarId, lc.SerialNumber, lc.ExpirationDate from Customers as c inner join LoyaltyCards as lc on c.Id = lc.OwnerId";

            var customers = connection.Query<Customer, Address, LoyaltyCard, Customer>(sql, (customer, invoiceAddress, loyaltyCard) =>
            {
                customer.InvoiceAddress = invoiceAddress;
                customer.LoyaltyCard = loyaltyCard;

                return customer;
            },
            splitOn: "Id, City, LoyaltyCarId"
            ).ToList();

            return customers;

        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer entity)
        {
            throw new NotImplementedException();
        }

        public void UpdateDateOfBirth(Customer customer)
        {
            throw new NotImplementedException();
        }
    }
}
