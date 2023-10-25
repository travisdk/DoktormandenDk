using DoktormandenDk.Models;
using Microsoft.EntityFrameworkCore;

namespace DoktormandenDk.BusinessLayer
{
    public class EConsultationService : IEConsultationService
    {
        private readonly AppDbContext _context;

        public EConsultationService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddConsultation(EConsultation eConsultation)
        {
            _context.Add(eConsultation);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> CancelConsultationById(int id)
        {
            if (_context.EConsultations == null)
            {
                throw (new Exception("Entity set 'EConsultation'  is null."));
            }
            var eConsultation = await _context.EConsultations.FindAsync(id);
            if (eConsultation != null)
            {
                _context.EConsultations.Remove(eConsultation);
            }

            return await _context.SaveChangesAsync() > 0;
      
        }

        public async Task<IEnumerable<EConsultation>?> GetAllConsultations()
        {
            return await _context.EConsultations.ToListAsync();
        }
        public bool EConsultationExists(int id)
        {
            return (_context.EConsultations?.Any(e => e.EConsultationId == id)).GetValueOrDefault();
        }
        public async Task<List<EConsultation>> GetAllForGP(string userName)
        {
            {
                var econsultations = await _context.EConsultations.Where(e => e.GP.UserName == userName).Include(e => e.Patient).Include(e => e.GP).ToListAsync();
           

                return econsultations;
            }

        }
        public async Task<List<EConsultation>> GetAllForPatient(string userName)
        {
            {
                var econsultations = await _context.EConsultations.Where(e => e.Patient.UserName == userName).Include(e => e.GP).Include(e => e.Patient).ToListAsync();

                return econsultations;
            }
        }

        public async Task<EConsultation?> GetEConsultationFromId(int? id)
        {
          return  await _context.EConsultations
                .Include(e => e.GP)
                .Include(e => e.Patient)
                .FirstOrDefaultAsync(m => m.EConsultationId == id);
        }

        public async Task<bool> UpdateConsultation(EConsultation eConsultation)
        {
            _context.Update(eConsultation);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
