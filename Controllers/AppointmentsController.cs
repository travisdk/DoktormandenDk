using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoktormandenDk.Models;
using DoktormandenDk.BusinessLayer;
using DoktormandenDk.Controllers.ActionFilters;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DoktormandenDk.Controllers
{

    public class AppointmentsController : Controller
    {
        public readonly IUser LoggedInUser;
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        private readonly IAppointmentsService _appointmentService;

        public AppointmentsController(AppDbContext context, IUserService userService, IAppointmentsService appointmentService)
        {
            _context = context;
            _userService = userService;
            _appointmentService = appointmentService;
            LoggedInUser = _userService.CurrentUser;
        }

        [TestValidAppointmentUser]
        public async Task<IActionResult> Index()
        {
            List<Appointment> appointments = null;
            if (_userService.IsPatient)
            {
                appointments = await _appointmentService.GetAllForPatient(LoggedInUser.UserName);
            }
            else if (_userService.IsGP)
            {
                appointments = await _appointmentService.GetAllForGP(LoggedInUser.UserName);
            }
            return View(appointments);
        }


        [TestValidAppointmentUser]
        public async Task<IActionResult> Details(int? id)
        {
            List<Appointment> appointments = null;
            if (_userService.IsPatient)
            {
                appointments = await _appointmentService.GetAllForPatient(LoggedInUser.UserName);
            }
            else if (_userService.IsGP)
            {
                appointments = await _appointmentService.GetAllForGP(LoggedInUser.UserName);
            }

            if (id == null || appointments == null)
            {
                return NotFound();
            }
            // we already have all the appointments for this user
            var appointment = appointments.FirstOrDefault(ap => ap.AppointmentId == id);    

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }


        [TestValidAppointmentUser]
        public async Task<IActionResult> Create()
        {
            var GPs = await _appointmentService.GetAllGPs();
            var Patients = await _appointmentService.GetAllPatients();

            if (_userService.IsGP)
            {
                var userAsGP = (GP)LoggedInUser;
                ViewData["Patients"] = new SelectList(Patients, "PatientId", "Name");
                var appointment = new Appointment
                {
                    GP = userAsGP,
                    GPId = userAsGP.GPId,
                };

                ViewData["AvailableTimes"] = new List<SelectListItem>();
                return View("CreateForGP", appointment);

            }
            else if (_userService.IsPatient)
            {
                var userAsPatient = (Patient)LoggedInUser;

                ViewData["GPs"] = new SelectList(GPs, "GPId", "Name");

                var appointment = new Appointment
                {
                    Patient = userAsPatient,
                    PatientId = userAsPatient.PatientId,

                };

                ViewData["AvailableTimes"] = new List<SelectListItem>();
                return View("CreateForPatient", appointment);
                
            }
            // just to be safe - "unregistered" users is not able to come here at all
            return NotFound();
        }


        [TestValidAppointmentUser]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForPatient(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                await _appointmentService.AddAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }
           
           return View(appointment);
          
        }


        [TestValidAppointmentUser]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateForGP(Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                await _appointmentService.AddAppointment(appointment);
                return RedirectToAction(nameof(Index));
            }

            return View(appointment);
        }

        [HttpGet] // Called by jQuery to refresh lists with avail. times
        public async Task<IActionResult> GetAvailableTimes(int gpId, int patientId)
        {
            if (patientId == null || gpId == null)
            {
                return NotFound();
            }
            else
            {
                // Valid Patient and GP
                var times = await _appointmentService.GetAvailableTimes(gpId, patientId);
                return Json(times);
            }
        }

        [TestValidAppointmentUser]
        public async Task<IActionResult> Delete(int? id)
        {
            var appointments = await _appointmentService.GetAllAppointments();
            if (id == null || appointments == null)
            {
                return NotFound();
            }

            var appointment = await _appointmentService.GetAppointmentFromId(id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
 
        [TestValidAppointmentUser]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _appointmentService.CancelAppointmentById(id);
            return RedirectToAction(nameof(Index));
        }


        public IActionResult Forbidden()
        {
            return View();
        }

    }
}
