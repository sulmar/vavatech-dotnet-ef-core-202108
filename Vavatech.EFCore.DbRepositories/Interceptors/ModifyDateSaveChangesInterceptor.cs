using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Threading;

namespace Vavatech.EFCore.DbRepositories.Interceptors
{


    // https://docs.microsoft.com/pl-pl/ef/core/logging-events-diagnostics/interceptors#savechanges-interception
    public class ModifyDateSaveChangesInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            SetModifiedOn(eventData, result);

            return new ValueTask<InterceptionResult<int>>(result);
        }

        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            return SetModifiedOn(eventData, result);
        }

        private static InterceptionResult<int> SetModifiedOn(DbContextEventData eventData, InterceptionResult<int> result)
        {
            var modified = eventData.Context.ChangeTracker.Entries()
                            .Where(e => e.State == EntityState.Modified)
                            .Select(e => e.Entity)
                            .OfType<BaseEntity>();

            foreach (var entity in modified)
            {
                entity.ModifiedOn = DateTime.Now;
            }

            return result;
        }

       
    }
}
