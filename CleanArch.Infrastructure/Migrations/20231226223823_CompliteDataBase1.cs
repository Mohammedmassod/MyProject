using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyProject.Infrastructure.Migrations
{
    public partial class CompliteDataBase1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhonexNumber",
                table: "Users",
                newName: "PhoneNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "Users",
                newName: "PhonexNumber");
        }
    }
}
