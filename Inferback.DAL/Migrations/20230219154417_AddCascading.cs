using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inferback.DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddCascading : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "projectId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_projectId",
                table: "Reports",
                column: "projectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Projects_projectId",
                table: "Reports",
                column: "projectId",
                principalTable: "Projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Projects_projectId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_projectId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "projectId",
                table: "Reports");
        }
    }
}
