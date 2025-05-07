using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class ContactInfoController : Controller
    {
        private readonly IContactInfoRepository _contactInfoRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public ContactInfoController(
            IContactInfoRepository contactInfoRepository, 
            IServicemanRepository servicemanRepository)
        {
            _contactInfoRepository = contactInfoRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: ContactInfo
        public async Task<IActionResult> Index()
        {
            try
            {
                var contactInfos = await _contactInfoRepository.GetAllContactInfosAsync();
                return View(contactInfos);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ContactInfo");
            }
        }

        // GET: ContactInfo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ContactInfo");

                var contactInfo = await _contactInfoRepository.GetContactInfoByIdAsync(id.Value);
                if (contactInfo == null)
                    return RedirectToAction("EP404", "EP");

                return View(contactInfo);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ContactInfo");
            }
        }

        // GET: ContactInfo/Create
        public async Task<IActionResult> Create()
        {
            await PopulateDropdown();
            return View(new ContactInfo());
        }

        // POST: ContactInfo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContactInfo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactInfoRepository.AddContactInfoAsync(model);
                    return RedirectToAction("Index");
                }

                await PopulateDropdown(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                await PopulateDropdown(model);
                return RedirectToAction("Index", "ContactInfo");
            }
        }

        // GET: ContactInfo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ContactInfo");

                var contactInfo = await _contactInfoRepository.GetContactInfoByIdAsync(id.Value);
                if (contactInfo == null)
                    return RedirectToAction("EP404", "EP");

                await PopulateDropdown(contactInfo);
                return View(contactInfo);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ContactInfo");
            }
        }

        // POST: ContactInfo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContactInfo model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _contactInfoRepository.UpdateContactInfoAsync(model);
                    return RedirectToAction("Index");
                }

                await PopulateDropdown(model);
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                await PopulateDropdown(model);
                return RedirectToAction("Index", "ContactInfo");
            }
        }

        // GET: ContactInfo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ContactInfo");

                var contactInfo = await _contactInfoRepository.GetContactInfoByIdAsync(id.Value);
                if (contactInfo == null)
                    return RedirectToAction("EP404", "EP");

                return View(contactInfo);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ContactInfo");
            }
        }

        // POST: ContactInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _contactInfoRepository.DeleteContactInfoAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("EP500", "EP");
            }
        }

        private async Task PopulateDropdown(ContactInfo? model = null)
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