using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class DocumentTemplateController : Controller
    {
        public IActionResult ApprovalResolution(DocumentFlow document)
        {
            return View(document);
        }

        public IActionResult AssignmentNotice(DocumentFlow document)
        {
            return View(document);
        }

        public IActionResult AwardRecommendation(DocumentFlow document)
        {
            return View(document);
        }

        public IActionResult DischargeOrder(DocumentFlow document)
        {
            return View(document);
        }

        public IActionResult LeaveRequest(DocumentFlow document)
        {
            return View(document);
        }

        public IActionResult MedicalCertificate(DocumentFlow document)
        {
            return View(document);
        }

        public IActionResult MobilizationList(DocumentFlow document)
        {
            return View(document);
        }

        public IActionResult OrderPersonnel(DocumentFlow document)
        {
            return View(document);
        }

        public IActionResult ServiceCertificate(DocumentFlow document)
        {
            return View(document);
        }

        public IActionResult TrainingReport(DocumentFlow document)
        {
            return View(document);
        }
    }
}
