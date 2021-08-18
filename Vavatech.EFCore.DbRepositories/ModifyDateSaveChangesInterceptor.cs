using Microsoft.EntityFrameworkCore;
using Sulmar.EFCore.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Threading;

namespace Vavatech.EFCore.DbRepositories
{


    // https://docs.microsoft.com/pl-pl/ef/core/logging-events-diagnostics/interceptors#savechanges-interception
    public class ModifyDateSaveChangesInterceptor : ISaveChangesInterceptor
    {
        public void SaveChangesFailed(DbContextErrorEventData eventData)
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesFailedAsync(DbContextErrorEventData eventData, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            return result;
        }

        public ValueTask<int> SavedChangesAsync(SaveChangesCompletedEventData eventData, int result, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
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

        public ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
