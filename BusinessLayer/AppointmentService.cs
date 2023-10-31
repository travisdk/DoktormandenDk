using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;

namespace DoktormandenDk.BusinessLayer
{
    public class AppointmentService : IAppointmentsService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAppointment(Appointment appointment )
        {
            _context.Add(appointment);
            return await _context.SaveChangesAsync() > 0;
        }
        public async Task<Appointment?> GetAppointmentFromId(int? id)
        {
            return await _context.Appointments
                  .Include(e => e.GP)
                  .Include(e => e.Patient)
                  .FirstOrDefaultAsync(m => m.AppointmentId == id);
        }

        public async Task<bool> CancelAppointmentById(int id)
        {
            if (_context.Appointments == null)
            {
                throw (new Exception("Entity set 'Appointments'  is null."));
            }
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointments.Remove(appointment);
            }

            return await _context.SaveChangesAsync() > 0;

        }
        public bool AppointmentExists(int id)
        {
            return (_context.Appointments?.Any(e => e.AppointmentId == id)).GetValueOrDefault();
        }
        public async Task<List<Appointment>> GetAllForGP(string userName)
        {
            {
                var appointments = await _context.Appointments.Where(a => a.GP.UserName == userName)
                    .Include(a => a.Patient)
                    .Include(a => a.GP).ToListAsync();

                return appointments;
            }
        }

        public async Task<List<Appointment>> GetAllForPatient(string userName)
        {
            {
                var appointments = await _context.Appointments.Where(a => a.Patient.UserName == userName)
                    .Include(a => a.GP)
                    .Include(a => a.Patient).ToListAsync();

                return appointments;
            }
        }

        public async Task<List<GP>> GetAllGPs()
        {
            return await _context.GPs.Include(gp => gp.Appointments).ToListAsync();
        }
        public async Task<IEnumerable<Appointment>?> GetAllAppointments()
        {
            return await _context.Appointments.ToListAsync();
        }
        public async Task<List<Patient>> GetAllPatients()
        {
            return await _context.Patients.Include(p => p.Appointments).ToListAsync();
        }

        // For at given  Patient find all available times for Appointment.
        // Max 1 month into the feature for demo purpose.
        // We allow for times in 30minutes intervals, from 9:00 to 16:00,
        // every working day.
        // In this demo we only use GP with ID=1 !!

        public async Task<List<DateTime>> GetAvailableTimes(int gpId, int patientId)
        {
           GP gp = _context.GPs.Include(gp => gp.Appointments).First(gp => gp.GPId == gpId);
           Patient patient = _context.Patients.Include(p => p.Appointments).First(p => p.PatientId == 1);


           List<Appointment> alreadyTakenTimes = new List<Appointment>();
           alreadyTakenTimes.AddRange(gp.Appointments);
           alreadyTakenTimes.AddRange(patient.Appointments);
           List<DateTime> availableTimes = new List<DateTime>();
            

            // ORIGINAL WAS THIS: Breaks if date of month = 31
            //DateTime from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 8, 30, 0);           
            
            // CHANGED START
            DateTime tomorrow0_00 = DateTime.Today + TimeSpan.FromDays(1);
            DateTime from = new DateTime(tomorrow0_00.Year, tomorrow0_00.Month, tomorrow0_00.Day, 8, 30, 0);
            // CHANGED END


            // earliest:9:00 next day 
            DateTime currentDate = from;
           
            while (currentDate < from + TimeSpan.FromDays(30)) {

                if (currentDate.Hour == 16) currentDate += TimeSpan.FromHours(16.5); // => 9:00
                if (currentDate.DayOfWeek == DayOfWeek.Saturday) {
                    currentDate = currentDate + TimeSpan.FromDays(2); // => Monday
                }
                currentDate = currentDate + TimeSpan.FromMinutes(30);

                bool timeAlreadyTaken = false;
             
                foreach(Appointment appointment in alreadyTakenTimes)
                {
                    if (appointment.AppointmentTime.Equals(currentDate))
                        timeAlreadyTaken = true;
                 }

                if (!timeAlreadyTaken)
                {
                    availableTimes.Add(currentDate);
                }
            }
            return availableTimes;
        }
    }
}
