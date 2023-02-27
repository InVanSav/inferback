using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inferback.Migrations
{
    /// <inheritdoc />
    public partial class FixedBugs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "bug_type_hum",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "hash",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "key",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "node_key",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "procedure",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "procedure_start_line",
                table: "Descriptions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "bug_type_hum",
                table: "Descriptions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "hash",
                table: "Descriptions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "key",
                table: "Descriptions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "node_key",
                table: "Descriptions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "procedure",
                table: "Descriptions",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "procedure_start_line",
                table: "Descriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
