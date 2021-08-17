using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
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

        public IEnumerable<Order> GetByCustomer(int customerId)
        {
            throw new NotImplementedException();
        }
    }
}
