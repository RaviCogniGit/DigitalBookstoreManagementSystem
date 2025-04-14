using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalBookstoreManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class zzz : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Authors",
                newName: "AuthorName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "AuthorName",
                table: "Authors",
                newName: "Name");
        }
    }
}
