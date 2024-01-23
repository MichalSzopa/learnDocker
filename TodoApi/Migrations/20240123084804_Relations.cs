using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Category_CategoryId",
                table: "TodoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Project_ProjectId",
                table: "TodoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_TodoTask_ParentTaskId",
                table: "TodoTask");

            migrationBuilder.DropIndex(
                name: "IX_TodoTask_ParentTaskId",
                table: "TodoTask");

            migrationBuilder.DropColumn(
                name: "ParentTaskId",
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

            migrationBuilder.CreateIndex(
                name: "IX_TodoTask_ParentId",
                table: "TodoTask",
                column: "ParentId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_TodoTask_ParentId",
                table: "TodoTask",
                column: "ParentId",
                principalTable: "TodoTask",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Category_CategoryId",
                table: "TodoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_Project_ProjectId",
                table: "TodoTask");

            migrationBuilder.DropForeignKey(
                name: "FK_TodoTask_TodoTask_ParentId",
                table: "TodoTask");

            migrationBuilder.DropIndex(
                name: "IX_TodoTask_ParentId",
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

            migrationBuilder.AddColumn<int>(
                name: "ParentTaskId",
                table: "TodoTask",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TodoTask_ParentTaskId",
                table: "TodoTask",
                column: "ParentTaskId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_TodoTask_TodoTask_ParentTaskId",
                table: "TodoTask",
                column: "ParentTaskId",
                principalTable: "TodoTask",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
