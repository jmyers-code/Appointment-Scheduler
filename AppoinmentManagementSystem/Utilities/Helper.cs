using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagementSystem.Utilities
{
    public static class Helper
    {
        public static string Admin = "Admin";
        public static string Nurse = "Nurse";
        public static string Patient = "Patient";

        public static string appointmentAdded = "Appointment added successfully.";
        public static string appointmentConfirmed = "Appointment confirmed successfully.";
        public static string appointmentUpdated = "Appointment updated successfully.";
        public static string appointmentDeleted = "Appointment deleted successfully.";
        public static string appointmentExist = "Appointment for selected date and time already exists.";
        public static string appointmentNotExist = "Appointment does not exist";

        public static string appointmentAddError = "Something went wrong. Please try again.";
        public static string appointmentConfirmError = "Something went wrong confirming appointment. Please try again.";
        public static string appointmentUpdateError = "Something went wrong. Please try again.";
        public static string somethingWentWrong = "Something went wrong. Please try again.";

        public static int success_code = 1;
        public static int failure_code = 0;

        public static List<SelectListItem> GetRolesForDropDown(bool isAdmin)
        {
            if (isAdmin)
            {
                return new List<SelectListItem>
              {
                new SelectListItem{Value = Admin, Text = Admin}
              };
            }
            else
            {
                return new List<SelectListItem>
              {
                new SelectListItem{Value = Nurse, Text = Nurse},
                new SelectListItem{Value = Patient, Text = Patient}
              };
            }
        }

        public static List<SelectListItem> GetTimeDropDown()
        {
            int minute = 60;
            List<SelectListItem> duration = new List<SelectListItem>();

            for (int i = 1; i <= 12; i++)
            {
                duration.Add(new SelectListItem { Value = minute.ToString(), Text = i + " Hr" });
                minute = minute + 30;
            }

            return duration;
        }
    }
}
