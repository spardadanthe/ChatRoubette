using Microsoft.EntityFrameworkCore.Migrations;

namespace Chatman.Api.Migrations
{
    public partial class s : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SecondUserId",
                table: "Friendships",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstUserId",
                table: "Friendships",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_FirstUserId",
                table: "Friendships",
                column: "FirstUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friendships_SecondUserId",
                table: "Friendships",
                column: "SecondUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_FirstUserId",
                table: "Friendships",
                column: "FirstUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Friendships_Users_SecondUserId",
                table: "Friendships",
                column: "SecondUserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_FirstUserId",
                table: "Friendships");

            migrationBuilder.DropForeignKey(
                name: "FK_Friendships_Users_SecondUserId",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_FirstUserId",
                table: "Friendships");

            migrationBuilder.DropIndex(
                name: "IX_Friendships_SecondUserId",
                table: "Friendships");

            migrationBuilder.AlterColumn<string>(
                name: "SecondUserId",
                table: "Friendships",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstUserId",
                table: "Friendships",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
