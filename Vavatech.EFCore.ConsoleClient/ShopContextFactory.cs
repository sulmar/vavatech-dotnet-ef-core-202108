using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.EFCore.DbRepositories;
using Vavatech.EFCore.DbRepositories.Interceptors;

namespace Vavatech.EFCore.ConsoleClient
{
    //  dotnet add package Microsoft.EntityFrameworkCore.Design
    public class ShopContextFactory : IDesignTimeDbContextFactory<ShopContext>
    {
        public ShopContext CreateDbContext(string[] args)
        {
            string connectionString = @"Data Source=(local)\SQLEXPRESS;Integrated Security=True;Initial Catalog=ShopDb;Application Name=Shop;MultipleActiveResultSets=True";

            // string connectionString2 = @"Data Source=(local)\SQLEXPRESS;Initial Catalog=ShopDb;Integrated Security=False;User Id=john;Password=yourP@ssw0rd;Application Name=Shop";

            // dotnet add package Microsoft.EntityFrameworkCore.SqlServer
            DbContextOptions options = new DbContextOptionsBuilder<ShopContext>()
                .UseSqlServer(connectionString, options =>
                {
                    // options.MaxBatchSize(99);

                    // dotnet add packackage Microsoft.EntityFrameworkCore.SqlServer.NetTopologySuite
                    options.UseNetTopologySuite();
                })
                .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information)
                // .UseLazyLoadingProxies()
                //.AddInterceptors(new ModifyDateSaveChangesInterceptor())
                .AddInterceptors(new LoggerCommandInterceptor())
                .AddInterceptors(new LoggingSavingChangesInterceptor())
                .ReplaceService<IMigrationsSqlGenerator, MyMigrationsSqlGenerator>()

                
                
                .Options;

            ShopContext context = new ShopContext(options);

            return context;
        }
    }

    
}
