using Microsoft.EntityFrameworkCore;
using DoktormandenDk.Models;
using Microsoft.Extensions.DependencyInjection;


namespace DoktormandenDk.BusinessLayer
{

    public class UserService : IUserService
    {
        private List<IUser> _demoUsers;
        private readonly IServiceScopeFactory _scopeFactory;

        public IUser? CurrentUser { get; set; } = null; // NO 'logged in' user default
        
        public List<IUser> GetDemoUsers()
        {
            return _demoUsers;
        }

        // Is current user a GP
        public bool IsGP 
        { 
            get
            {
                if (CurrentUser == null) return false;
                return CurrentUser.GetType() == typeof(GP);
            }
        }
        // Is current user a Patient
        public bool IsPatient
        {
            get
            {
                if (CurrentUser == null) return false;
                return CurrentUser.GetType() == typeof(Patient);

            }
        }
        public UserService(IServiceScopeFactory serviceScopeFactory)
        {
       
            // In order to get DEMO user data from scoped dbContext => singleton UserService
            // NOT FOR PRODUCTION USE!

            _scopeFactory = serviceScopeFactory;
            SetupService();

        }
        public  void SetupService()
        {
            // only runs once - when app is started..
            using (var scope = _scopeFactory.CreateScope())
            {
                var appDbContext = scope.ServiceProvider.GetService<AppDbContext>();
                var patients =  appDbContext.Patients.Include(p => p.Appointments).Include(p => p.EConsultations).ToList();
                var generalpractitioners = appDbContext.GPs.Include(p => p.Appointments).Include(p => p.EConsultations).ToList();
                _demoUsers = new List<IUser>();
                _demoUsers.AddRange(patients);
                _demoUsers.AddRange(generalpractitioners);

            }
        }

    }
}