using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class SubdivisionController : Controller
    {
        private readonly ISubdivisionRepository _subdivisionRepository;
        private readonly IMilitaryUnitRepository _militaryUnitRepository;

        public SubdivisionController(
            ISubdivisionRepository subdivisionRepository,
            IMilitaryUnitRepository militaryUnitRepository)
        {
            _subdivisionRepository = subdivisionRepository;
            _militaryUnitRepository = militaryUnitRepository;
        }

        // GET: Subdivision
        public async Task<IActionResult> Index()
        {
            try
            {
                var subdivisions = await _subdivisionRepository.GetAllSubdivisionsAsync();
                return View(subdivisions);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Subdivision");
            }
        }

        // GET: Subdivision/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Subdivision");

                var subdivision = await _subdivisionRepository.GetSubdivisionByIdAsync(id.Value);
                if (subdivision == null)
                    return RedirectToAction("EP404", "EP");

                return View(subdivision);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Subdivision");
            }
        }

        private async Task PopulateViewBags()
        {
            var militaryUnits = await _militaryUnitRepository.GetAllMilitaryUnitsAsync();
            ViewBag.MilitaryUnitList = militaryUnits
                .Select(mu => new { MilitaryUnitId = mu.Id, MilitaryUnit = mu.UnitName })
                .ToList();
        }

        // GET: Subdivision/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                await PopulateViewBags();
                return View(new Subdivision());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Subdivision");
            }
        }

        // POST: Subdivision/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Subdivision model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _subdivisionRepository.AddSubdivisionAsync(model);
                    return RedirectToAction("Index");
                }
                await PopulateViewBags();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Subdivision");
            }
        }

        // GET: Subdivision/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Subdivision");

                var subdivision = await _subdivisionRepository.GetSubdivisionByIdAsync(id.Value);
                if (subdivision == null)
                    return RedirectToAction("EP404", "EP");

                await PopulateViewBags();
                return View(subdivision);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Subdivision");
            }
        }

        // POST: Subdivision/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Subdivision model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _subdivisionRepository.UpdateSubdivisionAsync(model);
                    return RedirectToAction("Index");
                }
                await PopulateViewBags();
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Subdivision");
            }
        }

        // GET: Subdivision/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Subdivision");

                var subdivision = await _subdivisionRepository.GetSubdivisionByIdAsync(id.Value);
                if (subdivision == null)
                    return RedirectToAction("EP404", "EP");

                return View(subdivision);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Subdivision");
            }
        }

        // POST: Subdivision/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _subdivisionRepository.DeleteSubdivisionAsync(id);
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