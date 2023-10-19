
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
        private readonly UserService _userService;
        public UsersController(AppDbContext context, UserService userService)
        {
            _context = context;
            _userService = userService;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Users.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult> SetUser(int id)
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
            return View(newCurrentUser);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SetUser([Bind("Name, Id, Role")] User user)
        {
            if (user == null)
            {
                return NotFound();
            }
            _userService.SetCurrentUser(user); // Current profile changed
            return RedirectToAction("UserChanged");

        }
       
        public IActionResult UserChanged()
        {
            return View();
        }
    }
}
