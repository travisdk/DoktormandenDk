using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace DoktormandenDk.BusinessLayer
{
    public interface IAppointmentsService
    {

        public Task<List<Appointment>> GetAllForUsernameAsync(string userName);

        // TODO: Another place for these 2  ??
        public Task<List<GP>> GetAllGPsAsync();
        public Task<List<Patient>> GetAllPatientsAsync();

        public Task<List<DateTime>> GetAvailableTimes(GP gp);
    }
}
