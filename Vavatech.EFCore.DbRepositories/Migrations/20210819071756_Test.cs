using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class Test : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.SqlResource("Lorem.sql");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
