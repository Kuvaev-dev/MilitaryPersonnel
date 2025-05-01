using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class MilitarySpecialtyController : Controller
    {
        private readonly IMilitarySpecialtyRepository _militarySpecialtyRepository;

        public MilitarySpecialtyController(IMilitarySpecialtyRepository militarySpecialtyRepository)
        {
            _militarySpecialtyRepository = militarySpecialtyRepository;
        }

        // GET: MilitarySpecialty
        public async Task<IActionResult> Index()
        {
            try
            {
                var militarySpecialties = await _militarySpecialtyRepository.GetAllAsync();
                return View(militarySpecialties);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitarySpecialty");
            }
        }

        // GET: MilitarySpecialty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MilitarySpecialty");

                var militarySpecialty = await _militarySpecialtyRepository.GetByIdAsync(id.Value);
                if (militarySpecialty == null)
                    return RedirectToAction("EP404", "EP");

                return View(militarySpecialty);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitarySpecialty");
            }
        }

        // GET: MilitarySpecialty/Create
        public IActionResult Create()
        {
            return View(new MilitarySpecialty());
        }

        // POST: MilitarySpecialty/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MilitarySpecialty model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _militarySpecialtyRepository.AddAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitarySpecialty");
            }
        }

        // GET: MilitarySpecialty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MilitarySpecialty");

                var militarySpecialty = await _militarySpecialtyRepository.GetByIdAsync(id.Value);
                if (militarySpecialty == null)
                    return RedirectToAction("EP404", "EP");

                return View(militarySpecialty);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitarySpecialty");
            }
        }

        // POST: MilitarySpecialty/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MilitarySpecialty model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _militarySpecialtyRepository.UpdateAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitarySpecialty");
            }
        }

        // GET: MilitarySpecialty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MilitarySpecialty");

                var militarySpecialty = await _militarySpecialtyRepository.GetByIdAsync(id.Value);
                if (militarySpecialty == null)
                    return RedirectToAction("EP404", "EP");

                return View(militarySpecialty);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitarySpecialty");
            }
        }

        // POST: MilitarySpecialty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _militarySpecialtyRepository.DeleteAsync(id);
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