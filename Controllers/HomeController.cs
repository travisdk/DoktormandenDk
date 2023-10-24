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