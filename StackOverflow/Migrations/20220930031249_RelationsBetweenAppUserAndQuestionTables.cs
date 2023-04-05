using Microsoft.EntityFrameworkCore.Migrations;

namespace StackOverflow.Migrations
{
    public partial class RelationsBetweenAppUserAndQuestionTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AppUserId",
                table: "Questions",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_AppUserId",
                table: "Questions",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_AspNetUsers_AppUserId",
                table: "Questions",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_AspNetUsers_AppUserId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_AppUserId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Questions");
        }
    }
}
