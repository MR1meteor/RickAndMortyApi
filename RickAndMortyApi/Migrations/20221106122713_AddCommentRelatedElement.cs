using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RickAndMortyApi.Migrations
{
    public partial class AddCommentRelatedElement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RelatedElementId",
                table: "Comments",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RelatedElementId",
                table: "Comments");
        }
    }
}
