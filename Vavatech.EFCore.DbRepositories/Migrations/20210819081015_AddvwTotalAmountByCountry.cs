using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class AddvwTotalAmountByCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("vwTotalAmountByCountry.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.vwTotalAmountByCountry");
            
            //migrationBuilder.DropView(string name, string schema = null);
            //migrationBuilder.DropFunction
        }
    }
}
