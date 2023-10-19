using Microsoft.EntityFrameworkCore;
using DoktormandenDk.Models;

namespace DoktormandenDk.BusinessLayer
{

    public class UserService 
    {
        private readonly AppDbContext _context;
        private User _currentUser;

        public void SetCurrentUser(User currentUser) {
            _currentUser = currentUser;
        }
        public UserService(AppDbContext context) {
            _context = context;
            if (_currentUser == null)
            {
                var allUsers = context.Users.ToList();
                // hardcoded to "Patient" on App Start (default profile)
                _currentUser = allUsers[allUsers.Count - 1]; // the last in the user table = Patient role
            }
        }
    }
}
