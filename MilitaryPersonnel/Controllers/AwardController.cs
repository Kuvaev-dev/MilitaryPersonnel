using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class AwardController : Controller
    {
        private readonly IAwardRepository _awardRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public AwardController(IAwardRepository awardRepository, IServicemanRepository servicemanRepository)
        {
            _awardRepository = awardRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: Award
        public async Task<IActionResult> Index()
        {
            try
            {
                var awards = await _awardRepository.GetAllAwardsAsync();
                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(awards);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Award");
            }
        }

        // GET: Award
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var award = await _awardRepository.GetAwardByIdAsync(id.Value);
                return View(award);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Award");
            }
        }

        // GET: Award/Create
        public async Task<IActionResult> Create()
        {
            var servicemen = await _servicemanRepository.GetAllServicemenAsync();
            ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
            return View(new Award());
        }

        // POST: AccountActivity/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Award model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _awardRepository.AddAwardAsync(model);
                    return RedirectToAction("Index");
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Award");
            }
        }

        // GET: AccountActivity/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var award = await _awardRepository.GetAwardByIdAsync(id.Value);
                if (award == null) return RedirectToAction("Index", "Award");
                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(award);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Award");
            }
        }

        // POST: AccountActivity/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Award model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _awardRepository.UpdateAwardAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Award");
            }
        }

        // GET: AccountActivity/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var award = await _awardRepository.GetAwardByIdAsync(id);
                if (award == null) return RedirectToAction("EP404", "EP");

                return View(award);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Award");
            }
        }

        // POST: AccountActivity/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _awardRepository.DeleteAwardAsync(id);
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
