using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MilitaryPersonnel.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentFlowRepository _documentFlowRepository;
        private readonly IServicemanRepository _servicemanRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IDocumentStatusRepository _documentStatusRepository;

        public DocumentController(
            IDocumentRepository documentRepository,
            IDocumentFlowRepository documentFlowRepository,
            IServicemanRepository servicemanRepository,
            IDocumentTypeRepository documentTypeRepository,
            IDocumentStatusRepository documentStatusRepository)
        {
            _documentRepository = documentRepository;
            _documentFlowRepository = documentFlowRepository;
            _servicemanRepository = servicemanRepository;
            _documentTypeRepository = documentTypeRepository;
            _documentStatusRepository = documentStatusRepository;
        }

        private async Task PopulateDropdowns(Document? model = null)
        {
            var documentTypes = await _documentTypeRepository.GetAllDocumentTypesAsync() ?? new List<DocumentType>();
            var servicemen = await _servicemanRepository.GetAllServicemenAsync() ?? new List<Serviceman>();

            ViewBag.DocumentTypeList = new SelectList(documentTypes, "TypeName", "TypeName", model?.DocumentType);
            ViewBag.ServicemanList = new SelectList(
                servicemen.Select(s => new
                {
                    s.Id,
                    FullName = $"{s.LastName} {s.FirstName} {s.MiddleName}".Trim()
                }), "Id", "FullName", model?.ServicemanId);
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var documents = await _documentRepository.GetAllDocumentsAsync();
                return View(documents);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Document");

                var discharge = await _documentRepository.GetDocumentByIdAsync(id.Value);
                if (discharge == null)
                    return RedirectToAction("EP404", "EP");

                return View(discharge);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Document");
            }
        }

        public async Task<IActionResult> Create()
        {
            await PopulateDropdowns();
            return View(new Document());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Document model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentRepository.AddDocumentAsync(model);
                    TempData["SuccessMessage"] = "Document successfully created.";
                    return RedirectToAction("Index");
                }

                await PopulateDropdowns(model);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                await PopulateDropdowns(model);
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index");

                var document = await _documentRepository.GetDocumentByIdAsync(id.Value);
                if (document == null)
                    return NotFound();

                await PopulateDropdowns(document);
                return View(document);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Document model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentRepository.UpdateDocumentAsync(model);
                    TempData["SuccessMessage"] = "Document successfully updated.";
                    return RedirectToAction("Index");
                }
                await PopulateDropdowns(model);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                await PopulateDropdowns(model);
                return View(model);
            }
        }
    }
}