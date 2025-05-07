using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class DischargeController : Controller
    {
        private readonly IDischargeRepository _dischargeRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public DischargeController(
            IDischargeRepository dischargeRepository, 
            IServicemanRepository servicemanRepository)
        {
            _dischargeRepository = dischargeRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: Discharge
        public async Task<IActionResult> Index()
        {
            try
            {
                var discharges = await _dischargeRepository.GetAllDischargesAsync();
                return View(discharges);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Discharge");
            }
        }

        // GET: Discharge/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Discharge");

                var discharge = await _dischargeRepository.GetDischargeByIdAsync(id.Value);
                if (discharge == null)
                    return RedirectToAction("EP404", "EP");

                return View(discharge);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Discharge");
            }
        }

        // GET: Discharge/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdown();
            return View(new Discharge());
        }

        // POST: Discharge/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Discharge model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dischargeRepository.AddDischargeAsync(model);
                    return RedirectToAction("Index");
                }

                await PopulateDropdown(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Discharge");
            }
        }

        // GET: Discharge/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Discharge");

                var discharge = await _dischargeRepository.GetDischargeByIdAsync(id.Value);
                if (discharge == null)
                    return RedirectToAction("EP404", "EP");

                await PopulateDropdown();
                return View(discharge);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Discharge");
            }
        }

        // POST: Discharge/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Discharge model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _dischargeRepository.UpdateDischargeAsync(model);
                    return RedirectToAction("Index");
                }

                await PopulateDropdown(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Discharge");
            }
        }

        // GET: Discharge/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Discharge");

                var discharge = await _dischargeRepository.GetDischargeByIdAsync(id.Value);
                if (discharge == null)
                    return RedirectToAction("EP404", "EP");

                return View(discharge);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Discharge");
            }
        }

        // POST: Discharge/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _dischargeRepository.DeleteDischargeAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("EP500", "EP");
            }
        }

        private async Task PopulateDropdown(Discharge? model = null)
        {
            var servicemen = await _servicemanRepository.GetAllServicemenAsync();
            ViewBag.ServicemanList = servicemen
                .Select(s => new
                {
                    ServicemanId = s.Id,
                    ServicemanFullName = s.LastName + " " + s.FirstName + " " + s.MiddleName
                }).ToList();
        }
    }
}