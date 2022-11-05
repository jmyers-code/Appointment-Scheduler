using AppointmentManagementSystem.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagementSystem.Services.Interface
{
    public interface IAppointmentService
    {
        public List<NurseViewModel> GetNurseList();
        public List<PatientViewModel> GetPatientList();
        public Task<int> AddUpdate(AppointmentViewModel model);
        public Task<int> AddAppointment(AppointmentViewModel model);
        public List<AppointmentViewModel> NursesEventById(string nurseId);
        public List<AppointmentViewModel> PatientsEventById(string patientId);
        public AppointmentViewModel GetById(int id);
        public Task<int> Delete(int id);
        public Task<int> ConfirmEvent(int id);
    }
}
