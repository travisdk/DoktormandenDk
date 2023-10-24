using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;

namespace DoktormandenDk.BusinessLayer
{
    public interface IEConsultationService
    {
        public Task<List<EConsultation>> GetAllForGPAsync(string userName);
        public Task<List<EConsultation>> GetAllForPatientAsync(string userName);
    }
}