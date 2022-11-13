using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RickAndMortyApi.Migrations
{
    public partial class AddTopicTextField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Text",
                table: "Topics",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Text",
                table: "Topics");
        }
    }
}
