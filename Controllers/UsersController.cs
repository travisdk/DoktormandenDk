
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
        private List<IUser> _demoUsers;
        public UsersController(IUserService userService)
        {
            _userService = userService;
            _demoUsers = _userService.GetDemoUsers();
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
   
            return View(_demoUsers);
        }

        [HttpPost]
        public  IActionResult SetUser(string username)
        {
            if (username == null)
            {
                return NotFound();
            }
            IUser newCurrentUser = _demoUsers.Find(u => u.UserName == username);
            if (newCurrentUser == null)
            {
                return NotFound();
            }
            _userService.CurrentUser = newCurrentUser; // Current profile changed
            return RedirectToAction("UserChanged");
        }

        [HttpGet]
        public ActionResult UserChanged()
        {
            return View();
        }
     
    }
}
