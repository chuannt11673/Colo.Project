using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Add_Fluster_ChatEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chats_FromUserId",
                table: "Chats");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FromUserId_ToUserId",
                table: "Chats",
                columns: new[] { "FromUserId", "ToUserId" })
                .Annotation("SqlServer:Clustered", false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Chats_FromUserId_ToUserId",
                table: "Chats");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FromUserId",
                table: "Chats",
                column: "FromUserId");
        }
    }
}
