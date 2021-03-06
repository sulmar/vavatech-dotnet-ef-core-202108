using Bogus;
using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using Vavatech.EFCore.DbRepositories;
using Vavatech.EFCore.Fakers;
using Vavatech.EFCore.IRepositories;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Transactions;
using System.Threading;
using Sulmar.EFCore.Models.SearchCriterias;
using static Microsoft.EntityFrameworkCore.EF;
using System.Threading.Tasks;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using System.Diagnostics;
using System.Collections.Generic;
using NetTopologySuite;

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

           


            //   RemoveCustomer(context);

            // AddCustomer(context);

            // UpdateCustomer(context);

            // RemoveCustomer(context);

            // UpdateDeserializedCustomer(context);



            // GetCustomers(context);

            //GetCustomer(context);

            //AddProducts(context);
            //AddServices(context);

            // AddOrder(context);

            // AddDetachedOrder(context);

            // GetProducts(context);

            // UpdateByINotifyPropertyChangedCustomer(context);

            // AddAttachments(context);

            //GetAttachments(context);
            //GetAttachmentDetail(context);

            // GetOrders(context);

            // GroupByCustomer(context);

            // LinqSets(context);

            // GetProductsByColor(context);

            // GetCustomersByAge(context);

            // DbFunctionTest(context);


            // NativeTransaction(context);

            // DistributedTransaction(context);

            // ConcurrencyToken(context);

            // BatchUpdateCustomers(context);


            // AddCustomers(context);



            // GetProductsByColors(context);

            //ChangeTrackerTracked(context);

            //GetCustomersBySearchCriteria(context);

            //AddCustomer(context);

            // ChangeTrackerStateChanged(context);

            //  GetCustomersByFirstName(context);

            //GetTotalAmountCountries(context);


            //GetTotalAmountByCountryByYear(context);

            // OuterApplyTest(context);

            // ShadowPropertyTest(context);

            // AutoIncludeTest(context);

            // SavingChangesOnContext(context);

            // MetadataContext(context);

            // GetFullNameCustomers(context);

            // GetProductsAndServices(context);

            // CancelLongRunningQuery(context);

            // SplitQueryTest(context);

            // GetLongCustomers(context);

            // CompileQueryTest(context);


            // GetProductsTest(context);

            // DapperTest();

            // SpatialTypeTest(context);

            // LineTest();

            // AddCustomerWithEmptyShipAddress(context);

            // GetTotalAmountCountries(context);

            GetDevices(context);


            GetVehicles(context);

            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();

        }

        private static void GetVehicles(ShopContext context)
        {
            var vehicles = context.Vehicles.ToList();

        }

        private static void GetDevices(ShopContext context)
        {
            var devices = context.Devices.ToList();

            // var customers = context.Customers.ToDictionary(p => p.Pesel, c => new { c.FirstName, c.LastName });
        }

        private static void LineTest()
        {
            NetTopologySuite.Geometries.Coordinate[] coordinates = new NetTopologySuite.Geometries.Coordinate[]
           {
                new NetTopologySuite.Geometries.Coordinate( 27.10000, 78.04000),
                new NetTopologySuite.Geometries.Coordinate( 28.10000, 78.04000),
                new NetTopologySuite.Geometries.Coordinate( 28.50000, 71.04000),

           };

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

            var line = geometryFactory.CreateLineString(coordinates);
        }

        private static void SpatialTypeTest(ShopContext context)
        {
            IShopRepository shopRepository = new DbShopRepository(context);

            var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);

           

            var myLocation = geometryFactory.CreatePoint(new NetTopologySuite.Geometries.Coordinate( 27.10000, 78.04000));

            var shops = shopRepository.Get();

            var shops2 = shopRepository.Get(myLocation, 500_000);
        }

        private static void DapperTest()
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Integrated Security=True;Initial Catalog=ShopDb;Application Name=Shop;MultipleActiveResultSets=True";
            SqlConnection connection = new SqlConnection(connectionString);
            ICustomerRepository customerRepository = new DapperRepositories.DbCustomerRepository(connection);

            // var customers = customerRepository.Get();

            var customers = customerRepository.GetCustomersWithLoyaltyCard();
        }

        private static void GetProductsTest(ShopContext context)
        {
            IProductRepository productRepository = new DbProductRepository(context);

            var product = productRepository.Get(1);

            var products = productRepository.Get();
        }

        private static void CompileQueryTest(ShopContext context)
        {
            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var ids = context.Customers.Take(1000).OrderBy(c => c.Id).Select(c => c.Id).ToArray();

            foreach (var id in ids)
            {
                Customer customer = context.Customers.Find(id);
            }

            stopwatch.Stop();

            Console.BackgroundColor = ConsoleColor.Red;
            Debug.WriteLine($"Regular Query : {stopwatch.ElapsedMilliseconds} ms");
            Console.ResetColor();
            stopwatch.Reset();


            stopwatch.Start();

            Func<ShopContext, int, Customer> getCustomer = EF.CompileQuery((ShopContext db, int id) => db.Customers.SingleOrDefault(c => c.Id == id));

            foreach (var id in ids)
            {
                var customer = getCustomer(context, id);
            }

            stopwatch.Stop();

            Console.BackgroundColor = ConsoleColor.Red;
            Debug.WriteLine($"Compile Query : {stopwatch.ElapsedMilliseconds} ms");
            Console.ResetColor();
        }

        //private static readonly Func<ShopContext, int, Customer> getCustomer = EF.CompileQuery((ShopContext context, int id) 
        //    => context.Customers.SingleOrDefault(c => c.Id == id));

        private static void SplitQueryTest(ShopContext context)
        {
             Task.Run(() => SplitQueryTestAsync(context));
        }

        private static async Task SplitQueryTestAsync(ShopContext context)
        {
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            CancellationToken token = cts.Token;

            token.Register(() => Console.WriteLine("Cancelled!"));

            context.Database.SetCommandTimeout(TimeSpan.FromSeconds(0));

            var query = (from a in context.Customers
                        from b in context.Customers
                        select new { a, b.FirstName })
                        .AsSplitQuery();

            Console.WriteLine("Starting...");

            var customers = await query.ToListAsync(token);
        }

        

        private static void GetLongCustomers(ShopContext context)
        {
            Console.WriteLine("Press any key to Start!");
            Console.ReadKey();

            Task.Run(() => GetLongCustomersAsync(context));
        }

       



        private static void CancelLongRunningQuery(ShopContext context)
        {
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));

            CancellationToken token = cts.Token;

            SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();

            var query = (from a in context.Customers
                        from b in context.Customers
                        select new { a, b.FirstName });

            // var sql = query.ToQueryString();

            // string sql = "SELECT * FROM dbo.Customers as a CROSS APPLY dbo.Customers as b";

            //            SqlCommand command = new SqlCommand(sql, connection);

            SqlCommand command = query.GetSqlCommand();

            token.Register(() => command.Cancel());

            connection.Open();

            var reader = command.ExecuteReader();

            Console.WriteLine("waiting...");

            try
            {

                while (reader.Read())
                {
                    // TODO: Map
                    Console.Write(".");

                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Anulowano");
            }
            finally
            {
                connection.Close();
            }


        }

        private static async Task GetLongCustomersAsync(ShopContext context)
        {
            CancellationTokenSource cts = new CancellationTokenSource(TimeSpan.FromSeconds(10));

            CancellationToken token = cts.Token;

            token.Register(() => Console.WriteLine("Cancelled!"));

            context.Database.SetCommandTimeout(TimeSpan.FromSeconds(0));

            var query = from a in context.Customers
                        from b in context.Customers
                        select new { a, b.FirstName };

            Console.WriteLine("Starting...");


            var customers = await query.ToListAsync(token);










        }

        private static void GetFullNameCustomers(ShopContext context)
        {
            var customers = context.Customers
                .Take(100)
                .OrderBy(c => c.Id)
                .Select(c => new { c.Id, c.FullName }).ToList();


        }

        private static void MetadataContext(ShopContext context)
        {
            var entityTypes = context.Model.GetEntityTypes();

            foreach (var entityType in entityTypes)
            {
                var tableName = entityType.GetTableName();

                Console.WriteLine($"==== {tableName} ====");

                // var keys = entityType.GetDeclaredKeys();

                foreach (var property in entityType.GetProperties())
                {
                    var columnName = property.GetColumnName();

                    if (property.IsKey())
                        Console.Write("PK ");

                    if (property.IsForeignKey())
                        Console.Write("FK ");

                    Console.WriteLine($"{columnName} {property.ClrType.Name}");
                }

            }
        }

        private static void SavingChangesOnContext(ShopContext context)
        {
            context.SavingChanges += (sender, args) =>
            {
                Console.WriteLine($"Saving changes for {((DbContext)sender)?.Database.GetConnectionString()}");
            };

            context.SavedChanges += (sender, args) =>
            {
                Console.WriteLine($"Saved {args.EntitiesSavedCount} changes for {((DbContext)sender)?.Database.GetConnectionString()}");
            };

            context.SaveChangesFailed += (sender, args) =>
            {
                Console.WriteLine($"Save changes failed {args.Exception}");
            };


            var customer = context.Customers.Find(11);

            customer.Credit += 100;

            context.SaveChanges();
        }

        private static void AutoIncludeTest(ShopContext context)
        {
            // var customer = context.Customers.SingleOrDefault(p=>p.Id == 11);

            // EF Core 5
            var customer2 = context.Customers.IgnoreAutoIncludes().SingleOrDefault(p => p.Id == 11);
        }

        private static void ShadowPropertyTest(ShopContext context)
        {
            var customer = context.Customers.IgnoreQueryFilters().SingleOrDefault(p => p.Id == 103);

            context.Entry(customer).Property("LastLogin").CurrentValue = DateTime.Now;

            context.SaveChanges();

            var lastLogin = context.Entry(customer).Property("LastLogin").CurrentValue;

            Console.WriteLine(lastLogin);

            // query

            var customers = context.Customers.OrderBy(c => Property<DateTime>(c, "LastLogin"))
                .ToList();

        }

        private static void OuterApplyTest(ShopContext context)
        {
            // CROSS APPLY
            var query1 =
                        (from c in context.Customers
                         from t in context.GetTotalAmountByCountry(c.CreatedOn.Year)
                         select new { c.FirstName, t.Country })
                        .ToList();

            // OUTER APPLY
            var query2 =
                        (from c in context.Customers
                         from t in context.GetTotalAmountByCountry(c.CreatedOn.Year).DefaultIfEmpty()
                         select new { c.FirstName, t.Country })
                        .ToList();
        }

        private static void GetTotalAmountByCountryByYear(ShopContext context)
        {
            var totals = context.GetTotalAmountByCountry(2020).ToList();

            var totals2 = context.TotalAmountCountries.GetTotalAmountByCountry(2020).ToList();
        }

        private static void GetTotalAmountCountries(ShopContext context)
        {
            IOrderRepository orderRepository = new DbOrderRepository(context);

            var totalAmounts = orderRepository.GetTotalAmountByCountry();
        }

        private static void GetCustomersByFirstName(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            var customers = customerRepository.GetByFirstName(10);
        }

        private static void ChangeTrackerStateChanged(ShopContext context)
        {
            context.ChangeTracker.StateChanged += ChangeTracker_StateChanged;
        }

        private static void ChangeTracker_StateChanged(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityStateChangedEventArgs e)
        {
            if (e.NewState == EntityState.Modified && e.Entry.Entity is BaseEntity entity)
            {
                entity.ModifiedOn = DateTime.Now;
            }
        }

        private static void ChangeTrackerTracked(ShopContext context)
        {
            context.ChangeTracker.Tracked += ChangeTracker_Tracked;
        }

        private static void ChangeTracker_Tracked(object sender, Microsoft.EntityFrameworkCore.ChangeTracking.EntityTrackedEventArgs e)
        {
            if (e.FromQuery && e.Entry.Entity is Customer customer)
            {
                // customer.Pesel = customer.Pesel.Replace('0', '*');
            }

            if (!e.FromQuery && e.Entry.State == EntityState.Added && e.Entry.Entity is BaseEntity entity)
            {
                entity.CreatedOn = DateTime.Now;
            }
        }

        private static void GetProductsByColors(ShopContext context)
        {
            IProductRepository productRepository = new DbProductRepository(context);

            var products = productRepository.GetByColors("gold", "purple", "violet");
        }

        private static void GetCustomersBySearchCriteria(ShopContext context)
        {
            var searchCriteria = new CustomerSearchCriteria { CreditFrom = 120, CreditTo = 500 };

            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            var customers = customerRepository.Get(searchCriteria);

            var e = context.ChangeTracker.Entries();

        }

        private static void BatchUpdateCustomers(ShopContext context)
        {
            var customers = context.Customers.Take(1000).ToList();

            foreach (var customer in customers)
            {
                customer.Credit += 500;
            }

            // context.Customers.UpdateRange(customers);

            context.SaveChanges();
        }

        private static void ConcurrencyToken(ShopContext context)
        {
            ShopContextFactory shopContextFactory = new ShopContextFactory();

            ShopContext user1Context = shopContextFactory.CreateDbContext(null);
            ShopContext user2Context = shopContextFactory.CreateDbContext(null);

            int customerId = 2;

            try
            {
                Customer customer1 = user1Context.Customers.Find(customerId);
                customer1.LastName = "Spider";

                Customer customer2 = user2Context.Customers.Find(customerId);
                customer2.LastName = "Sky";

                user2Context.SaveChanges();

                user1Context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                Console.WriteLine("Klient został w międzyczasie zmodyfikowany!");

                var entry = e.Entries.First();

                entry.Reload();

                Customer customer = (Customer)entry.Entity;

                Console.WriteLine($"Obecnie nazywa się {customer.LastName}");
            }

        }

        private static void DistributedTransaction(ShopContext context)
        {
            decimal amount = 50;

            ShopContextFactory shopContextFactory = new ShopContextFactory();

            ShopContext senderContext = shopContextFactory.CreateDbContext(null);
            ShopContext recipientContext = shopContextFactory.CreateDbContext(null);

            try
            {
                // using System.Transaction
                using (var transaction = new TransactionScope())
                {
                    var sender = senderContext.Customers.Find(2);
                    sender.Credit -= amount;
                    senderContext.SaveChanges();
                    Console.WriteLine("Transakcja wychodząca");

                    var recipient = recipientContext.Customers.Find(3);
                    recipient.Credit += amount;

                    recipientContext.SaveChanges();
                    Console.WriteLine("Transakcja przychodząca");

                    transaction.Complete();   // To Commit

                } // ->  COMMIT

            }

            catch (Exception e)
            {
                Console.WriteLine("Wycofano transakcję.");
            }

        }

        // Transakcje
        // https://docs.microsoft.com/pl-pl/ef/core/saving/transactions

        // Poziomy izolacji
        // https://docs.microsoft.com/en-us/sql/connect/jdbc/understanding-isolation-levels?view=sql-server-ver15#remarks
        private static void NativeTransaction(ShopContext context)
        {
            decimal amount = 50;

            using (var transaction = context.Database.BeginTransaction(System.Data.IsolationLevel.ReadUncommitted)) // BEGIN TRAN
            {
                try
                {
                    var sender = context.Customers.Find(2);
                    sender.Credit -= amount;
                    context.SaveChanges();
                    Console.WriteLine("Transakcja wychodząca");

                    var recipient = context.Customers.Find(999);
                    recipient.Credit += amount;

                    context.SaveChanges();
                    transaction.CreateSavepoint("TransakcjaWychodzaca"); // EF Core 5

                    Console.WriteLine("Transakcja przychodząca");

                    transaction.Commit(); // COMMIT

                    Console.WriteLine("Zatwierdzono transakcję.");
                }
                catch (Exception e)
                {
                    // transaction.Rollback(); // ROLLBACK
                    transaction.RollbackToSavepoint("TransakcjaWychodzaca"); // EF Core 5

                    Console.WriteLine("Wycofano transakcję.");

                }
            }
        }

        private static void DbFunctionTest(ShopContext context)
        {
            var customers = context.Customers
                .Where(c => context.CalculateAge(c.DateOfBirth.Value) > 60)
                .ToList();
        }

        private static void GetProductsByColor(ShopContext context)
        {
            IProductRepository productRepository = new DbProductRepository(context);
            var products = productRepository.GetByColor("gold");
        }

        private static void GetCustomersByAge(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            var customers = customerRepository.GetByAge(60);

        }

        private static void LinqSets(ShopContext context)
        {
            var privatesCustomers = context.Customers.IgnoreQueryFilters().Where(c => c.CustomerType == CustomerType.Private);
            var companiesCustomers = context.Customers.IgnoreQueryFilters().Where(c => c.CustomerType == CustomerType.Company);

            var allCustomers = privatesCustomers.Concat(companiesCustomers);

            var activeCustomers = context.Customers.Where(c => !c.IsRemoved);

            var nonActiveCustomers = allCustomers.Except(activeCustomers).ToList();

            if (nonActiveCustomers.All(p => p.IsRemoved == true))
            {

            }

            if (privatesCustomers.Any(p => p.ShipAddress.Country == "USA"))
            {

            }

        }

        private static void GroupByCustomer(ShopContext context)
        {
            // po stronie klienta
            var query = context.Customers
                .AsEnumerable()
                .GroupBy(c => c.CustomerType)
                .Select(g => new { CustomerType = g.Key, g })
                .ToList();


            // po stronie serwera
            var query2 = context.Customers
               .GroupBy(c => c.CustomerType)
               .Select(g => new { CustomerType = g.Key, Qty = g.Count() })
               .ToList();

            // po stronie klienta

            var query3 = context.Orders
                .AsEnumerable()
                .GroupBy(o => o.Customer)
                .Select(g => new { Customer = g.Key, TotalAmount = g.Sum(p => p.TotalAmount) })
                .ToList();

        }

        private static void GetOrders(ShopContext context)
        {
            IOrderRepository orderRepository = new DbOrderRepository(context);

            var orders = orderRepository.Get();

            foreach (var order in orders)
            {
                Console.WriteLine($"{order.Customer.FullName}");

                foreach (var detail in order.Details)
                {
                    Console.WriteLine(detail.Item.Name);
                }
            }
        }

        private static void GetAttachments(ShopContext context)
        {
            IAttachmentRepository attachmentRepository = new DbAttachmentRepository(context);
            var attachments = attachmentRepository.Get();
        }

        private static void GetAttachmentDetail(ShopContext context)
        {
            IAttachmentDetailRepository attachmentDetailRepository = new DbAttachmentDetailRepository(context);
            var detail = attachmentDetailRepository.Get(1);
        }

        private static void AddAttachments(ShopContext context)
        {
            Console.Write("Adding attachments... ");

            Faker<Attachment> faker = new AttachmentFaker(new AttachmentDetailFaker());

            var attachments = faker.Generate(50);

            IAttachmentRepository attachmentRepository = new DbAttachmentRepository(context);

            attachmentRepository.AddRange(attachments);

            Console.WriteLine($"({attachments.Count()}) added.");




        }

        //private static void UpdateByINotifyPropertyChangedCustomer(ShopContext context)
        //{
        //    Customer customer = context.Customers.Find(1);

        //    Console.WriteLine(context.Entry(customer).State); Console.WriteLine(context.Entry(customer).State);

        //    customer.IsRemoved = !customer.IsRemoved;

        //    Console.WriteLine(context.Entry(customer).State);

        //    Console.WriteLine(context.ChangeTracker.DebugView.ShortView);

        //    context.SaveChanges();

        //    Console.WriteLine(context.Entry(customer).State);


        //}


        private static void GetProductsAndServices(ShopContext context)
        {
            var items = context.Products.AsEnumerable().OfType<Item>().Concat(context.Services).ToList();
        }

        private static void GetProducts(ShopContext context)
        {
            IProductRepository productRepository = new DbProductRepository(context);

            var products = productRepository.Get();

            var product = products.FirstOrDefault();

            Console.WriteLine(context.Entry(product).State);

            product.Color = "Red";

            Console.WriteLine(context.Entry(product).State);

        }

        private static void AddServices(ShopContext context)
        {
            Console.Write("Adding services... ");

            Faker<Service> faker = new ServiceFaker();

            var services = faker.GenerateLazy(10);

            IServiceRepository serviceRepository = new DbServiceRepository(context);
            serviceRepository.AddRange(services);

            Console.WriteLine($"({services.Count()}) added.");
        }

        private static void AddProducts(ShopContext context)
        {
            Console.Write("Adding products... ");

            Faker<Product> faker = new ProductFaker();

            var products = faker.GenerateLazy(20);

            IProductRepository productRepository = new DbProductRepository(context);
            productRepository.AddRange(products);

            Console.WriteLine($"({products.Count()}) added.");
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

            Order order = new Order(null)
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

            Order order = new Order(null)
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

            int customerId = 31;

            customerRepository.Remove(customerId);
        }

        private static void UpdateCustomer(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            Customer customer = customerRepository.Get(11);

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

        private static void AddCustomerWithEmptyShipAddress(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            Faker<Customer> faker = new CustomerFaker(new AddressFaker(), new CoordinateFaker());

            Customer customer = faker.Generate();

            //customer.InvoiceAddress = null;
            // customer.ShipAddress = null;


            customerRepository.Add(customer);
        }

        private static void AddCustomer(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            Faker<Customer> faker = new CustomerFaker(new AddressFaker(), new CoordinateFaker());

            Customer customer = faker.Generate();

            customerRepository.Add(customer);
        }

        private static void GetCustomer(ShopContext context)
        {
            string pesel = "59101427230";

            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            var customer = customerRepository.GetByPesel(pesel);

            if (customer != null)
            {

            }

        }

        private static void GetCustomers(ShopContext context)
        {
            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            var customers = customerRepository.Get();

            if (customers.All(p => !p.IsRemoved))
            {

            }


        }

        private static void AddCustomers(ShopContext context)
        {
            Console.Write("Adding Customers... ");

            ICustomerRepository customerRepository = new DbCustomerRepository(context);

            Faker<Customer> customerFaker = new CustomerFaker(new AddressFaker(), new CoordinateFaker());

            var customers = customerFaker.GenerateLazy(1_000);

            customerRepository.AddRange(customers);

            Console.WriteLine($"({customers.Count()}) added.");
        }

        private static void Setup(ShopContext context)
        {
            Console.WriteLine("Checking connection to database...");


            if (context.Database.CanConnect())
            {
                Console.WriteLine("Connected.");
            }
            else
            {
                Console.WriteLine("Creating database...");

            // context.Database.EnsureCreated(); // nie używać w przypadku stosowania migracji!

                 context.Database.Migrate();

                Console.WriteLine("Preparing data....");
           
                AddCustomers(context);
                AddProducts(context);
                AddServices(context);
            }

            Console.WriteLine("Created.");
        }


    }
}
