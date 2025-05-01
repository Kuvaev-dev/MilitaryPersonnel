using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Context;

namespace MilitaryPersonnel.Controllers
{
    public class ServiceHistoryController : Controller
    {
        private readonly IServiceHistoryRepository _serviceHistoryRepository;
        private readonly MilitaryPersonnelContext _context;

        public ServiceHistoryController(IServiceHistoryRepository serviceHistoryRepository, MilitaryPersonnelContext context)
        {
            _serviceHistoryRepository = serviceHistoryRepository;
            _context = context;
        }

        // GET: ServiceHistory
        public async Task<IActionResult> Index()
        {
            try
            {
                var serviceHistories = await _serviceHistoryRepository.GetAllServiceHistories();
                return View(serviceHistories);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceHistory");
            }
        }

        // GET: ServiceHistory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceHistory");

                var serviceHistory = await _serviceHistoryRepository.GetServiceHistoryById(id.Value);
                if (serviceHistory == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceHistory);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceHistory");
            }
        }

        // GET: ServiceHistory/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                ViewBag.ServicemanList = await _context.Servicemen
                    .Select(s => new
                    {
                        ServicemanId = s.Id,
                        ServicemanFullName = s.LastName + " " + s.FirstName + " " + s.MiddleName
                    })
                    .ToListAsync();

                ViewBag.PositionList = await _context.Positions
                    .Select(p => new
                    {
                        PositionId = p.Id,
                        PositionTitle = p.PositionName
                    })
                    .ToListAsync();

                ViewBag.SubdivisionList = await _context.Subdivisions
                    .Select(s => new
                    {
                        SubdivisionId = s.Id,
                        SubdivisionTitle = s.SubdivisionName
                    })
                    .ToListAsync();

                return View(new ServiceHistory());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceHistory");
            }
        }

        // POST: ServiceHistory/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ServiceHistory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceHistoryRepository.AddServiceHistory(model);
                    return RedirectToAction("Index");
                }

                ViewBag.ServicemanList = await _context.Servicemen
                    .Select(s => new
                    {
                        ServicemanId = s.Id,
                        ServicemanFullName = s.LastName + " " + s.FirstName + " " + s.MiddleName
                    })
                    .ToListAsync();

                ViewBag.PositionList = await _context.Positions
                    .Select(p => new
                    {
                        PositionId = p.Id,
                        PositionTitle = p.PositionName
                    })
                    .ToListAsync();

                ViewBag.SubdivisionList = await _context.Subdivisions
                    .Select(s => new
                    {
                        SubdivisionId = s.Id,
                        SubdivisionTitle = s.SubdivisionName
                    })
                    .ToListAsync();

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceHistory");
            }
        }

        // GET: ServiceHistory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceHistory");

                var serviceHistory = await _serviceHistoryRepository.GetServiceHistoryById(id.Value);
                if (serviceHistory == null)
                    return RedirectToAction("EP404", "EP");

                ViewBag.ServicemanList = await _context.Servicemen
                    .Select(s => new
                    {
                        ServicemanId = s.Id,
                        ServicemanFullName = s.LastName + " " + s.FirstName + " " + s.MiddleName
                    })
                    .ToListAsync();

                ViewBag.PositionList = await _context.Positions
                    .Select(p => new
                    {
                        PositionId = p.Id,
                        PositionTitle = p.PositionName
                    })
                    .ToListAsync();

                ViewBag.SubdivisionList = await _context.Subdivisions
                    .Select(s => new
                    {
                        SubdivisionId = s.Id,
                        SubdivisionTitle = s.SubdivisionName
                    })
                    .ToListAsync();

                return View(serviceHistory);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceHistory");
            }
        }

        // POST: ServiceHistory/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ServiceHistory model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _serviceHistoryRepository.UpdateServiceHistory(model);
                    return RedirectToAction("Index");
                }

                ViewBag.ServicemanList = await _context.Servicemen
                    .Select(s => new
                    {
                        ServicemanId = s.Id,
                        ServicemanFullName = s.LastName + " " + s.FirstName + " " + s.MiddleName
                    })
                    .ToListAsync();

                ViewBag.PositionList = await _context.Positions
                    .Select(p => new
                    {
                        PositionId = p.Id,
                        PositionTitle = p.PositionName
                    })
                    .ToListAsync();

                ViewBag.SubdivisionList = await _context.Subdivisions
                    .Select(s => new
                    {
                        SubdivisionId = s.Id,
                        SubdivisionTitle = s.SubdivisionName
                    })
                    .ToListAsync();

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceHistory");
            }
        }

        // GET: ServiceHistory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "ServiceHistory");

                var serviceHistory = await _serviceHistoryRepository.GetServiceHistoryById(id.Value);
                if (serviceHistory == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceHistory);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "ServiceHistory");
            }
        }

        // POST: ServiceHistory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _serviceHistoryRepository.DeleteServiceHistory(id);
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