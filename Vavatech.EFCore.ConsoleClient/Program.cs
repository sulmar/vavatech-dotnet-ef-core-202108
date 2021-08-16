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

            ShopContextFactory shopContextFactory = new ShopContextFactory();

            ShopContext context = shopContextFactory.CreateDbContext(args);

            Setup(context);

            AddCustomers(context);



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

            // context.Database.EnsureCreated(); // nie używać w przypadku stosowania migracji!

            context.Database.Migrate();

            Console.WriteLine("Created.");
        }

       
    }
}
