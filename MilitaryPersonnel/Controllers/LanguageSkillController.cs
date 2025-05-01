using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class LanguageSkillController : Controller
    {
        private readonly ILanguageSkillRepository _languageSkillRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public LanguageSkillController(ILanguageSkillRepository languageSkillRepository, IServicemanRepository servicemanRepository)
        {
            _languageSkillRepository = languageSkillRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: LanguageSkill
        public async Task<IActionResult> Index()
        {
            try
            {
                var languageSkills = await _languageSkillRepository.GetAllLanguageSkillsAsync();
                return View(languageSkills);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "LanguageSkill");
            }
        }

        // GET: LanguageSkill/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "LanguageSkill");

                var languageSkill = await _languageSkillRepository.GetLanguageSkillByIdAsync(id.Value);
                if (languageSkill == null)
                    return RedirectToAction("EP404", "EP");

                return View(languageSkill);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "LanguageSkill");
            }
        }

        // GET: LanguageSkill/Create
        public async Task<IActionResult> Create()
        {
            var servicemen = await _servicemanRepository.GetAllServicemenAsync();
            ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
            return View(new LanguageSkill());
        }

        // POST: LanguageSkill/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LanguageSkill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _languageSkillRepository.AddLanguageSkillAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "LanguageSkill");
            }
        }

        // GET: LanguageSkill/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "LanguageSkill");

                var languageSkill = await _languageSkillRepository.GetLanguageSkillByIdAsync(id.Value);
                if (languageSkill == null)
                    return RedirectToAction("EP404", "EP");

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(languageSkill);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "LanguageSkill");
            }
        }

        // POST: LanguageSkill/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(LanguageSkill model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _languageSkillRepository.UpdateLanguageSkillAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "LanguageSkill");
            }
        }

        // GET: LanguageSkill/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "LanguageSkill");

                var languageSkill = await _languageSkillRepository.GetLanguageSkillByIdAsync(id.Value);
                if (languageSkill == null)
                    return RedirectToAction("EP404", "EP");

                return View(languageSkill);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "LanguageSkill");
            }
        }

        // POST: LanguageSkill/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _languageSkillRepository.DeleteLanguageSkillAsync(id);
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