using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Vavatech.EFCore.DbRepositories.Migrations
{
    public partial class AddVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    Capacity = table.Column<float>(type: "real", nullable: false),
                    Model = table.Column<string>(type: "varchar(250)", unicode: false, maxLength: 250, nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicle", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 40, 53, 910, DateTimeKind.Local).AddTicks(6057));

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 40, 53, 910, DateTimeKind.Local).AddTicks(6835));

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 40, 53, 910, DateTimeKind.Local).AddTicks(6860));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 40, 53, 922, DateTimeKind.Local).AddTicks(9707));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 40, 53, 924, DateTimeKind.Local).AddTicks(3369));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 40, 53, 924, DateTimeKind.Local).AddTicks(3393));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 40, 53, 924, DateTimeKind.Local).AddTicks(3398));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicle");

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 20, 56, 965, DateTimeKind.Local).AddTicks(2344));

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 20, 56, 965, DateTimeKind.Local).AddTicks(3029));

            migrationBuilder.UpdateData(
                table: "LoyaltyCards",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 20, 56, 965, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 20, 56, 976, DateTimeKind.Local).AddTicks(9420));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 20, 56, 978, DateTimeKind.Local).AddTicks(3049));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 20, 56, 978, DateTimeKind.Local).AddTicks(3076));

            migrationBuilder.UpdateData(
                table: "Shops",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedOn",
                value: new DateTime(2021, 8, 20, 16, 20, 56, 978, DateTimeKind.Local).AddTicks(3080));
        }
    }
}
