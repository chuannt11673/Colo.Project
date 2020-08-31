using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class AddUserLikes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserLikes",
                columns: table => new
                {
                    SenderId = table.Column<Guid>(nullable: false),
                    ReceiverId = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikes", x => new { x.SenderId, x.ReceiverId });
                    table.ForeignKey(
                        name: "FK_UserLikes_Users_ReceiverId",
                        column: x => x.ReceiverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserLikes_Users_SenderId",
                        column: x => x.SenderId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_ReceiverId",
                table: "UserLikes",
                column: "ReceiverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserLikes");
        }
    }
}
