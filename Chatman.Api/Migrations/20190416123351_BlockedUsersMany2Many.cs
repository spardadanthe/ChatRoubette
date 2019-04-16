using Microsoft.EntityFrameworkCore.Migrations;

namespace Chatman.Api.Migrations
{
    public partial class BlockedUsersMany2Many : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationBlockedUsers_Conversations_ConversationId",
                table: "ConversationBlockedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationBlockedUsers_Users_UserId",
                table: "ConversationBlockedUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationBlockedUsers_Conversations_ConversationId",
                table: "ConversationBlockedUsers",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationBlockedUsers_Users_UserId",
                table: "ConversationBlockedUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConversationBlockedUsers_Conversations_ConversationId",
                table: "ConversationBlockedUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_ConversationBlockedUsers_Users_UserId",
                table: "ConversationBlockedUsers");

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationBlockedUsers_Conversations_ConversationId",
                table: "ConversationBlockedUsers",
                column: "ConversationId",
                principalTable: "Conversations",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_ConversationBlockedUsers_Users_UserId",
                table: "ConversationBlockedUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
