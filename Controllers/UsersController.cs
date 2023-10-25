
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoktormandenDk.BusinessLayer;
using DoktormandenDk.Models;
using DoktormandenDk.Models.ViewModels;

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
            return View(new UserVM { DemoUsers = _demoUsers, CurrentUser = _userService.CurrentUser });
        }

        [HttpPost]
        public  IActionResult SetUser(string username)
        {
            if (username == null)
            {
                return RedirectToAction("Index");
            }
            IUser newCurrentUser = _demoUsers.Find(u => u.UserName == username);
            if (newCurrentUser == null)
            {
                return RedirectToAction("Index");
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
