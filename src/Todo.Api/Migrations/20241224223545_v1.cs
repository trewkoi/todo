using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Todo.Api.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "NVARCHAR(120)", maxLength: 120, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TodoTask",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Completed = table.Column<bool>(type: "bit", nullable: false),
                    Priority = table.Column<short>(type: "SMALLINT", nullable: false),
                    Status = table.Column<short>(type: "SMALLINT", nullable: false),
                    AssignedTo = table.Column<string>(type: "VARCHAR(64)", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TodoTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TodoTask_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskId = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    AuthorId = table.Column<string>(type: "VARCHAR(255)", maxLength: 255, nullable: false),
                    Content = table.Column<string>(type: "NVARCHAR(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TodoTaskId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_TodoTask_TodoTaskId",
                        column: x => x.TodoTaskId,
                        principalTable: "TodoTask",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comment_TodoTaskId",
                table: "Comment",
                column: "TodoTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoTask_CategoryId",
                table: "TodoTask",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "TodoTask");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
