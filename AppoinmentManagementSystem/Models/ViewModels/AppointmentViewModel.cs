using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagementSystem.Models.ViewModels
{
    public class AppointmentViewModel
    {
        public int? Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Duration { get; set; }
        public string NurseId { get; set; }
        public string PatientId { get; set; }
        public bool IsNurseApproved { get; set; }
        public string AdminId { get; set; }

        public string NurseName { get; set; }
        public string PatientName { get; set; }
        public string AdminName { get; set; }
        public bool IsForClient { get; set; }
    }
}
