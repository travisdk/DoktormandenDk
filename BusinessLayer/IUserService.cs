using DoktormandenDk.Models;

namespace DoktormandenDk.BusinessLayer
{
    public interface IUserService
    {
        public void SetCurrentUser(IUser currentUser);
        public IUser GetCurrentUser();

        public List<IUser> GetDemoUsers();
    }
}
