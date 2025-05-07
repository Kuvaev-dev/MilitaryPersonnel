using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class FitnessCategoryController : Controller
    {
        private readonly IFitnessCategoryRepository _fitnessCategoryRepository;

        public FitnessCategoryController(IFitnessCategoryRepository fitnessCategoryRepository)
        {
            _fitnessCategoryRepository = fitnessCategoryRepository;
        }

        // GET: FitnessCategory
        public async Task<IActionResult> Index()
        {
            try
            {
                var fitnessCategories = await _fitnessCategoryRepository.GetAllFitnessCategoriesAsync();
                return View(fitnessCategories);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FitnessCategory");
            }
        }

        // GET: FitnessCategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "FitnessCategory");

                var fitnessCategory = await _fitnessCategoryRepository.GetFitnessCategoryByIdAsync(id.Value);
                if (fitnessCategory == null)
                    return RedirectToAction("EP404", "EP");

                return View(fitnessCategory);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FitnessCategory");
            }
        }

        // GET: FitnessCategory/Create
        public IActionResult Create()
        {
            return View(new FitnessCategory());
        }

        // POST: FitnessCategory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FitnessCategory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _fitnessCategoryRepository.AddFitnessCategoryAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FitnessCategory");
            }
        }

        // GET: FitnessCategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "FitnessCategory");

                var fitnessCategory = await _fitnessCategoryRepository.GetFitnessCategoryByIdAsync(id.Value);
                if (fitnessCategory == null)
                    return RedirectToAction("EP404", "EP");

                return View(fitnessCategory);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FitnessCategory");
            }
        }

        // POST: FitnessCategory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FitnessCategory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _fitnessCategoryRepository.UpdateFitnessCategoryAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FitnessCategory");
            }
        }

        // GET: FitnessCategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "FitnessCategory");

                var fitnessCategory = await _fitnessCategoryRepository.GetFitnessCategoryByIdAsync(id.Value);
                if (fitnessCategory == null)
                    return RedirectToAction("EP404", "EP");

                return View(fitnessCategory);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FitnessCategory");
            }
        }

        // POST: FitnessCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _fitnessCategoryRepository.DeleteFitnessCategoryAsync(id);
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