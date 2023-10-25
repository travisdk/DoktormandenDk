using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DoktormandenDk.BusinessLayer
{
    public interface IAppointmentsService
    {
        public Task<bool> AddAppointment(Appointment appointment);
        public Task<List<GP>> GetAllGPs();
        public Task<List<Patient>> GetAllPatients();
        public Task<List<DateTime>> GetAvailableTimes(int gpId, int patientId);
        public Task<Appointment?> GetAppointmentFromId(int? id);
        public Task<List<Appointment>> GetAllForGP(string userName);
        public Task<List<Appointment>> GetAllForPatient(string userName);
        public Task<bool> CancelAppointmentById(int id);
        public Task<IEnumerable<Appointment>?> GetAllAppointments();
        public bool AppointmentExists(int id);

    }
}
