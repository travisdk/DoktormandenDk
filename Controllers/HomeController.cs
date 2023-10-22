using DoktormandenDk.Controllers.ActionFilters;
using DoktormandenDk.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace DoktormandenDk.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context; 

        public HomeController(AppDbContext dbContext)
        {
            _context = dbContext;

            //foreach (var patient in _context.Patients.Include(p => p.Appointments))
            //{

            //    System.Diagnostics.Debug.WriteLine(patient.Name);
            //    foreach (var ap in patient.Appointments)
            //    {
            //        System.Diagnostics.Debug.WriteLine($"SUBJECT: {ap.Subject}");
            //    }
            //}

            //foreach (var gp in _context.GPs)
            //{

            //    System.Diagnostics.Debug.WriteLine(gp.Name);
            //}
            //foreach (var appointment in _context.Appointments)
            //{
            //    System.Diagnostics.Debug.WriteLine(appointment.Patient.Name + " " + appointment.GP.Name);
            //}
     
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}