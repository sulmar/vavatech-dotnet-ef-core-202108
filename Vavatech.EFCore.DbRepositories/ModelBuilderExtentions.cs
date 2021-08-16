using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Vavatech.EFCore.DbRepositories
{
    public static class ModelBuilderExtentions
    {
        public static IEnumerable<IMutableProperty> Properties(this ModelBuilder modelBuilder)
        {
            return from e in modelBuilder.Model.GetEntityTypes()
                   from p in e.GetProperties()
                   select p;
        }

        public static IEnumerable<IMutableProperty> Properties<T>(this ModelBuilder modelBuilder)
        {
            return modelBuilder.Properties().Where(p => p.PropertyInfo?.PropertyType == typeof(T));
        }

        public static void Configure(this IEnumerable<IMutableProperty> properties, Action<IMutableProperty> configuration)
        {
            foreach (IMutableProperty property in properties)
            {
                configuration.Invoke(property);
            }
        }
    }
}
