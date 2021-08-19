using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vavatech.EFCore.DbRepositories;

namespace Vavatech.EFCore.MVCApp.Middlewares
{
    public class DbContextMiddleware<TContext> : IMiddleware
        where TContext : DbContext
    {
        private readonly TContext context;

        public DbContextMiddleware(TContext context)
        {
            this.context = context;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (context.Request.Path == "/database" && HttpMethods.IsGet(context.Request.Method))
            {
                string content = GetMetadataContext(this.context);

                await context.Response.WriteAsync(content);
                context.Response.StatusCode = StatusCodes.Status200OK;

            }

            await next.Invoke(context);
        }


        private static string GetMetadataContext(DbContext context)
        {
            StringBuilder builder = new StringBuilder();

            var entityTypes = context.Model.GetEntityTypes();

            foreach (var entityType in entityTypes)
            {
                var tableName = entityType.GetTableName();

                builder.AppendLine($"==== {tableName} ====");

                // var keys = entityType.GetDeclaredKeys();

                foreach (var property in entityType.GetProperties())
                {
                    var columnName = property.GetColumnName();

                    if (property.IsKey())
                        builder.Append("PK ");

                    if (property.IsForeignKey())
                        builder.Append("FK ");

                    builder.AppendLine($"{columnName} {property.ClrType.Name}");
                }

            }

            return builder.ToString();
        }
    }
}
