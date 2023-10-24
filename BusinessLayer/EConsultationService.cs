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

        public async Task<List<EConsultation>> GetAllForGPAsync(string userName)
        {
            {
                var econsultations = await _context.EConsultations.Where(e => e.GP.UserName == userName).Include(e => e.Patient).Include(e => e.GP).ToListAsync();
           

                return econsultations;
            }

        }
        public async Task<List<EConsultation>> GetAllForPatientAsync(string userName)
        {
            {
                var econsultations = await _context.EConsultations.Where(e => e.Patient.UserName == userName).Include(e => e.GP).Include(e => e.Patient).ToListAsync();

                return econsultations;
            }
        }
    }
}
