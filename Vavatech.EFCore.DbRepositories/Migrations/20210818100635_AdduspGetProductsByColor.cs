using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class AdduspGetProductsByColor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("CREATE OR ALTER PROCEDURE dbo.uspGetProductsByColor(@color varchar(max)) AS SELECT * FROM dbo.Items WHERE Discriminator = 'Product' AND Color = @color");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE dbo.uspGetProductsByColor");
        }
    }
}
