using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MilitaryPersonnel.Extensions;
using DinkToPdf;
using DinkToPdf.Contracts;

namespace MilitaryPersonnel.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IDocumentFlowRepository _documentFlowRepository;
        private readonly IServicemanRepository _servicemanRepository;
        private readonly IDocumentTypeRepository _documentTypeRepository;
        private readonly IDocumentStatusRepository _documentStatusRepository;
        private readonly IConverter _pdfConverter;

        public DocumentController(
            IDocumentRepository documentRepository,
            IServicemanRepository servicemanRepository,
            IDocumentFlowRepository documentFlowRepository,
            IDocumentTypeRepository documentTypeRepository,
            IDocumentStatusRepository documentStatusRepository,
            IConverter pdfConverter)
        {
            _documentRepository = documentRepository;
            _servicemanRepository = servicemanRepository;
            _documentFlowRepository = documentFlowRepository;
            _documentTypeRepository = documentTypeRepository;
            _documentStatusRepository = documentStatusRepository;
            _pdfConverter = pdfConverter;
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

        public async Task<IActionResult> Index()
        {
            try
            {
                var documents = await _documentRepository.GetAllDocumentsAsync();
                return View(documents);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка: {ex.Message}";
                return RedirectToAction("Index", "Document");
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Document");

                var document = await _documentRepository.GetDocumentByIdAsync(id.Value);
                if (document == null)
                    return RedirectToAction("EP404", "EP");

                return View(document);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка: {ex.Message}";
                return RedirectToAction("Index", "Document");
            }
        }

        public async Task<IActionResult> Create()
        {
            var servicemen = await _servicemanRepository.GetAllServicemenAsync();
            ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = $"{s.FirstName} {s.LastName} {s.MiddleName}" });
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
                    TempData["SuccessMessage"] = "Документ успішно створено.";
                    return RedirectToAction("Index");
                }
                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = $"{s.FirstName} {s.LastName} {s.MiddleName}" });
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка: {ex.Message}";
                return RedirectToAction("Index", "Document");
            }
        }

        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Document");

                var document = await _documentRepository.GetDocumentByIdAsync(id.Value);
                if (document == null)
                    return RedirectToAction("EP404", "EP");

                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = $"{s.FirstName} {s.LastName} {s.MiddleName}" });
                return View(document);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка: {ex.Message}";
                return RedirectToAction("Index", "Document");
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
                    TempData["SuccessMessage"] = "Документ успішно оновлено.";
                    return RedirectToAction("Index");
                }
                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                ViewBag.ServicemanList = servicemen.Select(s => new { ServicemanId = s.Id, ServicemanFullName = $"{s.FirstName} {s.LastName} {s.MiddleName}" });
                return View(model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка: {ex.Message}";
                return RedirectToAction("Index", "Document");
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Document");

                var document = await _documentRepository.GetDocumentByIdAsync(id.Value);
                if (document == null)
                    return RedirectToAction("EP404", "EP");

                return View(document);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка: {ex.Message}";
                return RedirectToAction("Index", "Document");
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _documentRepository.DeleteDocumentAsync(id);
                TempData["SuccessMessage"] = "Документ успішно видалено.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка: {ex.Message}";
                return RedirectToAction("EP500", "EP");
            }
        }

        public async Task<IActionResult> CreateApprovalResolution()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Approval Resolution");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Затвердити запропоновані зміни до [вкажіть деталі]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
        }

        public async Task<IActionResult> CreateAssignmentNotice()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Assignment Notice");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Призначити [вкажіть особу] на посаду [вкажіть посаду]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
        }

        public async Task<IActionResult> CreateAwardRecommendation()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Award Recommendation");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Рекомендувати [вкажіть особу] до нагородження [вкажіть нагороду] за [вкажіть заслуги]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
        }

        public async Task<IActionResult> CreateDischargeOrder()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Discharge Order");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Звільнити [вкажіть особу] з військової служби з [вкажіть дату] за [вкажіть причину]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
        }

        public async Task<IActionResult> CreateLeaveRequest()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Leave Request");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Прошу надати відпустку з [вкажіть дату початку] по [вкажіть дату закінчення]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
        }

        public async Task<IActionResult> CreateMedicalCertificate()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Medical Certificate");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Довідка про стан здоров’я [вкажіть особу]: [вкажіть медичні дані]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
        }

        public async Task<IActionResult> CreateMobilizationList()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Mobilization List");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Список осіб для мобілізації: [вкажіть перелік осіб]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
        }

        public async Task<IActionResult> CreateOrderPersonnel()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Order Personnel");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Наказ щодо особового складу: [вкажіть деталі]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
        }

        public async Task<IActionResult> CreateServiceCertificate()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Service Certificate");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Посвідчення про вислугу [вкажіть особу]: [вкажіть деталі служби]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
        }

        public async Task<IActionResult> CreateTrainingReport()
        {
            var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                .FirstOrDefault(dt => dt.TypeName == "Training Report");
            var defaultStatus = (await _documentStatusRepository.GetAllDocumentStatusesAsync())
                .FirstOrDefault(ds => ds.StatusName == "Draft");
            var model = new DocumentFlow
            {
                CreatedDate = DateTime.Now,
                DocumentTypeId = documentType?.Id ?? 0,
                StatusId = defaultStatus?.Id ?? 0,
                Content = "Звіт про проведення навчання: [вкажіть деталі]."
            };
            await PopulateDropdowns(model);
            return View("CreateDocumentFlow", model);
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
                    var documentType = (await _documentTypeRepository.GetAllDocumentTypesAsync())
                        .FirstOrDefault(dt => dt.Id == model.DocumentTypeId);
                    TempData["SuccessMessage"] = "Документ успішно створено.";
                    return RedirectToAction("RenderDocument", new { id = model.Id, type = documentType?.TypeName });
                }

                await PopulateDropdowns(model);
                return View("CreateDocumentFlow", model);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка при створенні документа: {ex.Message}";
                await PopulateDropdowns(model);
                return View("CreateDocumentFlow", model);
            }
        }

        public async Task<IActionResult> RenderDocument(int? id, string type)
        {
            try
            {
                if (!id.HasValue || string.IsNullOrEmpty(type))
                {
                    TempData["ErrorMessage"] = "Ідентифікатор документа або тип не вказано.";
                    return RedirectToAction("Index", "DocumentFlow");
                }

                var documentFlow = await _documentFlowRepository.GetDocumentFLowByIdAsync(id.Value);
                if (documentFlow == null)
                {
                    return RedirectToAction("EP404", "EP");
                }

                var createdBy = await _servicemanRepository.GetServicemanByIdAsync(documentFlow.CreatedById);
                documentFlow.CreatedBy = createdBy.LastName + " " + createdBy.FirstName + " " + createdBy.MiddleName;

                switch (type)
                {
                    case "Order Personnel":
                        return View("OrderPersonnel", documentFlow);
                    case "Service Certificate":
                        return View("ServiceCertificate", documentFlow);
                    case "Leave Request":
                        return View("LeaveRequest", documentFlow);
                    case "Training Report":
                        return View("TrainingReport", documentFlow);
                    case "Medical Certificate":
                        return View("MedicalCertificate", documentFlow);
                    case "Discharge Order":
                        return View("DischargeOrder", documentFlow);
                    case "Award Recommendation":
                        return View("AwardRecommendation", documentFlow);
                    case "Mobilization List":
                        return View("MobilizationList", documentFlow);
                    case "Assignment Notice":
                        return View("AssignmentNotice", documentFlow);
                    case "Approval Resolution":
                        return View("ApprovalResolution", documentFlow);
                    default:
                        return RedirectToAction("EP404", "EP");
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка при відображенні документа: {ex.Message}";
                return RedirectToAction("Index", "DocumentFlow");
            }
        }

        public async Task<IActionResult> RenderDocumentAsPdf(int? id, string type)
        {
            try
            {
                if (!id.HasValue || string.IsNullOrEmpty(type))
                {
                    TempData["ErrorMessage"] = "Ідентифікатор документа або тип не вказано.";
                    return RedirectToAction("Index", "DocumentFlow");
                }

                var documentFlow = await _documentFlowRepository.GetDocumentFLowByIdAsync(id.Value);
                if (documentFlow == null)
                {
                    TempData["ErrorMessage"] = "Документ не знайдено.";
                    return RedirectToAction("EP404", "EP");
                }

                var createdBy = await _servicemanRepository.GetServicemanByIdAsync(documentFlow.CreatedById);
                documentFlow.CreatedBy = createdBy.LastName + " " + createdBy.FirstName + " " + createdBy.MiddleName;

                string viewName;
                switch (type)
                {
                    case "Order Personnel":
                        viewName = "OrderPersonnel";
                        break;
                    case "Service Certificate":
                        viewName = "ServiceCertificate";
                        break;
                    case "Leave Request":
                        viewName = "LeaveRequest";
                        break;
                    case "Training Report":
                        viewName = "TrainingReport";
                        break;
                    case "Medical Certificate":
                        viewName = "MedicalCertificate";
                        break;
                    case "Discharge Order":
                        viewName = "DischargeOrder";
                        break;
                    case "Award Recommendation":
                        viewName = "AwardRecommendation";
                        break;
                    case "Mobilization List":
                        viewName = "MobilizationList";
                        break;
                    case "Assignment Notice":
                        viewName = "AssignmentNotice";
                        break;
                    case "Approval Resolution":
                        viewName = "ApprovalResolution";
                        break;
                    default:
                        TempData["ErrorMessage"] = "Невірний тип документа.";
                        return RedirectToAction("EP404", "EP");
                }

                var htmlContent = await this.RenderViewToStringAsync(viewName, documentFlow);

                var pdfDocument = new HtmlToPdfDocument
                {
                    GlobalSettings = new GlobalSettings
                    {
                        PaperSize = PaperKind.A4,
                        Orientation = Orientation.Portrait,
                        Margins = new MarginSettings { Top = 20, Bottom = 20, Left = 30, Right = 10 },
                        DocumentTitle = documentFlow.Title
                    },
                    Objects = {
                        new ObjectSettings
                        {
                            HtmlContent = htmlContent,
                            WebSettings = { DefaultEncoding = "utf-8" },
                            HeaderSettings = { FontName = "Times New Roman", FontSize = 10, Right = "Сторінка [page] з [toPage]" },
                            FooterSettings = { FontName = "Times New Roman", FontSize = 10, Center = "Військова частина А1234" }
                        }
                    }
                };

                var pdfBytes = _pdfConverter.Convert(pdfDocument);
                var fileName = $"Document_{id}_{type}.pdf";
                return File(pdfBytes, "application/pdf", fileName);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Помилка при генерації PDF: {ex.Message}";
                return RedirectToAction("Index", "DocumentFlow");
            }
        }
    }
}