using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class StoreFullNameToCustomer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Customers",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' + [LastName]",
                stored: true,
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true,
                oldComputedColumnSql: "[FirstName] + ' ' + [LastName]",
                oldStored: null);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                table: "Customers",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true,
                computedColumnSql: "[FirstName] + ' ' + [LastName]",
                oldClrType: typeof(string),
                oldType: "varchar(250)",
                oldUnicode: false,
                oldMaxLength: 250,
                oldNullable: true,
                oldComputedColumnSql: "[FirstName] + ' ' + [LastName]");
        }
    }
}
