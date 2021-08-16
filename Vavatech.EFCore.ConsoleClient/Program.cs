using Bogus;
using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using Vavatech.EFCore.DbRepositories;
using Vavatech.EFCore.Fakers;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            ShopContext context = CreateContext();

            Setup(context);

           // AddCustomers(context);



        }

        private static void AddCustomers(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            Faker<Customer> customerFaker = new CustomerFaker(new AddressFaker());

            var customers = customerFaker.GenerateLazy(100);

            customerRepository.AddRange(customers);
        }

        private static void Setup(ShopContext context)
        {
            Console.WriteLine("Creating database...");
            context.Database.EnsureCreated();
            Console.WriteLine("Created.");
        }

        private static ShopContext CreateContext()
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Integrated Security=True;Initial Catalog=ShopDb;Application Name=Shop";

            // string connectionString2 = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=ShopDb;Integrated Security=False;User Id=john;Password=yourP@ssw0rd;Application Name=Shop";

            // dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            DbContextOptions options = new DbContextOptionsBuilder<ShopContext>()
                .UseSqlServer(connectionString)
                .Options;

            ShopContext context = new ShopContext(options);

            return context;
        }
    }
}
