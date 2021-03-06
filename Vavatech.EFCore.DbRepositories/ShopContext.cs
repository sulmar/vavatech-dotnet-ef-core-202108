using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Sulmar.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Vavatech.EFCore.DbRepositories.Configurations;
using Vavatech.EFCore.IRepositories;

namespace Vavatech.EFCore.DbRepositories
{
    public static class DbSetTotalAmountCountryExtensions
    {
        public static IQueryable<TotalAmountCountry> GetTotalAmountByCountry(this DbSet<TotalAmountCountry> dbset, int year)
        {
            ShopContext context = dbset.GetService<ICurrentDbContext>().Context as ShopContext;

            return context.GetTotalAmountByCountry(year);
        }
        
    }


    public class IdentityDbContext : DbContext
    {
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure
        }
    }


    // dotnet add package Microsoft.EntityFrameworkCore
    public class ShopContext : DbContext
    {
        public ShopContext([NotNull] DbContextOptions options) : base(options)
        {
            // this.Database.EnsureCreated();            

            // ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<LoyaltyCard> LoyaltyCards { get; set; }
        public DbSet<CustomerGroup> CustomerGroups { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Attachment> Attachments { get; set; }
        public DbSet<TotalAmountCountry> TotalAmountCountries { get; set; }

        public DbSet<Dictionary<string, object>> Devices => Set<Dictionary<string, object>>("Device");

        public DbSet<Vehicle> Vehicles => Set<Vehicle>("Vehicle");

        public DbSet<Shop> Shops { get; set; }

        public int CalculateAge(DateTime dateTime) => throw new NotSupportedException();

        public IQueryable<TotalAmountCountry> GetTotalAmountByCountry(int year) =>
            FromExpression(() => GetTotalAmountByCountry(year));

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SharedTypeEntity<Dictionary<string, object>>("Device", d =>
            {
                d.IndexerProperty<int>("Id");
                d.IndexerProperty<string>("Name").IsRequired();
                d.IndexerProperty<decimal>("Price");
            });


            modelBuilder.SharedTypeEntity<Vehicle>("Vehicle").HasKey(p => p.Id);

          

            //modelBuilder.SharedTypeEntity<List<Vehicle>>("Vehicles", d =>
            //{
            //    d.HasKey(d=>d.)
            //    d.IndexerProperty<string>("Name").IsRequired();
            //    d.IndexerProperty<float>("Capacity");
            //    d.IndexerProperty<string>("Model").IsRequired();
            //});

            modelBuilder.HasDbFunction(typeof(ShopContext).GetMethod(nameof(CalculateAge), new[] { typeof(DateTime) })).HasName("GetAge");

            modelBuilder.HasDbFunction(typeof(ShopContext).GetMethod(nameof(GetTotalAmountByCountry), new[] { typeof(int) })).HasName("TotalAmountByCountryForYear");

            // Owned Entities (https://docs.microsoft.com/en-us/ef/core/modeling/owned-entities)
            //modelBuilder.Entity<Customer>().OwnsOne(p => p.InvoiceAddress);
            //modelBuilder.Entity<Customer>().OwnsOne(p => p.ShipAddress);
            //modelBuilder.Entity<Customer>().Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<Customer>().Property(p => p.LastName).HasMaxLength(50).IsRequired();
            //modelBuilder.Entity<Customer>().Property(p => p.Pesel).IsRequired().HasMaxLength(11).IsFixedLength().IsUnicode(false);

            // PK
            // modelBuilder.Entity<Customer>().HasKey(p => p.Id);

            // Klucz złożony (Composite Primary Key)
            // modelBuilder.Entity<Customer>().HasKey(p => new { p.Id, p.Pesel });


            // dotnet add package Microsoft.EntityFrameworkCore.Relational
            // modelBuilder.Entity<Item>().ToTable("Items");


            // modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");


            //modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            //modelBuilder.ApplyConfiguration(new ItemConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderDetailConfiguration());

            // Automatyczne ładowanie wszystkich konfiguracji IEntityTypeConfiguration<T>

            // Tworzenie własnych konwencji
            //var properties = (from e in modelBuilder.Model.GetEntityTypes()
            //                  from p in e.GetProperties()
            //                  where p.PropertyInfo?.PropertyType == typeof(string)
            //                  select p).ToList();

            //var properties = modelBuilder.Properties<string>();

            //foreach (var property in properties)
            //{
            //    property.SetMaxLength(100);
            //    property.SetIsUnicode(false);
            //}

            modelBuilder.Properties<string>().Configure(c =>
            {
                c.SetMaxLength(250);
                c.SetIsUnicode(false);
            });

            modelBuilder.Properties<DateTime>()                
                .Configure(c => c.SetColumnType("datetime"));


            //modelBuilder.Properties()
            //    .Where(p => p.Name == p.DeclaringType.Name + "Id")
            //    .Configure(c => c.IsKey());

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerConfiguration).Assembly);

            // modelBuilder.Entity<Address>().Property(p => p.City).HasMaxLength(50);


            // dotnet add package Microsoft.EntityFrameworkCore.Tools

            // EF Core 5 Wykluczenie tabeli z migracji
            modelBuilder.Entity<ApplicationUser>().ToTable("ApplicationUsers", t => t.ExcludeFromMigrations());

            // INotifyPropertyChanged
            // modelBuilder.HasChangeTrackingStrategy(ChangeTrackingStrategy.ChangedNotifications);

        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
