using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Vavatech.EFCore.ConsoleClient
{
    public static class CommandExtensions
    {
        //public static void HasCancelationToken<T>(this IQueryable<T> query, DbContext context, CancellationToken cancellationToken)
        //{
        //    var sql = query.ToQueryString();

        //    SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();
        //    SqlCommand command = new SqlCommand(sql, connection);            
        //    cancellationToken.Register(() => command.Cancel());
        //    connection.Open();
        //    var reader = command.ExecuteReader();
        //}

        public static SqlCommand GetSqlCommand<T>(this IQueryable<T> query, DbContext context)
        {
            SqlConnection connection = (SqlConnection)context.Database.GetDbConnection();
            var sql = query.ToQueryString();
            SqlCommand command = new SqlCommand(sql, connection);

            return command;

        }
    }
}
