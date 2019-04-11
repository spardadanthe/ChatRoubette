using Microsoft.EntityFrameworkCore.Migrations;

namespace Chatman.Api.Migrations
{
    public partial class sopl : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConversationBlockedUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    ConversationId = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConversationBlockedUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConversationBlockedUsers_Conversations_ConversationId",
                        column: x => x.ConversationId,
                        principalTable: "Conversations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConversationBlockedUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConversationBlockedUsers_ConversationId",
                table: "ConversationBlockedUsers",
                column: "ConversationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConversationBlockedUsers_UserId",
                table: "ConversationBlockedUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConversationBlockedUsers");
        }
    }
}
