using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vavatech.EFCore.DbRepositories
{
    public static class ModelBuilderExtentions
    {
        public static IEnumerable<IMutableProperty> Properties<T>(this ModelBuilder modelBuilder)
        {
            return from e in modelBuilder.Model.GetEntityTypes()
                              from p in e.GetProperties()
                              where p.PropertyInfo?.PropertyType == typeof(T)
                   select p;

        }

        public static void Configure(this IEnumerable<IMutableProperty> properties, Action<IMutableProperty> configuration)
        {
            foreach (var property in properties)
            {
                configuration.Invoke(property);
            }
        }
    }
}
