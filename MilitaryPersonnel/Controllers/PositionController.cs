using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class PositionController : Controller
    {
        private readonly IPositionRepository _positionRepository;

        public PositionController(IPositionRepository positionRepository)
        {
            _positionRepository = positionRepository;
        }

        // GET: Position
        public async Task<IActionResult> Index()
        {
            try
            {
                var positions = await _positionRepository.GetAllPositionsAsync();
                return View(positions);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Position");
            }
        }

        // GET: Position/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Position");

                var position = await _positionRepository.GetPositionByIdAsync(id.Value);
                if (position == null)
                    return RedirectToAction("EP404", "EP");

                return View(position);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Position");
            }
        }

        // GET: Position/Create
        public IActionResult Create()
        {
            return View(new Position());
        }

        // POST: Position/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Position model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _positionRepository.AddPositionAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Position");
            }
        }

        // GET: Position/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Position");

                var position = await _positionRepository.GetPositionByIdAsync(id.Value);
                if (position == null)
                    return RedirectToAction("EP404", "EP");

                return View(position);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Position");
            }
        }

        // POST: Position/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Position model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _positionRepository.UpdatePositionAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Position");
            }
        }

        // GET: Position/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Position");

                var position = await _positionRepository.GetPositionByIdAsync(id.Value);
                if (position == null)
                    return RedirectToAction("EP404", "EP");

                return View(position);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Position");
            }
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _positionRepository.DeletePositionAsync(id);
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