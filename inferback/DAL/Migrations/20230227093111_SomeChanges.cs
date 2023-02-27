using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace inferback.Migrations
{
    /// <inheritdoc />
    public partial class SomeChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Descriptions_descriptionId",
                table: "Reports");

            migrationBuilder.DropIndex(
                name: "IX_Reports_descriptionId",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "descriptionId",
                table: "Reports");

            migrationBuilder.AddColumn<int>(
                name: "reportId",
                table: "Descriptions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Descriptions_reportId",
                table: "Descriptions",
                column: "reportId");

            migrationBuilder.AddForeignKey(
                name: "FK_Descriptions_Reports_reportId",
                table: "Descriptions",
                column: "reportId",
                principalTable: "Reports",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Descriptions_Reports_reportId",
                table: "Descriptions");

            migrationBuilder.DropIndex(
                name: "IX_Descriptions_reportId",
                table: "Descriptions");

            migrationBuilder.DropColumn(
                name: "reportId",
                table: "Descriptions");

            migrationBuilder.AddColumn<int>(
                name: "descriptionId",
                table: "Reports",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reports_descriptionId",
                table: "Reports",
                column: "descriptionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Descriptions_descriptionId",
                table: "Reports",
                column: "descriptionId",
                principalTable: "Descriptions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
