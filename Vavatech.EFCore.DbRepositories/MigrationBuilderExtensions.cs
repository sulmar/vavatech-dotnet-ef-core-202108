using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Vavatech.EFCore.DbRepositories
{
    public static class MigrationBuilderExtensions
    {
        public static OperationBuilder<SqlOperation> SqlResource(this MigrationBuilder migrationBuilder, string sqlResource, bool suppressTransaction = false)
        {
            var assembly = Assembly.GetExecutingAssembly();

            var resourceName = assembly.GetManifestResourceNames().FirstOrDefault(x => x.EndsWith(sqlResource));
            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);

            if (stream == null)
            {
                throw new FileNotFoundException($"Unable to find the SQL file from an embedded resource {resourceName}", resourceName);
            }

            var sqlResult = reader.ReadToEnd();
            
            return migrationBuilder.Sql(sqlResult, suppressTransaction);

     
        }

     
    }

}
