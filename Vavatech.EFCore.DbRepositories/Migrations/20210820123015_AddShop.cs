using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class AddShop : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Location = table.Column<Point>(type: "geography", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ExpirationDate" },
                values: new object[] { new DateTime(2021, 8, 20, 14, 30, 14, 900, DateTimeKind.Local).AddTicks(7737), new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ExpirationDate" },
                values: new object[] { new DateTime(2021, 8, 20, 14, 30, 14, 900, DateTimeKind.Local).AddTicks(8488), new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ExpirationDate" },
                values: new object[] { new DateTime(2021, 8, 20, 14, 30, 14, 900, DateTimeKind.Local).AddTicks(8547), new DateTime(2021, 9, 19, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "CreatedOn", "Location", "ModifiedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2021, 8, 20, 14, 30, 14, 917, DateTimeKind.Local).AddTicks(7320), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (27.175015 78.042155)"), null, "Taj Mahal" },
                    { 2, new DateTime(2021, 8, 20, 14, 30, 14, 919, DateTimeKind.Local).AddTicks(5581), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (31.61998 74.876485)"), null, "The Golden Temple of Amritsar" },
                    { 3, new DateTime(2021, 8, 20, 14, 30, 14, 919, DateTimeKind.Local).AddTicks(5660), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (28.656159 77.24102)"), null, "The Red Fort, New Delhi" },
                    { 4, new DateTime(2021, 8, 20, 14, 30, 14, 919, DateTimeKind.Local).AddTicks(5666), (NetTopologySuite.Geometries.Point)new NetTopologySuite.IO.WKTReader().Read("SRID=4326;POINT (18.921984 72.834654)"), null, "The Gateway of India, Mumbai" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Items",
                type: "varchar(250)",
                unicode: false,
                maxLength: 250,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedOn", "ExpirationDate" },
                values: new object[] { new DateTime(2021, 8, 19, 17, 13, 55, 363, DateTimeKind.Local).AddTicks(2302), new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedOn", "ExpirationDate" },
                values: new object[] { new DateTime(2021, 8, 19, 17, 13, 55, 363, DateTimeKind.Local).AddTicks(2993), new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedOn", "ExpirationDate" },
                values: new object[] { new DateTime(2021, 8, 19, 17, 13, 55, 363, DateTimeKind.Local).AddTicks(3023), new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Local) });
        }
    }
}
