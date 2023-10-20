
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

        [HttpPost]
        public async Task<IActionResult> SetUser(int? id )
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
            return Json(new { redirectToUrl = Url.Action("UserChanged", "Users") });
            // JS makes the redirect in the ajax success callback
        }


        [HttpGet]
        public ActionResult UserChanged()
        {
            return View();
        }
     
    }
}
