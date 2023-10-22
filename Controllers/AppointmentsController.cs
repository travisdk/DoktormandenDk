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

namespace DoktormandenDk.Controllers
{

    public class AppointmentsController : Controller
    {
        public readonly IUser LoggedInUser;
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        private readonly IAppointmentsService _appointmentService;

        public AppointmentsController(IUserService userService, IAppointmentsService appointmentService)
        {
            _userService = userService;
            _appointmentService = appointmentService;
            LoggedInUser = _userService.CurrentUser;

        }

        // GET: Appointments
        [TestValidAppointmentUser]
        public async Task<IActionResult> Index()
        {
            List<Appointment> appointments = null;
            if (_userService.IsPatient)
            {
                appointments = await _appointmentService.GetAllForPatientAsync(LoggedInUser.UserName);
            }
            else if (_userService.IsGP)
            {
                appointments = await _appointmentService.GetAllForGPAsync(LoggedInUser.UserName);
            }
            return View(appointments);
        }

        // GET: Appointments/Details/5
        [TestValidAppointmentUser]

        public async Task<IActionResult> Details(int? id)
        {
            List<Appointment> appointments = null;
            if (_userService.IsPatient)
            {
                appointments = await _appointmentService.GetAllForPatientAsync(LoggedInUser.UserName);
            }
            else if (_userService.IsGP)
            {
                appointments = await _appointmentService.GetAllForGPAsync(LoggedInUser.UserName);
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

        // GET: Appointments/Create
        [TestValidAppointmentUser]
        public async Task<IActionResult> Create()
        {

            var GPs = await _appointmentService.GetAllGPsAsync();
            var Patients = await _appointmentService.GetAllPatientsAsync();
            

            if (_userService.IsGP)
            {
                var userAsGP = (GP)LoggedInUser;
                var availTimes = new SelectList(await _appointmentService.GetAvailableTimesAsync(userAsGP));
                
                // his/her own available times
                ViewData["PatientId"] = new SelectList(Patients, "PatientId", "Name");
                var appointment = new Appointment
                {
                    GP = userAsGP
                };
                return View("CreateForGP", appointment );
            }

            else if (_userService.IsPatient)
            {
                var userAsPatient =   (Patient)LoggedInUser;
                var availTimes = await _appointmentService.GetAvailableTimesAsync(GPs[0]);
                // prefetch for first possible GP and convert to SelectList for the view
                ViewData["AvailableTimes"] = availTimes.Select(item => new SelectListItem
                {
                    Value = item.ToString(),
                    Text  = item.ToString()
                });
                ViewData["GPId"] = new SelectList(GPs, "GPId", "Name");
                var appointment = new Appointment
                {
                    Patient = userAsPatient
                };
                return View("CreateForPatient", appointment);
            }


            // just to be safe - "unregistered" users is not able to come here at all
            return NotFound();
        }

        // POST: Appointments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [TestValidAppointmentUser]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentId,PatientId,GPId,AppointmentTime,Subject")] Appointment appointment)
        {
           
            if (ModelState.IsValid)
            {
                _context.Add(appointment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GPId"] = new SelectList(_context.GPs, "GPId", "License", appointment.GPId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Name", appointment.PatientId);
            return View(appointment);
        }

       

        [TestValidAppointmentUser]
        // GET: Appointments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
        

            if (id == null || _context.Appointments == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointments
                .Include(a => a.GP)
                .Include(a => a.Patient)
                .FirstOrDefaultAsync(m => m.AppointmentId == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }
 
        // POST: Appointments/Delete/5
        [TestValidAppointmentUser]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
           

            if (_context.Appointments == null)
            {
                return Problem("Entity set 'AppDbContext.Appointments'  is null.");
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        public IActionResult Forbidden()
        {
            return View();
        }

        private bool AppointmentExists(int id)
        {
          return (_context.Appointments?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
    }
}
