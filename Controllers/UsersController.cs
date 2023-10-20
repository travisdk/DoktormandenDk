
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoktormandenDk.BusinessLayer;
using DoktormandenDk.Models;


namespace DoktormandenDk.Controllers
{
    public class UsersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IUserService _userService;
        public UsersController(AppDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<User> users = await _context.Users.ToListAsync();
            
            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> SetUser(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            User newCurrentUser = await _context.Users.FindAsync(id);
            if (newCurrentUser == null)
            {
                return NotFound();
            }
            _userService.SetCurrentUser(newCurrentUser); // Current profile changed
            return RedirectToAction("UserChanged");
        }

        [HttpGet]
        public ActionResult UserChanged()
        {
            return View();
        }
     
    }
}
