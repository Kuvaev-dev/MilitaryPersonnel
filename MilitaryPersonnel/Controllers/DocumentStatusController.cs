using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class DocumentStatusController : Controller
    {
        private readonly IDocumentStatusRepository _documentStatusRepository;

        public DocumentStatusController(IDocumentStatusRepository documentStatusRepository)
        {
            _documentStatusRepository = documentStatusRepository;
        }

        // GET: DocumentStatus
        public async Task<IActionResult> Index()
        {
            try
            {
                var documentStatuses = await _documentStatusRepository.GetAllDocumentStatusesAsync();
                return View(documentStatuses);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentStatus");
            }
        }

        // GET: DocumentStatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "DocumentStatus");

                var documentStatus = await _documentStatusRepository.GetDocumentStatusByIdAsync(id.Value);
                if (documentStatus == null)
                    return RedirectToAction("EP404", "EP");

                return View(documentStatus);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentStatus");
            }
        }

        // GET: DocumentStatus/Create
        public IActionResult Create()
        {
            return View(new DocumentStatus());
        }

        // POST: DocumentStatus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentStatus model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentStatusRepository.AddDocumentStatusAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentStatus");
            }
        }

        // GET: DocumentStatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "DocumentStatus");

                var documentStatus = await _documentStatusRepository.GetDocumentStatusByIdAsync(id.Value);
                if (documentStatus == null)
                    return RedirectToAction("EP404", "EP");

                return View(documentStatus);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentStatus");
            }
        }

        // POST: DocumentStatus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DocumentStatus model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentStatusRepository.UpdateDocumentStatusAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentStatus");
            }
        }

        // GET: DocumentStatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "DocumentStatus");

                var documentStatus = await _documentStatusRepository.GetDocumentStatusByIdAsync(id.Value);
                if (documentStatus == null)
                    return RedirectToAction("EP404", "EP");

                return View(documentStatus);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentStatus");
            }
        }

        // POST: DocumentStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _documentStatusRepository.DeleteDocumentStatusAsync(id);
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