using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vavatech.EFCore.DbRepositories
{
    // dotnet add package Microsoft.EntityFrameworkCore
    public class ShopContext : DbContext
    {
        public ShopContext([NotNull] DbContextOptions options) : base(options)
        {
           // this.Database.EnsureCreated();            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Owned Entities (https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities)
            modelBuilder.Entity<Customer>().OwnsOne(p => p.InvoiceAddress);
            modelBuilder.Entity<Customer>().OwnsOne(p => p.ShipAddress);

            // PK
            // modelBuilder.Entity<Customer>().HasKey(p => p.Id);

            // Klucz złożony (Composite Primary Key)
            // modelBuilder.Entity<Customer>().HasKey(p => new { p.Id, p.Pesel });


            // dotnet add package Microsoft.EntityFrameworkCore.Relational
            modelBuilder.Entity<Item>().ToTable("Items");
            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");

            modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Customer>().Property(p => p.LastName).HasMaxLength(50).IsRequired();

            modelBuilder.Entity<Customer>().Property(p => p.Pesel).IsRequired().HasMaxLength(11).IsFixedLength().IsUnicode(false);
        }


    }
}
