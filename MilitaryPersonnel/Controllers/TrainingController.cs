using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class TrainingController : Controller
    {
        private readonly ITrainingRepository _trainingRepository;

        public TrainingController(ITrainingRepository trainingRepository)
        {
            _trainingRepository = trainingRepository;
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
        public IActionResult Create()
        {
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
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
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
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
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
    }
}