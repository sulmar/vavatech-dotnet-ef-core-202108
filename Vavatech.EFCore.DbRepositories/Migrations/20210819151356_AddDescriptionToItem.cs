using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class AddDescriptionToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                column: "CreatedOn",
                value: new DateTime(2021, 8, 19, 17, 13, 55, 363, DateTimeKind.Local).AddTicks(2302));

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 19, 17, 13, 55, 363, DateTimeKind.Local).AddTicks(2993));

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 19, 17, 13, 55, 363, DateTimeKind.Local).AddTicks(3023));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 19, 16, 56, 14, 7, DateTimeKind.Local).AddTicks(3107));

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 19, 16, 56, 14, 7, DateTimeKind.Local).AddTicks(3843));

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 19, 16, 56, 14, 7, DateTimeKind.Local).AddTicks(3896));
        }
    }
}
