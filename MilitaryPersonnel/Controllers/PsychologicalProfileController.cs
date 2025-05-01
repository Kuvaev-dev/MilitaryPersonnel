using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class PsychologicalProfileController : Controller
    {
        private readonly IPsychologicalProfileRepository _psychologicalProfileRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public PsychologicalProfileController(IPsychologicalProfileRepository psychologicalProfileRepository, IServicemanRepository servicemanRepository)
        {
            _psychologicalProfileRepository = psychologicalProfileRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: PsychologicalProfile
        public async Task<IActionResult> Index()
        {
            try
            {
                var psychologicalProfiles = await _psychologicalProfileRepository.GetAllPsychologicalProfilesAsync();
                return View(psychologicalProfiles);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "PsychologicalProfile");
            }
        }

        // GET: PsychologicalProfile/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "PsychologicalProfile");

                var psychologicalProfile = await _psychologicalProfileRepository.GetPsychologicalProfileByIdAsync(id.Value);
                if (psychologicalProfile == null)
                    return RedirectToAction("EP404", "EP");

                return View(psychologicalProfile);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "PsychologicalProfile");
            }
        }

        // GET: PsychologicalProfile/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(new PsychologicalProfile());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "PsychologicalProfile");
            }
        }

        // POST: PsychologicalProfile/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PsychologicalProfile model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _psychologicalProfileRepository.AddPsychologicalProfileAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "PsychologicalProfile");
            }
        }

        // GET: PsychologicalProfile/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "PsychologicalProfile");

                var psychologicalProfile = await _psychologicalProfileRepository.GetPsychologicalProfileByIdAsync(id.Value);
                if (psychologicalProfile == null)
                    return RedirectToAction("EP404", "EP");

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(psychologicalProfile);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "PsychologicalProfile");
            }
        }

        // POST: PsychologicalProfile/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(PsychologicalProfile model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _psychologicalProfileRepository.UpdatePsychologicalProfileAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "PsychologicalProfile");
            }
        }

        // GET: PsychologicalProfile/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "PsychologicalProfile");

                var psychologicalProfile = await _psychologicalProfileRepository.GetPsychologicalProfileByIdAsync(id.Value);
                if (psychologicalProfile == null)
                    return RedirectToAction("EP404", "EP");

                return View(psychologicalProfile);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "PsychologicalProfile");
            }
        }

        // POST: PsychologicalProfile/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _psychologicalProfileRepository.DeletePsychologicalProfileAsync(id);
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