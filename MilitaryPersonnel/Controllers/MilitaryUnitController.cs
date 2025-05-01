using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class MilitaryUnitController : Controller
    {
        private readonly IMilitaryUnitRepository _militaryUnitRepository;

        public MilitaryUnitController(IMilitaryUnitRepository militaryUnitRepository)
        {
            _militaryUnitRepository = militaryUnitRepository;
        }

        // GET: MilitaryUnit
        public async Task<IActionResult> Index()
        {
            try
            {
                var militaryUnits = await _militaryUnitRepository.GetAllMilitaryUnitsAsync();
                return View(militaryUnits);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitaryUnit");
            }
        }

        // GET: MilitaryUnit/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MilitaryUnit");

                var militaryUnit = await _militaryUnitRepository.GetMilitaryUnitByIdAsync(id.Value);
                if (militaryUnit == null)
                    return RedirectToAction("EP404", "EP");

                return View(militaryUnit);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitaryUnit");
            }
        }

        // GET: MilitaryUnit/Create
        public IActionResult Create()
        {
            return View(new MilitaryUnit());
        }

        // POST: MilitaryUnit/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MilitaryUnit model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _militaryUnitRepository.AddMilitaryUnitAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitaryUnit");
            }
        }

        // GET: MilitaryUnit/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MilitaryUnit");

                var militaryUnit = await _militaryUnitRepository.GetMilitaryUnitByIdAsync(id.Value);
                if (militaryUnit == null)
                    return RedirectToAction("EP404", "EP");

                return View(militaryUnit);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitaryUnit");
            }
        }

        // POST: MilitaryUnit/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MilitaryUnit model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _militaryUnitRepository.UpdateMilitaryUnitAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitaryUnit");
            }
        }

        // GET: MilitaryUnit/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MilitaryUnit");

                var militaryUnit = await _militaryUnitRepository.GetMilitaryUnitByIdAsync(id.Value);
                if (militaryUnit == null)
                    return RedirectToAction("EP404", "EP");

                return View(militaryUnit);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MilitaryUnit");
            }
        }

        // POST: MilitaryUnit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _militaryUnitRepository.DeleteMilitaryUnitAsync(id);
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