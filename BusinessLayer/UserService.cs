using Microsoft.EntityFrameworkCore;
using DoktormandenDk.Models;
using Microsoft.Extensions.DependencyInjection;


namespace DoktormandenDk.BusinessLayer
{

    public class UserService : IUserService
    {
        private List<IUser> _demoUsers;
        private readonly IServiceScopeFactory _scopeFactory;
        private IUser _currentUser;

        public void SetCurrentUser(IUser currentUser)
        {
            _currentUser = currentUser;
        }
        public List<IUser> GetDemoUsers()
        {
            return _demoUsers;
        }
        public IUser GetCurrentUser()
        {
            return _currentUser;
        }
        public UserService(IServiceScopeFactory serviceScopeFactory)
        {
       
            // In order to get DEMO user data from scoped dbContext => singleton UserService
            // NOT FOR PRODUCTION USE!

            _scopeFactory = serviceScopeFactory;
            
            Execute();
        }
        public void Execute()
        {
            // only runs once - when app is started..
            using (var scope = _scopeFactory.CreateScope())
            {
                var appDbContext = scope.ServiceProvider.GetService<AppDbContext>();
                var patients = appDbContext.Patients.ToList();
                var generalpractitioners = appDbContext.GPs.ToList();
                _demoUsers = new List<IUser>();
                _demoUsers.AddRange(patients);
                _demoUsers.AddRange(generalpractitioners);

            }
        }
    }
}