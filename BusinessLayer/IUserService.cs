using DoktormandenDk.Models;

namespace DoktormandenDk.BusinessLayer
{
    public interface IUserService
    {
        public IUser CurrentUser { get; set; }

        public List<IUser> GetDemoUsers();

        public bool IsGP { get; }
        public bool IsPatient { get; }

    }
}
