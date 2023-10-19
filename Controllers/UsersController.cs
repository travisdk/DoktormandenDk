
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoktormandenDk.BusinessLayer;
using DoktormandenDk.Models;

namespace DoktormandenDk.Controllers
{
    public class UserProfileSelectorModel
    {
        public IEnumerable<User> UserList { get; set; }
        public int? SelectedId { get; set; }
    }

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
            UserProfileSelectorModel selector = new UserProfileSelectorModel
            {
                UserList = await _context.Users.ToListAsync(),
                SelectedId = 0,
            };
            return View(selector);
        }
        
        [HttpPost] 
        public async Task<IActionResult> SetUser(UserProfileSelectorModel  userProfileSelectorModel)
        {
                if (userProfileSelectorModel.SelectedId == null)
                {
                    return NotFound();
                }
                User newCurrentUser = await _context.Users.FindAsync(userProfileSelectorModel.SelectedId);

                if (newCurrentUser == null)
                {
                    return NotFound();
                }

                _userService.SetCurrentUser(newCurrentUser); // Current profile changed
                return RedirectToAction("UserChanged");

        }

        [HttpGet] 
        public IActionResult UserChanged()
        {
            return View();
        }
       
    }
}
