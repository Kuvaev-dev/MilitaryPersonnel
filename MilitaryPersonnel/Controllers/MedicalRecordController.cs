using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class MedicalRecordController : Controller
    {
        private readonly IMedicalRecordRepsitory _medicalRecordRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public MedicalRecordController(IMedicalRecordRepsitory medicalRecordRepository, IServicemanRepository servicemanRepository)
        {
            _medicalRecordRepository = medicalRecordRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: MedicalRecord
        public async Task<IActionResult> Index()
        {
            try
            {
                var medicalRecords = await _medicalRecordRepository.GetAllMedicalRecordsAsync();
                return View(medicalRecords);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MedicalRecord");
            }
        }

        // GET: MedicalRecord/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MedicalRecord");

                var medicalRecord = await _medicalRecordRepository.GetMedicalRecordByIdAsync(id.Value);
                if (medicalRecord == null)
                    return RedirectToAction("EP404", "EP");

                return View(medicalRecord);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MedicalRecord");
            }
        }

        // GET: MedicalRecord/Create
        public async Task<IActionResult> Create()
        {
            var servicemen = await _servicemanRepository.GetAllServicemenAsync();
            ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
            return View(new MedicalRecord());
        }

        // POST: MedicalRecord/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MedicalRecord model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _medicalRecordRepository.AddMedicalRecordAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MedicalRecord");
            }
        }

        // GET: MedicalRecord/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MedicalRecord");

                var medicalRecord = await _medicalRecordRepository.GetMedicalRecordByIdAsync(id.Value);
                if (medicalRecord == null)
                    return RedirectToAction("EP404", "EP");

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(medicalRecord);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MedicalRecord");
            }
        }

        // POST: MedicalRecord/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MedicalRecord model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _medicalRecordRepository.UpdateMedicalRecordAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MedicalRecord");
            }
        }

        // GET: MedicalRecord/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MedicalRecord");

                var medicalRecord = await _medicalRecordRepository.GetMedicalRecordByIdAsync(id.Value);
                if (medicalRecord == null)
                    return RedirectToAction("EP404", "EP");

                return View(medicalRecord);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MedicalRecord");
            }
        }

        // POST: MedicalRecord/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _medicalRecordRepository.DeleteMedicalRecordAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("EP500", "EP");
            }
        }
    }
}