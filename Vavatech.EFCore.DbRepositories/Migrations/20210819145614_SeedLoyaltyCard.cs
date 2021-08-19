using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class SeedLoyaltyCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "LoyaltyCards",
                columns: new[] { "Id", "CreatedOn", "ExpirationDate", "ModifiedOn", "OwnerId", "SerialNumber" },
                values: new object[] { 1, new DateTime(2021, 8, 19, 16, 56, 14, 7, DateTimeKind.Local).AddTicks(3107), new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), null, 1, "111111" });

            migrationBuilder.InsertData(
                table: "LoyaltyCards",
                columns: new[] { "Id", "CreatedOn", "ExpirationDate", "ModifiedOn", "OwnerId", "SerialNumber" },
                values: new object[] { 2, new DateTime(2021, 8, 19, 16, 56, 14, 7, DateTimeKind.Local).AddTicks(3843), new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), null, 2, "222222" });

            migrationBuilder.InsertData(
                table: "LoyaltyCards",
                columns: new[] { "Id", "CreatedOn", "ExpirationDate", "ModifiedOn", "OwnerId", "SerialNumber" },
                values: new object[] { 3, new DateTime(2021, 8, 19, 16, 56, 14, 7, DateTimeKind.Local).AddTicks(3896), new DateTime(2021, 9, 18, 0, 0, 0, 0, DateTimeKind.Local), null, 3, "333333" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
