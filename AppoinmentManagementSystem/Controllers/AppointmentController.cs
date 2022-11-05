using AppointmentManagementSystem.Services.Interface;
using AppointmentManagementSystem.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentManagementSystem.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        public IActionResult Index()
        {
            ViewBag.Duration = Helper.GetTimeDropDown();
            ViewBag.PatientList = _appointmentService.GetPatientList();
            ViewBag.NurseList = _appointmentService.GetNurseList();
            return View();
        }
    }
}
