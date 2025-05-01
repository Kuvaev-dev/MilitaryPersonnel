using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class EducationController : Controller
    {
        private readonly IEducationRepository _educationRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public EducationController(IEducationRepository educationRepository, IServicemanRepository servicemanRepository)
        {
            _educationRepository = educationRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: Education
        public async Task<IActionResult> Index()
        {
            try
            {
                var educations = await _educationRepository.GetAllEducationsAsync();
                return View(educations);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Education");
            }
        }

        // GET: Education/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Education");

                var education = await _educationRepository.GetEducationByIdAsync(id.Value);
                if (education == null)
                    return RedirectToAction("EP404", "EP");

                return View(education);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Education");
            }
        }

        // GET: Education/Create
        public async Task<IActionResult> Create()
        {
            var servicemen = await _servicemanRepository.GetAllServicemenAsync();
            ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
            return View(new Education());
        }

        // POST: Education/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Education model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _educationRepository.AddEducationAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Education");
            }
        }

        // GET: Education/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Education");

                var education = await _educationRepository.GetEducationByIdAsync(id.Value);
                if (education == null)
                    return RedirectToAction("EP404", "EP");

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(education);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Education");
            }
        }

        // POST: Education/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Education model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _educationRepository.UpdateEducationAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Education");
            }
        }

        // GET: Education/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Education");

                var education = await _educationRepository.GetEducationByIdAsync(id.Value);
                if (education == null)
                    return RedirectToAction("EP404", "EP");

                return View(education);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Education");
            }
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _educationRepository.DeleteEducationAsync(id);
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