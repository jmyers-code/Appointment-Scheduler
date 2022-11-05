using Microsoft.EntityFrameworkCore.Migrations;

namespace AppointmentManagementSystem.Migrations
{
    public partial class UpdateAppointmentInDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsDoctorApproved",
                table: "Appointments",
                newName: "IsNurseApproved");

            migrationBuilder.RenameColumn(
                name: "DoctorId",
                table: "Appointments",
                newName: "NurseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NurseId",
                table: "Appointments",
                newName: "DoctorId");

            migrationBuilder.RenameColumn(
                name: "IsNurseApproved",
                table: "Appointments",
                newName: "IsDoctorApproved");
        }
    }
}
