using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Infrastructure.Migrations
{
    public partial class Add_File : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: false),
                    CreatedBy = table.Column<string>(nullable: true),
                    UpdatedDateTime = table.Column<DateTimeOffset>(nullable: false),
                    UpdatedBy = table.Column<string>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    DeletedBy = table.Column<string>(nullable: true),
                    FileName = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");
        }
    }
}
