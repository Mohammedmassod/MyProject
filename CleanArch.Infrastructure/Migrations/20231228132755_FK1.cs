using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Infrastructure.Migrations
{
    public partial class FK1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserGroupId",
                table: "UserGroups",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserGroups",
                newName: "UserGroupId");
        }
    }
}
