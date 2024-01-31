using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysAllowNull : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Category_CategoryId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Category_CategoryId",
                table: "TodoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Project_ProjectId",
                table: "TodoTask");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TodoTask",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TodoTask",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Category_CategoryId",
                table: "Project",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_Category_CategoryId",
                table: "TodoTask",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_Project_ProjectId",
                table: "TodoTask",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Category_CategoryId",
                table: "Project");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Category_CategoryId",
                table: "TodoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Project_ProjectId",
                table: "TodoTask");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "TodoTask",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "TodoTask",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Category_CategoryId",
                table: "Project",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_Category_CategoryId",
                table: "TodoTask",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_Project_ProjectId",
                table: "TodoTask",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
