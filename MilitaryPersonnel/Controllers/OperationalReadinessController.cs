using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class OperationalReadinessController : Controller
    {
        private readonly IOperationalReadinessRepository _operationalReadinessRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public OperationalReadinessController(IOperationalReadinessRepository operationalReadinessRepository, IServicemanRepository servicemanRepository)
        {
            _operationalReadinessRepository = operationalReadinessRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: OperationalReadiness
        public async Task<IActionResult> Index()
        {
            try
            {
                var operationalReadinessRecords = await _operationalReadinessRepository.GetAllOperationalReadinessAsync();
                return View(operationalReadinessRecords);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "OperationalReadiness");
            }
        }

        // GET: OperationalReadiness/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "OperationalReadiness");

                var operationalReadiness = await _operationalReadinessRepository.GetOperationalReadinessByIdAsync(id.Value);
                if (operationalReadiness == null)
                    return RedirectToAction("EP404", "EP");

                return View(operationalReadiness);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "OperationalReadiness");
            }
        }

        // GET: OperationalReadiness/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(new OperationalReadiness());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "OperationalReadiness");
            }
        }

        // POST: OperationalReadiness/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(OperationalReadiness model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _operationalReadinessRepository.AddOperationalReadinessAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "OperationalReadiness");
            }
        }

        // GET: OperationalReadiness/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "OperationalReadiness");

                var operationalReadiness = await _operationalReadinessRepository.GetOperationalReadinessByIdAsync(id.Value);
                if (operationalReadiness == null)
                    return RedirectToAction("EP404", "EP");

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(operationalReadiness);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "OperationalReadiness");
            }
        }

        // POST: OperationalReadiness/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(OperationalReadiness model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _operationalReadinessRepository.UpdateOperationalReadinessAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "OperationalReadiness");
            }
        }

        // GET: OperationalReadiness/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "OperationalReadiness");

                var operationalReadiness = await _operationalReadinessRepository.GetOperationalReadinessByIdAsync(id.Value);
                if (operationalReadiness == null)
                    return RedirectToAction("EP404", "EP");

                return View(operationalReadiness);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "OperationalReadiness");
            }
        }

        // POST: OperationalReadiness/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _operationalReadinessRepository.DeleteOperationalReadinessAsync(id);
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