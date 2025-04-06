using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer_TodoApp.DataAccess.Data.Migrations
{
    /// <inheritdoc />
    public partial class CategoryDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryWork_Category_CategoryId",
                table: "CategoryWork");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryWork_Works_WorkId",
                table: "CategoryWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryWork",
                table: "CategoryWork");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "CategoryWork",
                newName: "CategoryWorks");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryWork_CategoryId",
                table: "CategoryWorks",
                newName: "IX_CategoryWorks_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryWorks",
                table: "CategoryWorks",
                columns: new[] { "WorkId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryWorks_Categories_CategoryId",
                table: "CategoryWorks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryWorks_Works_WorkId",
                table: "CategoryWorks",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryWorks_Categories_CategoryId",
                table: "CategoryWorks");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryWorks_Works_WorkId",
                table: "CategoryWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryWorks",
                table: "CategoryWorks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "CategoryWorks",
                newName: "CategoryWork");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Category");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryWorks_CategoryId",
                table: "CategoryWork",
                newName: "IX_CategoryWork_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryWork",
                table: "CategoryWork",
                columns: new[] { "WorkId", "CategoryId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryWork_Category_CategoryId",
                table: "CategoryWork",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryWork_Works_WorkId",
                table: "CategoryWork",
                column: "WorkId",
                principalTable: "Works",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
