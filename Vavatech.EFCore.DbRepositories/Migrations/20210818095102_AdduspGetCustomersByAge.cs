using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class AdduspGetCustomersByAge : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE OR ALTER PROCEDURE dbo.uspGetCustomersByAge(@age int) AS SELECT * FROM Customers WHERE year(getdate()) - year(DateOfBirth) > @age");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.uspGetCustomersByAge");
        }
    }
}
