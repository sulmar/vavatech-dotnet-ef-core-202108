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

            var resourceName = assembly.GetManifestResourceNames().SingleOrDefault(x => x.EndsWith(sqlResource));

            if (resourceName == null)
            {
                throw new FileNotFoundException($"Unable to find the SQL file {sqlResource} from an embedded resource", sqlResource);
            }

            using var stream = assembly.GetManifestResourceStream(resourceName);
            using var reader = new StreamReader(stream);

            if (stream == null)
            {
                throw new FileNotFoundException($"Unable to find the SQL file {sqlResource} from an embedded resource", sqlResource);
            }

            var sqlResult = reader.ReadToEnd();
            
            return migrationBuilder.Sql(sqlResult, suppressTransaction);

     
        }

     
    }

}
