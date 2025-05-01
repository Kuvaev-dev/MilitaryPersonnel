using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class DischargeController : Controller
    {
        private readonly IDischargeRepository _dischargeRepository;

        public DischargeController(IDischargeRepository dischargeRepository)
        {
            _dischargeRepository = dischargeRepository;
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
        public IActionResult Create()
        {
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
    }
}