using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TangyAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "AddedOn", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "Entree" },
                    { 2, new DateTime(2026, 2, 23, 0, 0, 0, 0, DateTimeKind.Utc), "Appetiser" },
                    { 3, new DateTime(2026, 3, 17, 0, 0, 0, 0, DateTimeKind.Utc), "Desert" },
                    { 4, new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Starter" },
                    { 5, new DateTime(2026, 5, 19, 0, 0, 0, 0, DateTimeKind.Utc), "Snaks" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
