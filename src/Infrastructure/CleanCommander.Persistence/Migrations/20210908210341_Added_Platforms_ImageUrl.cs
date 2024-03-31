using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanCommander.Persistence.Migrations
{
    public partial class Added_Platforms_ImageUrl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PromptPlatformImageUrl",
                table: "PromptPlatforms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromptPlatformImageUrl",
                table: "PromptPlatforms");
        }
    }
}
