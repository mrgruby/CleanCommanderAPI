using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanCommander.Persistence.Migrations
{
    public partial class ChangedPlatformsToPromptPlatforms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandLines_Platforms_PlatformId",
                table: "CommandLines");

            migrationBuilder.DropTable(
                name: "Platforms");

            migrationBuilder.RenameColumn(
                name: "PlatformName",
                table: "CommandLines",
                newName: "PromptPlatformName");

            migrationBuilder.RenameColumn(
                name: "PlatformId",
                table: "CommandLines",
                newName: "PromptPlatformId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CommandLines",
                newName: "CommandLineId");

            migrationBuilder.RenameIndex(
                name: "IX_CommandLines_PlatformId",
                table: "CommandLines",
                newName: "IX_CommandLines_PromptPlatformId");

            migrationBuilder.CreateTable(
                name: "PromptPlatforms",
                columns: table => new
                {
                    PromptPlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PromptPlatformName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptPlatforms", x => x.PromptPlatformId);
                });

            migrationBuilder.InsertData(
                table: "PromptPlatforms",
                columns: new[] { "PromptPlatformId", "PromptPlatformName" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Angular CLI" });

            migrationBuilder.InsertData(
                table: "PromptPlatforms",
                columns: new[] { "PromptPlatformId", "PromptPlatformName" },
                values: new object[] { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Entity Framework" });

            migrationBuilder.InsertData(
                table: "PromptPlatforms",
                columns: new[] { "PromptPlatformId", "PromptPlatformName" },
                values: new object[] { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Git commands" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommandLines_PromptPlatforms_PromptPlatformId",
                table: "CommandLines",
                column: "PromptPlatformId",
                principalTable: "PromptPlatforms",
                principalColumn: "PromptPlatformId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CommandLines_PromptPlatforms_PromptPlatformId",
                table: "CommandLines");

            migrationBuilder.DropTable(
                name: "PromptPlatforms");

            migrationBuilder.RenameColumn(
                name: "PromptPlatformName",
                table: "CommandLines",
                newName: "PlatformName");

            migrationBuilder.RenameColumn(
                name: "PromptPlatformId",
                table: "CommandLines",
                newName: "PlatformId");

            migrationBuilder.RenameColumn(
                name: "CommandLineId",
                table: "CommandLines",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_CommandLines_PromptPlatformId",
                table: "CommandLines",
                newName: "IX_CommandLines_PlatformId");

            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "PlatformName" },
                values: new object[] { new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Angular CLI" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "PlatformName" },
                values: new object[] { new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Entity Framework" });

            migrationBuilder.InsertData(
                table: "Platforms",
                columns: new[] { "PlatformId", "PlatformName" },
                values: new object[] { new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Git commands" });

            migrationBuilder.AddForeignKey(
                name: "FK_CommandLines_Platforms_PlatformId",
                table: "CommandLines",
                column: "PlatformId",
                principalTable: "Platforms",
                principalColumn: "PlatformId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
