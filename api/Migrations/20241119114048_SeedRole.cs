using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class SeedRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6c421a85-a463-4fe5-8520-8e2561eda994");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9b405bc2-a456-40bc-a12f-95849c0fba15");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5c22dcb2-8648-45e1-b41c-7739085cc6f6", null, "Admin", "ADMIN" },
                    { "bdab5974-47cf-4ead-8307-0b8f171ad499", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c22dcb2-8648-45e1-b41c-7739085cc6f6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bdab5974-47cf-4ead-8307-0b8f171ad499");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6c421a85-a463-4fe5-8520-8e2561eda994", null, "Admin", "ADMIN" },
                    { "9b405bc2-a456-40bc-a12f-95849c0fba15", null, "User", "USER" }
                });
        }
    }
}
