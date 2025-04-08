using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DigitalBookstoreManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class mio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookID",
                table: "Books",
                newName: "BookId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BookId",
                table: "Books",
                newName: "BookID");
        }
    }
}
