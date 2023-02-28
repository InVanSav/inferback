using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inferback.Migrations
{
    /// <inheritdoc />
    public partial class ChangeFiledsOfEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "path",
                table: "Reports",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "Descriptions",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "path",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "name",
                table: "Descriptions");
        }
    }
}
