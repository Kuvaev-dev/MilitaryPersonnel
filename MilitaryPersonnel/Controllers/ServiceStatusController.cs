using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class ServiceStatusController : Controller
    {
        private readonly IServiceStatusRepository _serviceStatusRepository;

        public ServiceStatusController(IServiceStatusRepository serviceStatusRepository)
        {
            _serviceStatusRepository = serviceStatusRepository;
        }

        // GET: ServiceStatus
        public async Task<IActionResult> Index()
        {
            try
            {
                var serviceStatuses = await _serviceStatusRepository.GetAllServiceStatusesAsync();
                return View(serviceStatuses);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceStatus");
            }
        }

        // GET: ServiceStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceStatus");

                var serviceStatus = await _serviceStatusRepository.GetServiceStatusByIdAsync(id.Value);
                if (serviceStatus == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceStatus);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceStatus");
            }
        }

        // GET: ServiceStatus/Create
        public IActionResult Create()
        {
            return View(new ServiceStatus());
        }

        // POST: ServiceStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceStatus model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceStatusRepository.AddServiceStatusAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceStatus");
            }
        }

        // GET: ServiceStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceStatus");

                var serviceStatus = await _serviceStatusRepository.GetServiceStatusByIdAsync(id.Value);
                if (serviceStatus == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceStatus);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceStatus");
            }
        }

        // POST: ServiceStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceStatus model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceStatusRepository.UpdateServiceStatusAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceStatus");
            }
        }

        // GET: ServiceStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceStatus");

                var serviceStatus = await _serviceStatusRepository.GetServiceStatusByIdAsync(id.Value);
                if (serviceStatus == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceStatus);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceStatus");
            }
        }

        // POST: ServiceStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _serviceStatusRepository.DeleteServiceStatusAsync(id);
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