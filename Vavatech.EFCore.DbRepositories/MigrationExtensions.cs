using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.EntityFrameworkCore.Migrations.Operations.Builders;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Vavatech.EFCore.DbRepositories
{
    // Tworzenie własnych operacj migracji
    // https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/operations

    // https://github.com/dotnet/efcore/blob/main/src/EFCore.SqlServer/Migrations/SqlServerMigrationsSqlGenerator.cs


    // Z użyciem MigrationBuilder.Sql()
    //public static class MigrationExtensions
    //{
    //    public static OperationBuilder<SqlOperation> DropView(this MigrationBuilder builder, string name, string schema = null)
    //    {
    //        if (schema == null)
    //            return builder.Sql($"DROP VIEW {name}");
    //        else
    //            return builder.Sql($"DROP VIEW {schema}.{name}");
    //    }

    //}

    // Z użyciem MigrationOperation

    public static class MigrationExtensions
    {

        public static OperationBuilder<DropViewOperation> DropView(this MigrationBuilder builder, string name, string schema = null)
        {
            var operation = new DropViewOperation { Schema = schema, Name = name };
            builder.Operations.Add(operation);

            return new OperationBuilder<DropViewOperation>(operation);
        }
    }

    public class MyMigrationsSqlGenerator : SqlServerMigrationsSqlGenerator
    {
        public MyMigrationsSqlGenerator(
            [NotNullAttribute] MigrationsSqlGeneratorDependencies dependencies,
            [NotNullAttribute] IRelationalAnnotationProvider migrationsAnnotations)
            : base(dependencies, migrationsAnnotations)
        {
        }

        protected override void Generate(MigrationOperation operation, IModel model, MigrationCommandListBuilder builder)
        {
            if (operation is DropViewOperation dropViewOperation)
            {
                Generate(dropViewOperation, builder);
            }
            else
            {
                base.Generate(operation, model, builder);
            }

        }

        private void Generate(DropViewOperation operation, MigrationCommandListBuilder builder)
        {
            builder
                 .Append($"DROP VIEW ")
                 .Append(operation.Name)
                 .AppendLine(Dependencies.SqlGenerationHelper.StatementTerminator)
                 .EndCommand();
        }
    }

    

    //
    // Summary:
    //     Represents a migration operation on a view.
    public interface IViewMigrationOperation
    {
        //
        // Summary:
        //     The schema that contains the view, or null if the default schema should be used.
        string Schema
        {
            get;
        }

        //
        // Summary:
        //     The view that contains the target of this operation.
        string View
        {
            get;
        }
    }

    [DebuggerDisplay("DROP VIEW {Name}")]
    public class DropViewOperation : MigrationOperation, IViewMigrationOperation
    {
        public DropViewOperation() => IsDestructiveChange = true;

        /// <summary>
        ///  The name of the view.
        /// </summary>
        public virtual string Name { get; set; } = null!;

        public virtual string Schema { get; set; }

        /// <inheritdoc />
        string IViewMigrationOperation.View => Name;
    }
}
