using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;

namespace DoktormandenDk.BusinessLayer
{
    public class AppointmentService : IAppointmentsService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Appointment>> GetAllForUsernameAsync(string userName)
        {
            {
                var appointments = await _context.Appointments.Where(a => a.Patient.UserName ==  userName)
                    .Include(a => a.GP)
                    .Include(a => a.Patient).ToListAsync();

                return appointments;
            }
        }
        // TODO: Another place for this???
        public async Task<List<GP>> GetAllGPsAsync()
        {
            return await _context.GPs.ToListAsync();
        }

        public async Task<List<Patient>> GetAllPatientsAsync()
        {
            return await _context.Patients.ToListAsync();
        }

        // For at given GP find all available times for Appointment.
        // Max 1 month into the feature for demo purpose.
        // We allow for times in 30minutes intervals, from 9:00 to 16:00,
        // every working day.
        public async Task<List<DateTime>> GetAvailableTimes(GP gp)
        {
           List<DateTime> availableTimes = new List<DateTime>();
            DateTime from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 8, 30, 0);
            
            // earliest:9:00 next day 
           DateTime currentDate = from;
           
           while (currentDate < from + TimeSpan.FromDays(30)) {

                if (currentDate.Hour == 16) currentDate += TimeSpan.FromHours(16.5); // => 9:00
                if (currentDate.DayOfWeek == DayOfWeek.Saturday) {
                    currentDate.AddDays(2); // => Monday
                }
                currentDate = currentDate + TimeSpan.FromMinutes(30);

                // TODO: Check if already booked!!
                availableTimes.Add(currentDate);
           
            }

            return availableTimes;
        }
    }
}
