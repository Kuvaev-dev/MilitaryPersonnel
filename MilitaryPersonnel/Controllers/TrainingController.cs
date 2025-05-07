using Database.Repositories;
using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class TrainingController : Controller
    {
        private readonly ITrainingRepository _trainingRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public TrainingController(
            ITrainingRepository trainingRepository, 
            IServicemanRepository servicemanRepository)
        {
            _trainingRepository = trainingRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: Training
        public async Task<IActionResult> Index()
        {
            try
            {
                var trainings = await _trainingRepository.GetAllTrainingsAsync();
                return View(trainings);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Training");
            }
        }

        // GET: Training/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Training");

                var training = await _trainingRepository.GetTrainingByIdAsync(id.Value);
                if (training == null)
                    return RedirectToAction("EP404", "EP");

                return View(training);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Training");
            }
        }

        // GET: Training/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdown();
            return View(new Training());
        }

        // POST: Training/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Training model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.EndDate.HasValue && model.StartDate.HasValue && model.EndDate < model.StartDate)
                    {
                        ModelState.AddModelError("EndDate", "End Date cannot be before Start Date.");
                        return View(model);
                    }
                    await _trainingRepository.AddTrainingAsync(model);
                    await PopulateDropdown(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                await PopulateDropdown(model);
                return RedirectToAction("Index", "Training");
            }
        }

        // GET: Training/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Training");

                var training = await _trainingRepository.GetTrainingByIdAsync(id.Value);
                if (training == null)
                    return RedirectToAction("EP404", "EP");

                await PopulateDropdown(training);
                return View(training);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Training");
            }
        }

        // POST: Training/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Training model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (model.EndDate.HasValue && model.StartDate.HasValue && model.EndDate < model.StartDate)
                    {
                        ModelState.AddModelError("EndDate", "End Date cannot be before Start Date.");
                        return View(model);
                    }
                    await _trainingRepository.UpdateTrainingAsync(model);
                    await PopulateDropdown(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                await PopulateDropdown(model);
                return RedirectToAction("Index", "Training");
            }
        }

        // GET: Training/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Training");

                var training = await _trainingRepository.GetTrainingByIdAsync(id.Value);
                if (training == null)
                    return RedirectToAction("EP404", "EP");

                return View(training);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Training");
            }
        }

        // POST: Training/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _trainingRepository.DeleteTrainingAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("EP500", "EP");
            }
        }

        private async Task PopulateDropdown(Training? model = null)
        {
            var servicemen = await _servicemanRepository.GetAllServicemenAsync() ?? new List<Serviceman>();
            ViewBag.ServicemanList = new SelectList(
                servicemen.Select(s => new
                {
                    s.Id,
                    FullName = $"{s.LastName} {s.FirstName} {s.MiddleName}".Trim()
                }), "Id", "FullName", model?.ServicemanId);
        }
    }
}