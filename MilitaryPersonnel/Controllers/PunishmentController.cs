using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class PunishmentController : Controller
    {
        private readonly IPunishmentRepository _punishmentRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public PunishmentController(IPunishmentRepository punishmentRepository, IServicemanRepository servicemanRepository)
        {
            _punishmentRepository = punishmentRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: Punishment
        public async Task<IActionResult> Index()
        {
            try
            {
                var punishments = await _punishmentRepository.GetAllPunishments();
                return View(punishments);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Punishment");
            }
        }

        // GET: Punishment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Punishment");

                var punishment = await _punishmentRepository.GetPunishmentById(id.Value);
                if (punishment == null)
                    return RedirectToAction("EP404", "EP");

                return View(punishment);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Punishment");
            }
        }

        // GET: Punishment/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(new Punishment());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Punishment");
            }
        }

        // POST: Punishment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Punishment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _punishmentRepository.AddPunishment(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Punishment");
            }
        }

        // GET: Punishment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Punishment");

                var punishment = await _punishmentRepository.GetPunishmentById(id.Value);
                if (punishment == null)
                    return RedirectToAction("EP404", "EP");

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });

                return View(punishment);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Punishment");
            }
        }

        // POST: Punishment/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Punishment model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _punishmentRepository.UpdatePunishment(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Punishment");
            }
        }

        // GET: Punishment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Punishment");

                var punishment = await _punishmentRepository.GetPunishmentById(id.Value);
                if (punishment == null)
                    return RedirectToAction("EP404", "EP");

                return View(punishment);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Punishment");
            }
        }

        // POST: Punishment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _punishmentRepository.DeletePunishment(id);
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