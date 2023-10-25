using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DoktormandenDk.BusinessLayer
{
    public interface IAppointmentsService
    {


        public Task<List<GP>> GetAllGPsAsync();
        public Task<List<Patient>> GetAllPatientsAsync();

        public Task<List<DateTime>> GetAvailableTimesAsync(int gpId, int patientId);
        public Task<List<Appointment>> GetAllForGPAsync(string userName);
        public Task<List<Appointment>> GetAllForPatientAsync(string userName);
    }
}
