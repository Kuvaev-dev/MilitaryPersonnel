using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class MobilizationListController : Controller
    {
        private readonly IMobilizationListRepository _mobilizationListRepository;

        public MobilizationListController(IMobilizationListRepository mobilizationListRepository)
        {
            _mobilizationListRepository = mobilizationListRepository;
        }

        // GET: MobilizationList
        public async Task<IActionResult> Index()
        {
            try
            {
                var mobilizationLists = await _mobilizationListRepository.GetMobilizationListsAsync();
                return View(mobilizationLists);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // GET: MobilizationList/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MobilizationList");

                var mobilizationList = await _mobilizationListRepository.GetMobilizationListByIdAsync(id.Value);
                if (mobilizationList == null)
                    return RedirectToAction("EP404", "EP");

                return View(mobilizationList);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // GET: MobilizationList/Create
        public IActionResult Create()
        {
            return View(new MobilizationList());
        }

        // POST: MobilizationList/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MobilizationList model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mobilizationListRepository.AddMobilizationListAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // GET: MobilizationList/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MobilizationList");

                var mobilizationList = await _mobilizationListRepository.GetMobilizationListByIdAsync(id.Value);
                if (mobilizationList == null)
                    return RedirectToAction("EP404", "EP");

                return View(mobilizationList);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // POST: MobilizationList/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(MobilizationList model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _mobilizationListRepository.UpdateMobilizationListAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // GET: MobilizationList/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "MobilizationList");

                var mobilizationList = await _mobilizationListRepository.GetMobilizationListByIdAsync(id.Value);
                if (mobilizationList == null)
                    return RedirectToAction("EP404", "EP");

                return View(mobilizationList);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "MobilizationList");
            }
        }

        // POST: MobilizationList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _mobilizationListRepository.DeleteMobilizationListAsync(id);
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