using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.DbRepositories
{
    public class DbOrderRepository : IOrderRepository
    {
        private readonly ShopContext context;

        public DbOrderRepository(ShopContext context)
        {
            this.context = context;
        }

        public void Add(Order order)
        {
            // Własna Strategia
            context.ChangeTracker.TrackGraph(order, e => 
            {
                if (e.Entry.IsKeySet)
                {
                    e.Entry.State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
                }
                else
                {
                    e.Entry.State = Microsoft.EntityFrameworkCore.EntityState.Added;
                }
            });

            context.Orders.Add(order);


            // ręczne sterowanie 
            //context.Entry(order.Customer).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;

            //foreach (var detail in order.Details)
            //{
            //    context.Entry(detail.Item).State = Microsoft.EntityFrameworkCore.EntityState.Unchanged;
            //}

            var entries = context.ChangeTracker.Entries();

            Console.WriteLine(context.ChangeTracker.DebugView.ShortView);

            Console.Clear();

            Console.WriteLine(context.ChangeTracker.DebugView.LongView);

            context.SaveChanges();
        }

        // Pobieranie zachłanne (Eadger loading)

        /*
        public IEnumerable<Order> Get()
        {
            //return context.Orders
            //    .Include(p=>p.Customer)
            //    .Include(p=>p.Details)
            //        .ThenInclude(p=>p.Item)
            //    .ToList();

            // EF Core 5 filtrowanie 
            return context.Orders
                .Include(p => p.Customer)
                .Include(p => p.Details.Where(d=>d.UnitPrice>100))
                    .ThenInclude(p => p.Item)
                .ToList();
           
        }
        */

        // Jawne pobieranie danych (Explicit loading)
        //public IEnumerable<Order> Get()
        //{
        //    var orders = context.Orders.ToList();

        //    foreach (var order in orders)
        //    {
        //        // ...
        //        context.Entry(order).Reference(p => p.Customer).Load();

        //        context.Entry(order).Collection(p => p.Details).Load();
        //    }

        //    return orders;
        //}

        // Leniwe pobieranie danych (Lazy loading) z Proxy

        // 1. dotnet add package Microsoft.EntityFrameworkCore.Proxies
        // 2. dodaj modelBuilder.UseLazyLoadingProxies()
        // 3. dodaj virtual do WSZYSTKICH(!) właściwości navigation property


        // Leniwe pobieranie danych (Lazy loading) z ILazyLoader
        // 1. Dodaj ILazyLoader do konstruktora
        // 2. Dodaj LazyLoader.Load() do właściwości

        // nie wymaga Microsoft.EntityFrameworkCore.Proxies i virtual

        public IEnumerable<Order> Get()
        {
            var orders = context.Orders.ToList();

            foreach (var order in orders)
            {
                Debug.WriteLine(order.Customer.FullName);

                foreach (var orderDetail in order.Details)
                {
                    Debug.WriteLine(orderDetail.Item.Name);
                }
            }

            return orders;

        }

         public IEnumerable<Order> GetByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerTotalAmount> GetTotalAmountByCustomer()
        {
            throw new NotImplementedException();
        }
    }
}
