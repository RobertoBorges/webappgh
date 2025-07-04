using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketSystem.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 8, 15, 19, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 7, 25, 20, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 8, 30, 18, 30, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2025, 8, 3, 17, 35, 47, 784, DateTimeKind.Local).AddTicks(2407));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2025, 7, 19, 17, 35, 47, 785, DateTimeKind.Local).AddTicks(1164));

            migrationBuilder.UpdateData(
                table: "Shows",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2025, 8, 18, 17, 35, 47, 785, DateTimeKind.Local).AddTicks(1189));
        }
    }
}
