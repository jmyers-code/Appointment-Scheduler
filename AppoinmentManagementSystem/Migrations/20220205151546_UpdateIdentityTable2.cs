using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentManagementSystem.Migrations
{
    public partial class UpdateIdentityTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserLogin",
                table: "AspNetUsers",
                newName: "LoginCode");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LoginCode",
                table: "AspNetUsers",
                newName: "UserLogin");
        }
    }
}
