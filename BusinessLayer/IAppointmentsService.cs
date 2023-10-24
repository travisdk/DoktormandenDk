using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DoktormandenDk.BusinessLayer
{
    public interface IAppointmentsService
    {

        // TODO: Another place for these 2  ??
        public Task<List<GP>> GetAllGPsAsync();
        public Task<List<Patient>> GetAllPatientsAsync();

        public Task<List<DateTime>> GetAvailableTimesAsync(int patientId);
        public Task<List<Appointment>> GetAllForGPAsync(string userName);
        public Task<List<Appointment>> GetAllForPatientAsync(string userName);
    }
}
