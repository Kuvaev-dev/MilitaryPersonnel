using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MilitaryPersonnel.Controllers
{
    public class DocumentFlowController : Controller
    {
        private readonly IDocumentFlowRepository _documentFlowRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IDocumentStatusRepository _documentStatusRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public DocumentFlowController(
            IDocumentFlowRepository documentFlowRepository,
            IDocumentTypeRepository documentTypeRepository,
            IDocumentStatusRepository documentStatusesRepository,
            IServicemanRepository servicemanRepository)
        {
            _documentFlowRepository = documentFlowRepository;
            _documentTypeRepository = documentTypeRepository;
            _documentStatusRepository = documentStatusesRepository;
            _servicemanRepository = servicemanRepository;
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
                TempData["ErrorMessage"] = $"Помилка при отриманні документів: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> CreateDocumentFlow()
        {
            try
            {
                await PopulateDropdowns();
                return View(new DocumentFlow { CreatedDate = DateTime.Now });
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка при завантаженні форми: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateDocumentFlow(DocumentFlow model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.CreatedDate = DateTime.Now;
                    await _documentFlowRepository.AddDocumentFLowAsync(model);
                    TempData["SuccessMessage"] = "Документ успішно створено.";
                    return RedirectToAction("Index");
                }

                await PopulateDropdowns();
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка при створенні документа: {ex.Message}";
                await PopulateDropdowns();
                return View(model);
            }
        }

        public async Task<IActionResult> EditDocumentFlow(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    TempData["ErrorMessage"] = "Ідентифікатор документа не вказано.";
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
                TempData["ErrorMessage"] = $"Помилка при редагуванні документа: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDocumentFlow(DocumentFlow model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _documentFlowRepository.UpdateDocumentFLowAsync(model);
                    TempData["SuccessMessage"] = "Документ успішно оновлено.";
                    return RedirectToAction("Index");
                }

                await PopulateDropdowns(model);
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка при оновленні документа: {ex.Message}";
                await PopulateDropdowns(model);
                return View(model);
            }
        }

        public async Task<IActionResult> DeleteDocumentFlow(int? id)
        {
            try
            {
                if (!id.HasValue)
                {
                    TempData["ErrorMessage"] = "Ідентифікатор документа не вказано.";
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
                TempData["ErrorMessage"] = $"Помилка при видаленні документа: {ex.Message}";
                return RedirectToAction("Index");
            }
        }

        [HttpPost, ActionName("DeleteDocumentFlow")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteDocumentFlowConfirmed(int id)
        {
            try
            {
                await _documentFlowRepository.DeleteDocumentFLowAsync(id);
                TempData["SuccessMessage"] = "Документ успішно видалено.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка при видаленні документа: {ex.Message}";
                return RedirectToAction("EP500", "EP");
            }
        }

        private async Task PopulateDropdowns(DocumentFlow model = null)
        {
            var documentTypes = await _documentTypeRepository.GetAllDocumentTypesAsync();
            var documentStatuses = await _documentStatusRepository.GetAllDocumentStatusesAsync();
            var servicemen = await _servicemanRepository.GetAllServicemenAsync();

            ViewBag.DocumentTypeList = new SelectList(documentTypes, "Id", "TypeName", model?.DocumentTypeId);
            ViewBag.StatusList = new SelectList(documentStatuses, "Id", "StatusName", model?.StatusId);
            ViewBag.CreatedByList = new SelectList(
                servicemen.Select(s => new
                {
                    s.Id,
                    FullName = $"{s.LastName} {s.FirstName} {s.MiddleName}"
                }), "Id", "FullName", model?.CreatedById);
        }
    }
}