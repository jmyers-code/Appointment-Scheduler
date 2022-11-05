using AppointmentManagementSystem.Models;
using AppointmentManagementSystem.Models.AppDbConext;
using AppointmentManagementSystem.Models.ViewModels;
using AppointmentManagementSystem.Services.Interface;
using AppointmentManagementSystem.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagementSystem.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAppointment(AppointmentViewModel model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));

            Appointment appointment = new()
            {
                Title = model.Title,
                Description = model.Description,
                StartDate = startDate,
                EndDate = endDate,
                Duration = model.Duration,
                NurseId = model.NurseId,
                PatientId = model.PatientId,
                IsNurseApproved = false,
                AdminId = model.AdminId
            };

            await _context.Appointments.AddAsync(appointment);
            await _context.SaveChangesAsync();
            return 2;
        }

        public async Task<int> AddUpdate(AppointmentViewModel model)
        {
            var startDate = DateTime.Parse(model.StartDate);
            var endDate = DateTime.Parse(model.StartDate).AddMinutes(Convert.ToDouble(model.Duration));

            if (model != null && model.Id > 0)
            {
                //Update Appointment
                return 1;
            }
            else
            {
                //Create Appointment
                Appointment appoinment = new Appointment()
                {
                    Title = model.Title,
                    Description = model.Description,
                    StartDate = startDate,
                    EndDate = endDate,
                    Duration = model.Duration,
                    NurseId = model.NurseId,
                    PatientId = model.PatientId,
                    IsNurseApproved = false,
                    AdminId = model.AdminId
                };

                await _context.Appointments.AddAsync(appoinment);
                await _context.SaveChangesAsync();
                return 2;
            }
        }

        public async Task<int> ConfirmEvent(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if(appointment != null)
            {
                appointment.IsNurseApproved = true;
                return await _context.SaveChangesAsync();
            }
            return 0;
        }
        public async Task<int> Delete(int id)
        {
            var appointment = _context.Appointments.FirstOrDefault(x => x.Id == id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
                return await _context.SaveChangesAsync();
            }
            return 0;
        }

        public AppointmentViewModel GetById(int id)
        {
            return _context.Appointments.Where(n => n.Id == id).ToList().Select(d => new AppointmentViewModel()
            {
                Id = d.Id,
                Description = d.Description,
                StartDate = d.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = d.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = d.Title,
                Duration = d.Duration,
                IsNurseApproved = d.IsNurseApproved,
                PatientId = d.PatientId,
                NurseId = d.NurseId,
                PatientName = _context.Users.Where(x => x.Id == d.PatientId).Select(x => x.Name).FirstOrDefault(),
                NurseName = _context.Users.Where(x => x.Id == d.NurseId).Select(x => x.Name).FirstOrDefault()
            }).SingleOrDefault();
        }

        public List<NurseViewModel> GetNurseList()
        {
            var nurses = (from user in _context.Users
                          join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                          join roles in _context.Roles.Where(n => n.Name == Helper.Nurse) on userRoles.RoleId equals roles.Id
                          select new NurseViewModel
                          {
                              Id = user.Id,
                              Name = user.Name
                          }).ToList();

            return nurses;
        }

        public List<PatientViewModel> GetPatientList()
        {
            var patients = (from user in _context.Users
                            join userRoles in _context.UserRoles on user.Id equals userRoles.UserId
                            join roles in _context.Roles.Where(n => n.Name == Helper.Patient) on userRoles.RoleId equals roles.Id
                            select new PatientViewModel
                            {
                                Id = user.Id,
                                Name = user.Name
                            }).ToList();

            return patients;
        }

        public List<AppointmentViewModel> NursesEventById(string nurseId)
        {
            return _context.Appointments.Where(n => n.NurseId == nurseId).ToList().Select(d => new AppointmentViewModel()
            {
                Id = d.Id,
                Description = d.Description,
                StartDate = d.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = d.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = d.Title,
                Duration = d.Duration,
                IsNurseApproved = d.IsNurseApproved
            }).ToList();
        }

        public List<AppointmentViewModel> PatientsEventById(string patientId)
        {
            return _context.Appointments.Where(n => n.PatientId == patientId).ToList().Select(d => new AppointmentViewModel()
            {
                Id = d.Id,
                Description = d.Description,
                StartDate = d.StartDate.ToString("yyyy-MM-dd HH:mm:ss"),
                EndDate = d.EndDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Title = d.Title,
                Duration = d.Duration,
                IsNurseApproved = d.IsNurseApproved
            }).ToList();
        }
    }
}
