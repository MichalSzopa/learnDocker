using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class CategoryMigrationFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_UserId1",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "UserId1",
                table: "Category",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Category_UserId1",
                table: "Category",
                newName: "IX_Category_UserId");

            migrationBuilder.AddColumn<int>(
                name: "Color",
                table: "Category",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsPredefined",
                table: "Category",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_UserId",
                table: "Category",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_User_UserId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "IsPredefined",
                table: "Category");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Category",
                newName: "UserId1");

            migrationBuilder.RenameIndex(
                name: "IX_Category_UserId",
                table: "Category",
                newName: "IX_Category_UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_User_UserId1",
                table: "Category",
                column: "UserId1",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
