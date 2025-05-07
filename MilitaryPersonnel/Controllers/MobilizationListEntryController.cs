using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class MobilizationListEntryController : Controller
    {
        private readonly IMobilizationListEntryRepository _mobilizationListEntryRepository;
        private readonly IMobilizationListRepository _mobilizationListRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public MobilizationListEntryController(
            IMobilizationListEntryRepository mobilizationListEntryRepository, 
            IMobilizationListRepository mobilizationListRepository,
            IServicemanRepository servicemanRepository)
        {
            _mobilizationListEntryRepository = mobilizationListEntryRepository;
            _mobilizationListRepository = mobilizationListRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: MobilizationListEntry?mobilizationListId=5
        public async Task<IActionResult> Index()
        {
            try
            {
                var entries = await _mobilizationListEntryRepository.GetMobilizationListEntriesAsync();
                return View(entries);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // GET: MobilizationListEntry/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MobilizationList");

                var mobilizationListEntry = await _mobilizationListEntryRepository.GetMobilizationListEntryAsync(id.Value);
                if (mobilizationListEntry == null)
                    return RedirectToAction("EP404", "EP");

                return View(mobilizationListEntry);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // GET: MobilizationListEntry/Create?mobilizationListId=5
        public async Task<IActionResult> Create()
        {
            try
            {
                await PopulateDropdowns();

                return View(new MobilizationListEntry());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // POST: MobilizationListEntry/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MobilizationListEntry model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mobilizationListEntryRepository.AddMobilizationListEntryAsync(model);
                    return RedirectToAction("Index");
                }

                await PopulateDropdowns(model);

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // GET: MobilizationListEntry/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var mobilizationListEntry = await _mobilizationListEntryRepository.GetMobilizationListEntryAsync(id.Value);
                if (mobilizationListEntry == null)
                    return RedirectToAction("EP404", "EP");

                await PopulateDropdowns();

                return View(mobilizationListEntry);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // POST: MobilizationListEntry/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MobilizationListEntry model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mobilizationListEntryRepository.UpdateMobilizationListEntryAsync(model);
                    return RedirectToAction("Index", new { mobilizationListId = model.MobilizationListId });
                }

                await PopulateDropdowns(model);

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // GET: MobilizationListEntry/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MobilizationList");

                var mobilizationListEntry = await _mobilizationListEntryRepository.GetMobilizationListEntryAsync(id.Value);
                if (mobilizationListEntry == null)
                    return RedirectToAction("EP404", "EP");

                return View(mobilizationListEntry);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // POST: MobilizationListEntry/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _mobilizationListEntryRepository.DeleteMobilizationListEntryAsync(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("EP500", "EP");
            }
        }

        private async Task PopulateDropdowns(MobilizationListEntry? model = null)
        {
            var mobilizationLists = await _mobilizationListRepository.GetMobilizationListsAsync();
            var servisemen = await _servicemanRepository.GetAllServicemenAsync();

            ViewBag.MobilizationLists = mobilizationLists
                .Select(l => new
                {
                    MobilizationListId = l.Id,
                    MobilizationListName = l.ListName
                }).ToList();
            ViewBag.ServicemanList = servisemen
                .Select(s => new
                {
                    ServicemanId = s.Id,
                    ServicemanFullName = s.LastName + " " + s.FirstName + " " + s.MiddleName
                }).ToList();
        }
    }
}