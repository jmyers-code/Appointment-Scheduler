using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentManagementSystem.Migrations
{
    public partial class UpdateIdentityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AspNetUsers",
                newName: "UserLogin");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserLogin",
                table: "AspNetUsers",
                newName: "UserId");
        }
    }
}
