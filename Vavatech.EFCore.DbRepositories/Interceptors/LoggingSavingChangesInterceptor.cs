using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Threading;

namespace Vavatech.EFCore.DbRepositories.Interceptors
{
    // https://khalidabuhakmeh.com/entity-framework-core-5-interceptors
    public class LoggingSavingChangesInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            Log(eventData);

            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            Log(eventData);

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void Log(DbContextEventData eventData)
        {
            Console.WriteLine(eventData.Context.ChangeTracker.DebugView.LongView);
        }
    }
}
