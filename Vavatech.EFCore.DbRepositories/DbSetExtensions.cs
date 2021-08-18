using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Vavatech.EFCore.DbRepositories
{
    public static class DbSetExtensions
    {
        public static void Remove<TEntity, TValue>(this DbSet<TEntity> dbset, TValue id)
            where TEntity : class, new()
            where TValue : struct

        {
            var context = dbset.GetService<ICurrentDbContext>().Context;

            var keyName = GetKeyName<TEntity>(context);

            TEntity entity = new();

            entity.GetType().GetProperty(keyName).SetValue(entity, id);

            context.Remove(entity);
        }

        private static string GetKeyName<TEntity>(DbContext context)
        {
            var keyName = context.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey()
                .Properties
                .Select(x => x.Name)
                .Single();

            return keyName;
        }
    }
}
