using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class FamilyMemberController : Controller
    {
        private readonly IFamilyMemberRepository _familyMemberRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public FamilyMemberController(IFamilyMemberRepository familyMemberRepository, IServicemanRepository servicemanRepository)
        {
            _familyMemberRepository = familyMemberRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: FamilyMember
        public async Task<IActionResult> Index()
        {
            try
            {
                var familyMembers = await _familyMemberRepository.GetAllFamilyMembersAsync();
                return View(familyMembers);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FamilyMember");
            }
        }

        // GET: FamilyMember/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "FamilyMember");

                var familyMember = await _familyMemberRepository.GetFamilyMemberByIdAsync(id.Value);
                if (familyMember == null)
                    return RedirectToAction("EP404", "EP");

                return View(familyMember);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FamilyMember");
            }
        }

        // GET: FamilyMember/Create
        public async Task<IActionResult> Create()
        {
            var servicemen = await _servicemanRepository.GetAllServicemenAsync();
            ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
            return View(new FamilyMember());
        }

        // POST: FamilyMember/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FamilyMember model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _familyMemberRepository.AddFamilyMemberAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FamilyMember");
            }
        }

        // GET: FamilyMember/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "FamilyMember");

                var familyMember = await _familyMemberRepository.GetFamilyMemberByIdAsync(id.Value);
                if (familyMember == null)
                    return RedirectToAction("EP404", "EP");

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(familyMember);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FamilyMember");
            }
        }

        // POST: FamilyMember/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(FamilyMember model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _familyMemberRepository.UpdateFamilyMemberAsync(model);
                    return RedirectToAction("Index");
                }

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = s.FirstName + " " + s.LastName + " " + s.MiddleName });
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FamilyMember");
            }
        }

        // GET: FamilyMember/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "FamilyMember");

                var familyMember = await _familyMemberRepository.GetFamilyMemberByIdAsync(id.Value);
                if (familyMember == null)
                    return RedirectToAction("EP404", "EP");

                return View(familyMember);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "FamilyMember");
            }
        }

        // POST: FamilyMember/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _familyMemberRepository.DeleteFamilyMemberAsync(id);
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