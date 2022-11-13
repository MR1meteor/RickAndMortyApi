using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RickAndMortyApi.Migrations
{
    public partial class AddTopicOwnerField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Topics",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Topics_OwnerId",
                table: "Topics",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_UserProfiles_OwnerId",
                table: "Topics",
                column: "OwnerId",
                principalTable: "UserProfiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topics_UserProfiles_OwnerId",
                table: "Topics");

            migrationBuilder.DropIndex(
                name: "IX_Topics_OwnerId",
                table: "Topics");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Topics");
        }
    }
}
