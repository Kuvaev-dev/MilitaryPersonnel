using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.VisualBasic;

namespace MilitaryPersonnel.Controllers
{
    public class DocumentFlowController : Controller
    {
        private readonly IDocumentFlowRepository _documentFlowRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IDocumentStatusRepository _documentStatusRepository;
        private readonly IMilitaryUnitRepository _militaryUnitRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public DocumentFlowController(
            IDocumentFlowRepository documentFlowRepository,
            IDocumentTypeRepository documentTypeRepository,
            IDocumentStatusRepository documentStatusRepository,
            IServicemanRepository servicemanRepository,
            IMilitaryUnitRepository militaryUnitRepository)
        {
            _documentFlowRepository = documentFlowRepository;
            _documentTypeRepository = documentTypeRepository;
            _documentStatusRepository = documentStatusRepository;
            _servicemanRepository = servicemanRepository;
            _militaryUnitRepository = militaryUnitRepository;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var documentFlows = await _documentFlowRepository.GetAllDocumentFLowsAsync();
                return View(documentFlows);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error retrieving documents: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Document");

                var documentFlow = await _documentFlowRepository.GetDocumentFLowByIdAsync(id.Value);
                if (documentFlow == null)
                    return RedirectToAction("EP404", "EP");

                return View(documentFlow);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Document");
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                await PopulateDropdowns();
                return View(new DocumentFlow { CreatedDate = DateTime.Now });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error loading form: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DocumentFlow model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;
                    var newId = await _documentFlowRepository.AddDocumentFLowAsync(model);
                    var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                        ?.FirstOrDefault(dt => dt.Id == model.DocumentTypeId);
                    TempData["SuccessMessage"] = "Document successfully created.";
                    return RedirectToAction("Index");
                }

                await PopulateDropdowns(model);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error creating document: {ex.Message}";
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    TempData["ErrorMessage"] = "Document identifier not specified.";
                    return RedirectToAction("Index");
                }

                var documentFlow = await _documentFlowRepository.GetDocumentFLowByIdAsync(id.Value);
                if (documentFlow == null)
                {
                    return RedirectToAction("EP404", "EP");
                }

                await PopulateDropdowns(documentFlow);
                return View(documentFlow);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error editing document: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DocumentFlow model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentFlowRepository.UpdateDocumentFLowAsync(model);
                    TempData["SuccessMessage"] = "Document successfully updated.";
                    return RedirectToAction("Index");
                }

                await PopulateDropdowns(model);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error updating document: {ex.Message}";
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    TempData["ErrorMessage"] = "Document identifier not specified.";
                    return RedirectToAction("Index");
                }

                var documentFlow = await _documentFlowRepository.GetDocumentFLowByIdAsync(id.Value);
                if (documentFlow == null)
                {
                    return RedirectToAction("EP404", "EP");
                }

                return View(documentFlow);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting document: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _documentFlowRepository.DeleteDocumentFLowAsync(id);
                TempData["SuccessMessage"] = "Document successfully deleted.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error deleting document: {ex.Message}";
                return RedirectToAction("EP500", "EP");
            }
        }

        public async Task<IActionResult> Print(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index");

                var model = await _documentFlowRepository.GetDocumentFLowByIdAsync(id.Value);
                if (model == null)
                    return NotFound();

                return model.DocumentType switch
                {
                    "Резолюція про затвердження" => RedirectToAction("ApprovalResolution", "DocumentTemplate", model),
                    "Повідомлення про призначення" => RedirectToAction("AssignmentNotice", "DocumentTemplate", model),
                    "Подання на нагородження" => RedirectToAction("AwardRecommendation", "DocumentTemplate", model),
                    "Наказ про звільнення" => RedirectToAction("DischargeOrder", "DocumentTemplate", model),
                    "Заява на відпустку" => RedirectToAction("LeaveRequest", "DocumentTemplate", model),
                    "Медична довідка" => RedirectToAction("MedicalCertificate", "DocumentTemplate", model),
                    "Список мобілізації" => RedirectToAction("MobilizationList", "DocumentTemplate", model),
                    "Наказ щодо особового складу" => RedirectToAction("OrderPersonnel", "DocumentTemplate", model),
                    "Посвідчення про вислугу" => RedirectToAction("ServiceCertificate", "DocumentTemplate", model),
                    "Звіт про навчання" => RedirectToAction("TrainingReport", "DocumentTemplate", model),
                    _ => NotFound()
                };
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Error: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        private async Task PopulateDropdowns(DocumentFlow? model = null)
        {
            var documentTypes = await _documentTypeRepository.GetAllDocumentTypesAsync() ?? new List<DocumentType>();
            var documentStatuses = await _documentStatusRepository.GetAllDocumentStatusesAsync() ?? new List<DocumentStatus>();
            var servicemen = await _servicemanRepository.GetAllServicemenAsync() ?? new List<Serviceman>();
            var militaryUnits = await _militaryUnitRepository.GetAllMilitaryUnitsAsync() ?? new List<MilitaryUnit>();

            ViewBag.DocumentTypeList = new SelectList(documentTypes, "Id", "TypeName", model?.DocumentTypeId);
            ViewBag.StatusList = new SelectList(documentStatuses, "Id", "StatusName", model?.StatusId);
            ViewBag.MilitaryUnitList = new SelectList(militaryUnits, "Id", "UnitName", model?.MilitaryUnitId);
            ViewBag.CreatedByList = new SelectList(
                servicemen.Select(s => new
                {
                    s.Id,
                    FullName = $"{s.LastName} {s.FirstName} {s.MiddleName}"
                }), "Id", "FullName", model?.CreatedById);
            ViewBag.ServicemanList = new SelectList(
                servicemen.Select(s => new
                {
                    s.Id,
                    FullName = $"{s.LastName} {s.FirstName} {s.MiddleName}"
                }), "Id", "FullName", model?.ServicemanId);
        }
    }
}