using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class AddGetCustomerByPesel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE PROCEDURE dbo.usp_GetCustomerByPesel(@pesel char(11)) AS BEGIN SELECT * FROM dbo.Customers WHERE Pesel = @pesel AND IsRemoved = 0 END");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.usp_GetCustomerByPesel");
        }
    }
}
