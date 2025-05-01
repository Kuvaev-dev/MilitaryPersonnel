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
        public async Task<IActionResult> Index(int? mobilizationListId)
        {
            try
            {
                if (!mobilizationListId.HasValue)
                    return RedirectToAction("Index", "MobilizationList");

                var mobilizationList = await _mobilizationListRepository.GetMobilizationListByIdAsync(mobilizationListId.Value);
                if (mobilizationList == null)
                    return RedirectToAction("EP404", "EP");

                ViewBag.MobilizationListId = mobilizationListId.Value;
                ViewBag.MobilizationListName = mobilizationList.ListName;

                var mobilizationListEntries = await _mobilizationListEntryRepository.GetMobilizationListEntriesAsync(mobilizationListId.Value);
                return View(mobilizationListEntries);
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
        public async Task<IActionResult> Create(int? mobilizationListId)
        {
            try
            {
                if (!mobilizationListId.HasValue)
                    return RedirectToAction("Index", "MobilizationList");

                var mobilizationList = await _mobilizationListRepository.GetMobilizationListByIdAsync(mobilizationListId.Value);
                if (mobilizationList == null)
                    return RedirectToAction("EP404", "EP");

                ViewBag.MobilizationListList = await _mobilizationListRepository.GetMobilizationListsAsync();
                ViewBag.ServicemanList = await _servicemanRepository.GetAllServicemenAsync();

                var model = new MobilizationListEntry { MobilizationListId = mobilizationListId.Value };
                return View(model);
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
                    return RedirectToAction("Index", new { mobilizationListId = model.MobilizationListId });
                }

                ViewBag.MobilizationListList = await _mobilizationListRepository.GetMobilizationListsAsync();
                ViewBag.ServicemanList = await _servicemanRepository.GetAllServicemenAsync();

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
                if (!id.HasValue)
                    return RedirectToAction("Index", "MobilizationList");

                var mobilizationListEntry = await _mobilizationListEntryRepository.GetMobilizationListEntryAsync(id.Value);
                if (mobilizationListEntry == null)
                    return RedirectToAction("EP404", "EP");

                ViewBag.MobilizationListList = await _mobilizationListRepository.GetMobilizationListsAsync();
                ViewBag.ServicemanList = await _servicemanRepository.GetAllServicemenAsync();

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

                ViewBag.MobilizationListList = await _mobilizationListRepository.GetMobilizationListsAsync();
                ViewBag.ServicemanList = await _servicemanRepository.GetAllServicemenAsync();

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
                var mobilizationListEntry = await _mobilizationListEntryRepository.GetMobilizationListEntryAsync(id);
                if (mobilizationListEntry == null)
                    return RedirectToAction("EP404", "EP");

                await _mobilizationListEntryRepository.DeleteMobilizationListEntryAsync(id);
                return RedirectToAction("Index", new { mobilizationListId = mobilizationListEntry.MobilizationListId });
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("EP500", "EP");
            }
        }
    }
}