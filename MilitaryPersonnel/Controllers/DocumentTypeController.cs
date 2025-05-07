using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class DocumentTypeController : Controller
    {
        private readonly IDocumentTypeRepository _documentTypeRepository;

        public DocumentTypeController(IDocumentTypeRepository documentTypeRepository)
        {
            _documentTypeRepository = documentTypeRepository;
        }

        // GET: DocumentType
        public async Task<IActionResult> Index()
        {
            try
            {
                var documentTypes = await _documentTypeRepository.GetAllDocumentTypesAsync();
                return View(documentTypes);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentType");
            }
        }

        // GET: DocumentType/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "DocumentType");

                var documentType = await _documentTypeRepository.GetDocumentTypeByIdAsync(id.Value);
                if (documentType == null)
                    return RedirectToAction("EP404", "EP");

                return View(documentType);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentType");
            }
        }

        // GET: DocumentType/Create
        public IActionResult Create()
        {
            return View(new DocumentType());
        }

        // POST: DocumentType/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentType model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentTypeRepository.AddDocumentTypeAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentType");
            }
        }

        // GET: DocumentType/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "DocumentType");

                var documentType = await _documentTypeRepository.GetDocumentTypeByIdAsync(id.Value);
                if (documentType == null)
                    return RedirectToAction("EP404", "EP");

                return View(documentType);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentType");
            }
        }

        // POST: DocumentType/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DocumentType model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentTypeRepository.UpdateDocumentTypeAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentType");
            }
        }

        // GET: DocumentType/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "DocumentType");

                var documentType = await _documentTypeRepository.GetDocumentTypeByIdAsync(id.Value);
                if (documentType == null)
                    return RedirectToAction("EP404", "EP");

                return View(documentType);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "DocumentType");
            }
        }

        // POST: DocumentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _documentTypeRepository.DeleteDocumentTypeAsync(id);
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