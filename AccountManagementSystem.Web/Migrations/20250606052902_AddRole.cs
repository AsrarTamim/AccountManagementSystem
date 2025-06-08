using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AccountManagementSystem.Web.Migrations
{
    /// <inheritdoc />
    public partial class AddRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("6b40ed0f-4b9c-4999-861a-6f0b3fc1d400"), "4/19/2025 1:02:01 AM", "Admin", "ADMIN" },
                    { new Guid("a26efde9-74f9-420e-b17e-d3e817681662"), "4/19/2025 1:02:04 AM", "Author", "AUTHOR" },
                    { new Guid("ae59c5fd-e084-409f-ac8f-f7d5e782357e"), "4/19/2025 1:02:03 AM", "HR", "HR" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("6b40ed0f-4b9c-4999-861a-6f0b3fc1d400"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("a26efde9-74f9-420e-b17e-d3e817681662"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("ae59c5fd-e084-409f-ac8f-f7d5e782357e"));
        }
    }
}
