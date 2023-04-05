using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StackOverflow.Migrations
{
    public partial class CompanyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Questions",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    About = table.Column<string>(nullable: false),
                    AboutImage = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: false),
                    OriginHistory = table.Column<DateTime>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    WebSiteLink = table.Column<string>(nullable: false),
                    WebSiteLinkName = table.Column<string>(nullable: false),
                    Industry = table.Column<string>(nullable: false),
                    Benefits = table.Column<string>(nullable: false),
                    VideoLink = table.Column<string>(nullable: false),
                    VideoImage = table.Column<string>(nullable: true),
                    PostImage = table.Column<string>(nullable: true),
                    PostDesc = table.Column<string>(nullable: false),
                    PostUpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Desc",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
