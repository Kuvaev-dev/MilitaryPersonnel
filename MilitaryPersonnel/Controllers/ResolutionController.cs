using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class ResolutionController : Controller
    {
        private readonly IResolutionRepository _resolutionRepository;
        private readonly IDocumentFlowRepository _documentFlowRepository;
        private readonly IServicemanRepository _servicemanRepository;

        public ResolutionController(
            IResolutionRepository resolutionRepository,
            IDocumentFlowRepository documentFlowRepository,
            IServicemanRepository servicemanRepository)
        {
            _resolutionRepository = resolutionRepository;
            _documentFlowRepository = documentFlowRepository;
            _servicemanRepository = servicemanRepository;
        }

        // GET: Resolution
        public async Task<IActionResult> Index()
        {
            try
            {
                var resolutions = await _resolutionRepository.GetAllResolutionsAsync();
                return View(resolutions);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Resolution");
            }
        }

        // GET: Resolution/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Resolution");

                var resolution = await _resolutionRepository.GetResolutionByIdAsync(id.Value);
                if (resolution == null)
                    return RedirectToAction("EP404", "EP");

                return View(resolution);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Resolution");
            }
        }

        private async Task PopulateViewBag()
        {
            var documentFlows = await _documentFlowRepository.GetAllDocumentFLowsAsync();
            var authors = await _servicemanRepository.GetAllServicemenAsync();

            ViewBag.DocumentList = documentFlows
                .Select(d => new
                {
                    DocumentFlowId = d.Id,
                    DocumentFlowTitle = d.Title
                }).ToList();

            ViewBag.AuthorList = authors
                .Select(s => new
                {
                    AuthorId = s.Id,
                    AuthorFullName = s.LastName + " " + s.FirstName + " " + s.MiddleName
                }).ToList();
        }

        // GET: Resolution/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                await PopulateViewBag();

                return View(new Resolution());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Resolution");
            }
        }

        // POST: Resolution/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Resolution model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _resolutionRepository.AddResolutionAsync(model);
                    return RedirectToAction("Index");
                }

                await PopulateViewBag();

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Resolution");
            }
        }

        // GET: Resolution/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Resolution");

                var resolution = await _resolutionRepository.GetResolutionByIdAsync(id.Value);
                if (resolution == null)
                    return RedirectToAction("EP404", "EP");

                await PopulateViewBag();

                return View(resolution);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Resolution");
            }
        }

        // POST: Resolution/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Resolution model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _resolutionRepository.UpdateResolutionAsync(model);
                    return RedirectToAction("Index");
                }

                await PopulateViewBag();

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Resolution");
            }
        }

        // GET: Resolution/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Resolution");

                var resolution = await _resolutionRepository.GetResolutionByIdAsync(id.Value);
                if (resolution == null)
                    return RedirectToAction("EP404", "EP");

                return View(resolution);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Resolution");
            }
        }

        // POST: Resolution/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _resolutionRepository.DeleteResolutionAsync(id);
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