using System;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace Vavatech.EFCore.DbRepositories
{
    public class LoggerCommandInterceptor : DbCommandInterceptor
    {
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {           
            return base.ReaderExecuting(command, eventData, result);
        }

        public override DbDataReader ReaderExecuted(DbCommand command, CommandExecutedEventData eventData, DbDataReader result)
        {
            Console.BackgroundColor = ConsoleColor.Green;
            Console.WriteLine($"Started {eventData.StartTime}  {eventData.Command.CommandText} Duration  {eventData.Duration}");
            Console.ResetColor();

            return base.ReaderExecuted(command, eventData, result);
        }
    }
}
