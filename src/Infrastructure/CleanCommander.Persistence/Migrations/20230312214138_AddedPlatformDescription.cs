using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanCommander.Persistence.Migrations
{
    public partial class AddedPlatformDescription : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PromptPlatformDescription",
                table: "PromptPlatforms",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromptPlatformDescription",
                table: "PromptPlatforms");
        }
    }
}
