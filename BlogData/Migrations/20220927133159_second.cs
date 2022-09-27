using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogData.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FontColor",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FontFamily",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FontSize",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FontColor",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FontFamily",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "FontSize",
                table: "Articles");
        }
    }
}
