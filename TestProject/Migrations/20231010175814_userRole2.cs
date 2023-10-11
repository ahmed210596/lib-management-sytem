using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TestProject.Migrations
{
    /// <inheritdoc />
    public partial class userRole2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffebdeec-16b2-4ca7-a418-e69b4adcd10e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "08926fb3-adaa-4a42-aff5-818d8bd24c80", "ce9993e9-236a-42e4-8811-459fb0458c29", "Admin", "admin" },
                    { "fa84e892-6e2d-48e3-a9d0-a66ccfc7a5c1", "d20c4999-46a3-403b-8719-61ea79921168", "User", "user" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "08926fb3-adaa-4a42-aff5-818d8bd24c80");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fa84e892-6e2d-48e3-a9d0-a66ccfc7a5c1");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffebdeec-16b2-4ca7-a418-e69b4adcd10e", "fd2b98e7-5b89-414e-89af-f42ae95fbacd", "Admin", "admin" });
        }
    }
}
