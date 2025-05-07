using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class ServiceAttitudeController : Controller
    {
        private readonly IServiceAttitudeRepository _serviceAttitudeRepository;

        public ServiceAttitudeController(IServiceAttitudeRepository serviceAttitudeRepository)
        {
            _serviceAttitudeRepository = serviceAttitudeRepository;
        }

        // GET: ServiceAttitude
        public async Task<IActionResult> Index()
        {
            try
            {
                var serviceAttitudes = await _serviceAttitudeRepository.GetAllServiceAttitudesAsync();
                return View(serviceAttitudes);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceAttitude");
            }
        }

        // GET: ServiceAttitude/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceAttitude");

                var serviceAttitude = await _serviceAttitudeRepository.GetServiceAttitudeByIdAsync(id.Value);
                if (serviceAttitude == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceAttitude);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceAttitude");
            }
        }

        // GET: ServiceAttitude/Create
        public IActionResult Create()
        {
            return View(new ServiceAttitude());
        }

        // POST: ServiceAttitude/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceAttitude model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceAttitudeRepository.AddServiceAttitudeAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceAttitude");
            }
        }

        // GET: ServiceAttitude/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceAttitude");

                var serviceAttitude = await _serviceAttitudeRepository.GetServiceAttitudeByIdAsync(id.Value);
                if (serviceAttitude == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceAttitude);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceAttitude");
            }
        }

        // POST: ServiceAttitude/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceAttitude model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceAttitudeRepository.UpdateServiceAttitudeAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceAttitude");
            }
        }

        // GET: ServiceAttitude/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceAttitude");

                var serviceAttitude = await _serviceAttitudeRepository.GetServiceAttitudeByIdAsync(id.Value);
                if (serviceAttitude == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceAttitude);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceAttitude");
            }
        }

        // POST: ServiceAttitude/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _serviceAttitudeRepository.DeleteServiceAttitudeAsync(id);
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