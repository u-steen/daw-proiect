using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CategorieUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2d9259e8-f5c5-45a3-847d-036a9d92c08e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35d4fad2-1cbe-43c9-bbae-215b87d49075");

            migrationBuilder.AddColumn<string>(
                name: "Descriere",
                table: "Categorii",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "d168e255-a4bc-4efe-b659-5f5a5e0e6a87", null, "Admin", "ADMIN" },
                    { "d5089bce-6d63-4a57-a596-3b50dbb4d733", null, "User", "USER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d168e255-a4bc-4efe-b659-5f5a5e0e6a87");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d5089bce-6d63-4a57-a596-3b50dbb4d733");

            migrationBuilder.DropColumn(
                name: "Descriere",
                table: "Categorii");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2d9259e8-f5c5-45a3-847d-036a9d92c08e", null, "User", "USER" },
                    { "35d4fad2-1cbe-43c9-bbae-215b87d49075", null, "Admin", "ADMIN" }
                });
        }
    }
}
