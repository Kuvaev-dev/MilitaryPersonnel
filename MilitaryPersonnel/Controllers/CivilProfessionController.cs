using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class CivilProfessionController : Controller
    {
        private readonly ICivilProfessionRepository _civilProfessionRepository;

        public CivilProfessionController(ICivilProfessionRepository civilProfessionRepository)
        {
            _civilProfessionRepository = civilProfessionRepository;
        }

        // GET: CivilProfession
        public async Task<IActionResult> Index()
        {
            try
            {
                var civilProfessions = await _civilProfessionRepository.GetAllAsync();
                return View(civilProfessions);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CivilProfession");
            }
        }

        // GET: CivilProfession/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "CivilProfession");

                var civilProfession = await _civilProfessionRepository.GetByIdAsync(id.Value);
                if (civilProfession == null)
                    return RedirectToAction("EP404", "EP");

                return View(civilProfession);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CivilProfession");
            }
        }

        // GET: CivilProfession/Create
        public IActionResult Create()
        {
            return View(new CivilProfession());
        }

        // POST: CivilProfession/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CivilProfession model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _civilProfessionRepository.AddAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CivilProfession");
            }
        }

        // GET: CivilProfession/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "CivilProfession");

                var civilProfession = await _civilProfessionRepository.GetByIdAsync(id.Value);
                if (civilProfession == null)
                    return RedirectToAction("EP404", "EP");

                return View(civilProfession);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CivilProfession");
            }
        }

        // POST: CivilProfession/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CivilProfession model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _civilProfessionRepository.UpdateAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CivilProfession");
            }
        }

        // GET: CivilProfession/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "CivilProfession");

                var civilProfession = await _civilProfessionRepository.GetByIdAsync(id.Value);
                if (civilProfession == null)
                    return RedirectToAction("EP404", "EP");

                return View(civilProfession);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CivilProfession");
            }
        }

        // POST: CivilProfession/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _civilProfessionRepository.DeleteAsync(id);
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
