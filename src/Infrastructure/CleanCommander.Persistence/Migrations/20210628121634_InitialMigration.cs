using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CleanCommander.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Platforms",
                columns: table => new
                {
                    PlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platforms", x => x.PlatformId);
                });

            migrationBuilder.CreateTable(
                name: "Commands",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HowTo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Line = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commands", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commands_Platforms_PlatformId",
                        column: x => x.PlatformId,
                        principalTable: "Platforms",
                        principalColumn: "PlatformId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Commands",
                columns: new[] { "Id", "Comment", "HowTo", "Line", "PlatformId", "PlatformName" },
                values: new object[,]
                {
                    { new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), "This is a comment", "Generate new module", "This is the command", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Angular CLI" },
                    { new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), "This is a comment", "Generate new component", "This is the command", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Angular CLI" },
                    { new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"), "This is a comment", "Generate new Service", "This is the command", new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"), "Angular CLI" },
                    { new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"), "This is a comment", "Add new migratation", "This is the command", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Entity Framework" },
                    { new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), "This is a comment", "Update database", "This is the command", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Entity Framework" },
                    { new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), "This is a comment", "Update packages", "This is the command", new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"), "Entity Framework" },
                    { new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"), "This is a comment", "Push code", "This is the command", new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Git commands" },
                    { new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"), "This is a comment", "Change branch", "This is the command", new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Git commands" },
                    { new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"), "This is a comment", "Add new repository", "This is the command", new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"), "Git commands" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commands_PlatformId",
                table: "Commands",
                column: "PlatformId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commands");

            migrationBuilder.DropTable(
                name: "Platforms");
        }
    }
}
