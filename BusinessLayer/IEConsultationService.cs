using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;

namespace DoktormandenDk.BusinessLayer
{
    public interface IEConsultationService
    {
        public Task<bool> AddConsultation(EConsultation eConsultation);
        public Task<bool> UpdateConsultation(EConsultation eConsultation);

        public Task<List<EConsultation>> GetAllForGP(string userName);
        public Task<List<EConsultation>> GetAllForPatient(string userName);
        public Task<EConsultation?> GetEConsultationFromId(int? id);
        public Task<bool> CancelConsultationById(int id);
        public Task<IEnumerable<EConsultation>?> GetAllConsultations();
        public bool EConsultationExists(int id);
    }
}