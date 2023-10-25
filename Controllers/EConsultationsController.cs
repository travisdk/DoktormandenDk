using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DoktormandenDk.Models;
using DoktormandenDk.BusinessLayer;
using DoktormandenDk.Controllers.ActionFilters;

namespace DoktormandenDk.Controllers
{
    public class EConsultationsController : Controller
    {
        public readonly IUser LoggedInUser;
        private readonly IUserService _userService;
        private readonly IEConsultationService _eConsultationService;
        private readonly AppDbContext _context;



        public EConsultationsController(AppDbContext context, IUserService userService, IEConsultationService eConsultationService)
        {
            _context = context;
            _userService = userService;
            _eConsultationService = eConsultationService;
            LoggedInUser = _userService.CurrentUser;
        }

        // GET: EConsultations
        [TestValidEConsultationUser]
        public async Task<IActionResult> Index()
        {
            List<EConsultation> eConsultations = null;
            if (_userService.IsPatient)
            {
                eConsultations = await _eConsultationService.GetAllForPatient(LoggedInUser.UserName);
                return View("IndexForPatient", eConsultations);
            }
            else if (_userService.IsGP)
            {
                eConsultations = await _eConsultationService.GetAllForGP(LoggedInUser.UserName);
                return View("IndexForGP", eConsultations);
            }
            return NotFound();
        }

        // GET: EConsultations/Details/5
        [TestValidEConsultationUser]
        public async Task<IActionResult> Details(int? id)
        {
            List<EConsultation> eConsultations = null;
            if (_userService.IsPatient)
            {
                eConsultations = await _eConsultationService.GetAllForPatient(LoggedInUser.UserName);
            }
            else if (_userService.IsGP)
            {
                eConsultations = await _eConsultationService.GetAllForGP(LoggedInUser.UserName);
            }
            if (id == null || eConsultations == null)
            {
                return NotFound();
            }
            // we already have all the appointments for this user
            var eConsultation = eConsultations.FirstOrDefault(ec => ec.EConsultationId == id);
            
            if (eConsultation == null)
            {
                return NotFound();
            }

            return View(eConsultation);
        }

        // GET: EConsultations/CreateForPatient - Only patients ends up here (Not GP)
        [TestValidEConsultationUser]
        public IActionResult CreateForPatient()
        {
            if (!_userService.IsPatient)
            {
                return NotFound();
            }
            
            ViewData["GPId"] = new SelectList(_context.GPs, "GPId", "Name");
    
            var userAsPatient = (Patient)LoggedInUser;
            var eConsultation = new EConsultation
            {
                Patient = userAsPatient,
                PatientId = userAsPatient.PatientId,
                QuestionTime = DateTime.Now,
         
                

        };
            return View(eConsultation);
        }

        // POST: EConsultations/CreateForPatient
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TestValidEConsultationUser]
        public async Task<IActionResult> CreateForPatient([Bind("EConsultationId,PatientId,GPId,Question,QuestionTime,Answer,AnswerTime,Closed")] EConsultation eConsultation)
        {
            if (ModelState.IsValid)
            {
                eConsultation.QuestionTime = DateTime.Now;
                await _eConsultationService.AddConsultation(eConsultation);
 
                return RedirectToAction("Index");
            }
            ViewData["GPId"] = new SelectList(_context.GPs, "GPId", "Name", eConsultation.GPId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "PatientId", "Name", eConsultation.PatientId);
            return View(eConsultation);
        }

        // GET: EConsultations/EditForGP/5 - Only GPs ends up here (Not Patients)
        [TestValidEConsultationUser]
        public async Task<IActionResult> EditForGP(int? id)
        {
            if (!_userService.IsGP)
            {
                return NotFound();
            }
            if (id == null || _context.EConsultations == null)
            {
                return NotFound();
            }
            var eConsultation = await _context.EConsultations.FindAsync(id);
            if (eConsultation == null)
            {
                return NotFound();
            }
            eConsultation.GP = _context.GPs.Find(eConsultation.GPId);
            eConsultation.Patient = _context.Patients.Find(eConsultation.PatientId);
      
            return View(eConsultation);
        }

        // POST: EConsultations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [TestValidEConsultationUser]
        public async Task<IActionResult> EditForGP(int id, [Bind("EConsultationId,PatientId,GPId,Question,QuestionTime,Answer,AnswerTime,Closed")] EConsultation eConsultation)
        {
            if (id != eConsultation.EConsultationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    eConsultation.AnswerTime = DateTime.Now;
                    eConsultation.Closed = true;
                    await _eConsultationService.UpdateConsultation(eConsultation);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_eConsultationService.EConsultationExists (eConsultation.EConsultationId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(eConsultation);
        }

        // GET: EConsultations/Delete/5
        [TestValidEConsultationUser]
        public async Task<IActionResult> Delete(int? id)
        {
            var consultations = await _eConsultationService.GetAllConsultations();
   
             if (id == null || consultations == null)
            {
                return NotFound();
            }

            var eConsultation = await _eConsultationService.GetEConsultationFromId(id);

            if (eConsultation == null)
            {
                return NotFound();
            }

            return View(eConsultation);
        }

        // POST: EConsultations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [TestValidEConsultationUser]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _eConsultationService.CancelConsultationById(id);
            //var consultations = _eConsultationService.GetAllConsultations();
            //if (consultations == null)
            //{
            //    return Problem("Entity set 'AppDbContext.EConsultations'  is null.");
            //}
            //var eConsultation = await _eConsultationService.GetEConsultationFromId(id);
            //if (eConsultation != null)
            //{
            //   await _eConsultationService.CancelConsultation(eConsultation);
             
            //}
            
 
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Forbidden()
        {
            return View();
        }

    }
}
