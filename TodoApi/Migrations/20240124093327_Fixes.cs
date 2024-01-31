using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class Fixes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RepetitionInterval",
                table: "TodoTask",
                newName: "Version");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TodoTask",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TodoTask");

            migrationBuilder.RenameColumn(
                name: "Version",
                table: "TodoTask",
                newName: "RepetitionInterval");
        }
    }
}
