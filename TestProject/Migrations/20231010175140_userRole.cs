using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestProject.Migrations
{
    /// <inheritdoc />
    public partial class userRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ffebdeec-16b2-4ca7-a418-e69b4adcd10e", "fd2b98e7-5b89-414e-89af-f42ae95fbacd", "Admin", "admin" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ffebdeec-16b2-4ca7-a418-e69b4adcd10e");
        }
    }
}
