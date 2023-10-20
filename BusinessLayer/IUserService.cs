using DoktormandenDk.Models;

namespace DoktormandenDk.BusinessLayer
{
    public interface IUserService
    {
        public void SetCurrentUser(User currentUser);
        public User GetCurrentUser();   
    }
}
