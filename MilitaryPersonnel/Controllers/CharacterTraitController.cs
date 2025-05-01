using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    public class CharacterTraitController : Controller
    {
        private readonly ICharacterTraitRepository _characterTraitRepository;

        public CharacterTraitController(ICharacterTraitRepository characterTraitRepository)
        {
            _characterTraitRepository = characterTraitRepository;
        }

        // GET: CharacterTrait
        public async Task<IActionResult> Index()
        {
            try
            {
                var characterTraits = await _characterTraitRepository.GetAllCharacterTraitsAsync();
                return View(characterTraits);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CharacterTrait");
            }
        }

        // GET: CharacterTrait/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "CharacterTrait");

                var characterTrait = await _characterTraitRepository.GetCharacterTraitByIdAsync(id.Value);
                if (characterTrait == null)
                    return RedirectToAction("EP404", "EP");

                return View(characterTrait);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CharacterTrait");
            }
        }

        // GET: CharacterTrait/Create
        public IActionResult Create()
        {
            return View(new CharacterTrait());
        }

        // POST: CharacterTrait/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CharacterTrait model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _characterTraitRepository.AddCharacterTraitAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CharacterTrait");
            }
        }

        // GET: CharacterTrait/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "CharacterTrait");

                var characterTrait = await _characterTraitRepository.GetCharacterTraitByIdAsync(id.Value);
                if (characterTrait == null)
                    return RedirectToAction("EP404", "EP");

                return View(characterTrait);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CharacterTrait");
            }
        }

        // POST: CharacterTrait/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CharacterTrait model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _characterTraitRepository.UpdateCharacterTraitAsync(model);
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CharacterTrait");
            }
        }

        // GET: CharacterTrait/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "CharacterTrait");

                var characterTrait = await _characterTraitRepository.GetCharacterTraitByIdAsync(id.Value);
                if (characterTrait == null)
                    return RedirectToAction("EP404", "EP");

                return View(characterTrait);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "CharacterTrait");
            }
        }

        // POST: CharacterTrait/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _characterTraitRepository.DeleteCharacterTraitAsync(id);
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