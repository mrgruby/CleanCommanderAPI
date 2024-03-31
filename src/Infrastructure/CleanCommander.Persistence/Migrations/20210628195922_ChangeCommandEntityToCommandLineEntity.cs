using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanCommander.Persistence.Migrations
{
    public partial class ChangeCommandEntityToCommandLineEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commands_Platforms_PlatformId",
                table: "Commands");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commands",
                table: "Commands");

            migrationBuilder.RenameTable(
                name: "Commands",
                newName: "CommandLines");

            migrationBuilder.RenameIndex(
                name: "IX_Commands_PlatformId",
                table: "CommandLines",
                newName: "IX_CommandLines_PlatformId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CommandLines",
                table: "CommandLines",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CommandLines_Platforms_PlatformId",
                table: "CommandLines",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandLines_Platforms_PlatformId",
                table: "CommandLines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CommandLines",
                table: "CommandLines");

            migrationBuilder.RenameTable(
                name: "CommandLines",
                newName: "Commands");

            migrationBuilder.RenameIndex(
                name: "IX_CommandLines_PlatformId",
                table: "Commands",
                newName: "IX_Commands_PlatformId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commands",
                table: "Commands",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commands_Platforms_PlatformId",
                table: "Commands",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
