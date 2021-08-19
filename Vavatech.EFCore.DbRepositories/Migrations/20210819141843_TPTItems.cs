using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class TPTItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
              name: "Products",
              columns: table => new
              {
                  Id = table.Column<int>(type: "int", nullable: false),
                  Color = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                  Weight = table.Column<float>(type: "real", nullable: false)
              },
              constraints: table =>
              {
                  table.PrimaryKey("PK_Products", x => x.Id);
                  table.ForeignKey(
                      name: "FK_Products_Items_Id",
                      column: x => x.Id,
                      principalTable: "Items",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
              });


      
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Duration = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Items_Id",
                        column: x => x.Id,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.Sql("INSERT INTO [ShopDb].[dbo].[Products] (Id, Color, Weight) SELECT Id, Color, Weight FROM [ShopDb].[dbo].[Items] WHERE Discriminator = 'Product'");
            migrationBuilder.Sql("INSERT INTO [ShopDb].[dbo].[Services] (Id, Duration) SELECT Id, Duration FROM [ShopDb].[dbo].[Items] WHERE Discriminator = 'Service'");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Items");

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Items",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Duration",
                table: "Items",
                type: "time",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Items",
                type: "real",
                nullable: true);
        }
    }
}
