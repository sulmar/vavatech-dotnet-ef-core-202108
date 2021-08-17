using Bogus;
using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using Vavatech.EFCore.DbRepositories;
using Vavatech.EFCore.Fakers;
using Vavatech.EFCore.IRepositories;
using System.Linq;
using System.Text.Json;

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

            // AddCustomer(context);

            // UpdateCustomer(context);

            // RemoveCustomer(context);

            // UpdateDeserializedCustomer(context);

            // AddCustomers(context);

            //GetCustomers(context);

            //GetCustomer(context);

            //AddProducts(context);
            //AddServices(context);

            // AddOrder(context);

            AddDetachedOrder(context);
        }


        private static void AddServices(ShopContext context)
        {
            Faker<Service> faker = new ServiceFaker();

            var services = faker.GenerateLazy(10);

            IServiceRepository serviceRepository = new DbServiceRepository(context);
            serviceRepository.AddRange(services);
        }

        private static void AddProducts(ShopContext context)
        {
            Faker<Product> faker = new ProductFaker();

            var products = faker.GenerateLazy(20);

            IProductRepository productRepository = new DbProductRepository(context);
            productRepository.AddRange(products);
        }

        private static void AddOrder(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);
            IProductRepository productRepository = new DbProductRepository(context);
            IServiceRepository serviceRepository = new DbServiceRepository(context);
            IOrderRepository orderRepository = new DbOrderRepository(context);

            Customer customer = customerRepository.Get(11);

            Product product1 = productRepository.Get(1);
            Product product2 = productRepository.Get(2);
            Product product3 = productRepository.Get(3);
            Service service1 = serviceRepository.Get(21);

            Order order = new Order
            {
                CreatedOn = DateTime.Now,
                Customer = customer,
                OrderDate = DateTime.Today,
            };

            order.Details.Add(new OrderDetail(product1));
            order.Details.Add(new OrderDetail(product2));
            order.Details.Add(new OrderDetail(product3));
            order.Details.Add(new OrderDetail(service1));

            orderRepository.Add(order);
        }

        private static void AddDetachedOrder(ShopContext context)
        {
            IOrderRepository orderRepository = new DbOrderRepository(context);

            Customer customer = new Customer { Id = 11 };

            Product product1 = new Product { Id = 1 };
            Product product2 = new Product { Id = 2 };
            Product product3 = new Product { Id = 3 };
            Service service1 = new Service { Id = 21 };

            Order order = new Order
            {
                CreatedOn = DateTime.Now,
                Customer = customer,
                OrderDate = DateTime.Today,
            };

            order.Details.Add(new OrderDetail(product1));
            order.Details.Add(new OrderDetail(product2));
            order.Details.Add(new OrderDetail(product3));
            order.Details.Add(new OrderDetail(service1));

            orderRepository.Add(order);
        }

        private static void RemoveCustomer(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            int customerId = 99;

            customerRepository.Remove(customerId);
        }

        private static void UpdateCustomer(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            Customer customer = customerRepository.Get(100);

            customer.DateOfBirth = customer.DateOfBirth.Value.AddDays(1);

            customerRepository.Update(customer);
        }

        private static void UpdateDeserializedCustomer(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            Customer customer = customerRepository.Get(11);

            string json = JsonSerializer.Serialize(customer);

            Customer deserializedCustomer = JsonSerializer.Deserialize<Customer>(json);

            deserializedCustomer.DateOfBirth = deserializedCustomer.DateOfBirth.Value.AddDays(1);

            ShopContextFactory shopContextFactory = new ShopContextFactory();

            ShopContext context2 = shopContextFactory.CreateDbContext(null);
            ICustomerRepository customerRepository2 = new DbCustomerRepository(context2);

            customerRepository2.UpdateDateOfBirth(deserializedCustomer);
        }

        private static void AddCustomer(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            Faker<Customer> faker = new CustomerFaker(new AddressFaker());

            Customer customer = faker.Generate();

            customerRepository.Add(customer);
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
