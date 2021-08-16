using Bogus;
using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using Vavatech.EFCore.DbRepositories;
using Vavatech.EFCore.Fakers;
using Vavatech.EFCore.IRepositories;
using System.Linq;

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

            // AddCustomers(context);

            GetCustomers(context);

            GetCustomer(context);
        }

        private static void GetCustomer(ShopContext context)
        {
            string pesel = "59101427230";

            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            var customer = customerRepository.GetByPesel(pesel);

            if (customer!=null)
            {

            }

        }

        private static void GetCustomers(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            var customers = customerRepository.Get();

            if (customers.All(p=>!p.IsRemoved))
            {

            }


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
