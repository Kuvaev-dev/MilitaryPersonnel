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

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index");

                var document = await _documentRepository.GetDocumentByIdAsync(id.Value);
                if (document == null)
                    return NotFound();

                return View(document);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _documentRepository.DeleteDocumentAsync(id);
                TempData["SuccessMessage"] = "Document successfully deleted.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Print(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index");

                var document = await _documentRepository.GetDocumentByIdAsync(id.Value);
                if (document == null)
                    return NotFound();

                var model = await _documentFlowRepository.GetDocumentFLowByServicemanIdAsync(document.ServicemanId);
                if (model == null)
                    return NotFound();

                return document.DocumentType switch
                {
                    "Резолюція про затвердження" => View("ApprovalResolution", model),
                    "Повідомлення про призначення" => View("AssignmentNotice", model),
                    "Подання на нагородження" => View("AwardRecommendation", model),
                    "Наказ про звільнення" => View("DischargeOrder", model),
                    "Заява на відпустку" => View("LeaveRequest", model),
                    "Медична довідка" => View("MedicalCertificate", model),
                    "Список мобілізації" => View("MobilizationList", model),
                    "Наказ щодо особового складу" => View("OrderPersonnel", model),
                    "Посвідчення про вислугу" => View("ServiceCertificate", model),
                    "Звіт про навчання" => View("TrainingReport", model),
                    _ => NotFound()
                };
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}