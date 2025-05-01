using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class ServiceFormController : Controller
    {
        private readonly IServiceFormRepository _serviceFormRepository;

        public ServiceFormController(IServiceFormRepository serviceFormRepository)
        {
            _serviceFormRepository = serviceFormRepository;
        }

        // GET: ServiceForm
        public async Task<IActionResult> Index()
        {
            try
            {
                var serviceForms = await _serviceFormRepository.GetAllServiceFormsAsync();
                return View(serviceForms);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceForm");
            }
        }

        // GET: ServiceForm/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceForm");

                var serviceForm = await _serviceFormRepository.GetServiceFormByIdAsync(id.Value);
                if (serviceForm == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceForm);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceForm");
            }
        }

        // GET: ServiceForm/Create
        public IActionResult Create()
        {
            return View(new ServiceForm());
        }

        // POST: ServiceForm/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceForm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceFormRepository.AddServiceFormAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceForm");
            }
        }

        // GET: ServiceForm/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceForm");

                var serviceForm = await _serviceFormRepository.GetServiceFormByIdAsync(id.Value);
                if (serviceForm == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceForm);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceForm");
            }
        }

        // POST: ServiceForm/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceForm model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceFormRepository.UpdateServiceFormAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceForm");
            }
        }

        // GET: ServiceForm/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceForm");

                var serviceForm = await _serviceFormRepository.GetServiceFormByIdAsync(id.Value);
                if (serviceForm == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceForm);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceForm");
            }
        }

        // POST: ServiceForm/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _serviceFormRepository.DeleteServiceFormAsync(id);
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