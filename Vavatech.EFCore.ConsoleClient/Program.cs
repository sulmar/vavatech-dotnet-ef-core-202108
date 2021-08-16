using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using Vavatech.EFCore.DbRepositories;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.ConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Customer customer = new Customer { FirstName = "John", LastName = "Smith" };

            string connectionString = @"Data Source=(local)\SQLEXPRESS;Integrated Security=True;Initial Catalog=ShopDb;Application Name=Shop";

            // string connectionString2 = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=ShopDb;Integrated Security=False;User Id=john;Password=yourP@ssw0rd;Application Name=Shop";

            // dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            DbContextOptions options = new DbContextOptionsBuilder<ShopContext>()
                .UseSqlServer(connectionString)
                .Options;

            ShopContext context = new ShopContext(options);

            Console.WriteLine("Creating database...");
            context.Database.EnsureCreated();
            Console.WriteLine("Created.");

            ICustomerRepository customerRepository = new DbCustomerRepository(context); 

            customerRepository.Add(customer);
        }
    }
}
