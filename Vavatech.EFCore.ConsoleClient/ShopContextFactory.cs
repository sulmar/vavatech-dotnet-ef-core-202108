﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.EFCore.DbRepositories;

namespace Vavatech.EFCore.ConsoleClient
{
    //  dotnet add package Microsoft.EntityFrameworkCore.Design
    public class ShopContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        public ShopContext CreateDbContext(string[] args)
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Integrated Security=True;Initial Catalog=ShopDb;Application Name=Shop";

            // string connectionString2 = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=ShopDb;Integrated Security=False;User Id=john;Password=yourP@ssw0rd;Application Name=Shop";

            // dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            DbContextOptions options = new DbContextOptionsBuilder<ShopContext>()
                .UseSqlServer(connectionString)
                // .UseLazyLoadingProxies()
                //.AddInterceptors(new ModifyDateSaveChangesInterceptor())
                .Options;

            ShopContext context = new ShopContext(options);

            return context;
        }
    }

    
}
