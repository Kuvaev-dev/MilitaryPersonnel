using Domain.Models;
using Domain.RepositoryAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MilitaryPersonnel.Controllers
{
    [Authorize]
    public class ServicemanController : Controller
    {
        private readonly IServicemanRepository _servicemanRepository;
        private readonly ICivilProfessionRepository _civilProfessionRepository;
        private readonly IMilitarySpecialtyRepository _militarySpecialtyRepository;
        private readonly IEducationRepository _educationRepository;
        private readonly IPositionRepository _positionRepository;
        private readonly ISubdivisionRepository _subdivisionRepository;
        private readonly IServiceFormRepository _serviceFormRepository;
        private readonly ICharacterTraitRepository _characterTraitRepository;
        private readonly IServiceAttitudeRepository _serviceAttitudeRepository;
        private readonly IServiceStatusRepository _serviceStatusRepository;
        private readonly IFitnessCategoryRepository _fitnessCategoryRepository;

        public ServicemanController(
            IServicemanRepository servicemanRepository,
            ICivilProfessionRepository civilProfessionRepository,
            IMilitarySpecialtyRepository militarySpecialtyRepository,
            IEducationRepository educationRepository,
            IPositionRepository positionRepository,
            ISubdivisionRepository subdivisionRepository,
            IServiceFormRepository serviceFormRepository,
            ICharacterTraitRepository characterTraitRepository,
            IServiceAttitudeRepository serviceAttitudeRepository,
            IServiceStatusRepository serviceStatusRepository,
            IFitnessCategoryRepository fitnessCategoryRepository)
        {
            _servicemanRepository = servicemanRepository;
            _civilProfessionRepository = civilProfessionRepository;
            _militarySpecialtyRepository = militarySpecialtyRepository;
            _educationRepository = educationRepository;
            _positionRepository = positionRepository;
            _subdivisionRepository = subdivisionRepository;
            _serviceFormRepository = serviceFormRepository;
            _characterTraitRepository = characterTraitRepository;
            _serviceAttitudeRepository = serviceAttitudeRepository;
            _serviceStatusRepository = serviceStatusRepository;
            _fitnessCategoryRepository = fitnessCategoryRepository;
        }

        // GET: Serviceman
        public async Task<IActionResult> Index()
        {
            try
            {
                var servicemen = await _servicemanRepository.GetAllServicemenAsync();
                return View(servicemen);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Serviceman");
            }
        }

        // GET: Serviceman/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Serviceman");

                var serviceman = await _servicemanRepository.GetServicemanByIdAsync(id.Value);
                if (serviceman == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceman);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Serviceman");
            }
        }

        private async Task PopulateViewBags()
        {
            var civilProfessions = await _civilProfessionRepository.GetAllAsync();
            var miitarySpecialties = await _militarySpecialtyRepository.GetAllAsync();
            var educations = await _educationRepository.GetAllEducationsAsync();
            var positions = await _positionRepository.GetAllPositionsAsync();
            var subdivisions = await _subdivisionRepository.GetAllSubdivisionsAsync();
            var serviceForms = await _serviceFormRepository.GetAllServiceFormsAsync();
            var characterTraits = await _characterTraitRepository.GetAllCharacterTraitsAsync();
            var serviceAttitudes = await _serviceAttitudeRepository.GetAllServiceAttitudesAsync();
            var serviceStatuses = await _serviceStatusRepository.GetAllServiceStatusesAsync();
            var fitnessCategories = await _fitnessCategoryRepository.GetAllFitnessCategoriesAsync();

            ViewBag.CivilProfessionList = civilProfessions
                .Select(cp => new { CivilProfessionId = cp.Id, CivilProfession = cp.ProfessionName })
                .ToList();

            ViewBag.MilitarySpecialtyList = miitarySpecialties
                .Select(ms => new { MilitarySpecialtyId = ms.Id, MilitarySpecialty = ms.SpecialtyName })
                .ToList();

            ViewBag.EducationList = educations
                .Select(e => new { EducationId = e.Id, Education = e.Institution })
                .ToList();

            ViewBag.PositionList = positions
                .Select(p => new { PositionId = p.Id, Position = p.PositionName })
                .ToList();

            ViewBag.SubdivisionList = subdivisions
                .Select(s => new { SubdivisionId = s.Id, Subdivision = s.SubdivisionName })
                .ToList();

            ViewBag.ServiceFormList = serviceForms
                .Select(sf => new { ServiceFormId = sf.Id, ServiceForm = sf.FormName })
                .ToList();

            ViewBag.CharacterTraitList = characterTraits
                .Select(ct => new { CharacterTraitId = ct.Id, CharacterTrait = ct.TraitName })
                .ToList();

            ViewBag.ServiceAttitudeList = serviceAttitudes
                .Select(sa => new { ServiceAttitudeId = sa.Id, ServiceAttitude = sa.AttitudeDescription })
                .ToList();

            ViewBag.ServiceStatusList = serviceStatuses
                .Select(ss => new { ServiceStatusId = ss.Id, ServiceStatus = ss.StatusName })
                .ToList();

            ViewBag.FitnessCategoryList = fitnessCategories
                .Select(fc => new { FitnessCategoryId = fc.Id, FitnessCategory = fc.CategoryName })
                .ToList();
        }

        // GET: Serviceman/Create
        public async Task<IActionResult> Create()
        {
            try
            {
                await PopulateViewBags();

                return View(new Serviceman());
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Serviceman");
            }
        }

        // POST: Serviceman/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Serviceman model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _servicemanRepository.AddServicemanAsync(model);
                    return RedirectToAction("Index");
                }

                await PopulateViewBags();

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Serviceman");
            }
        }

        // GET: Serviceman/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Serviceman");

                var serviceman = await _servicemanRepository.GetServicemanByIdAsync(id.Value);
                if (serviceman == null)
                    return RedirectToAction("EP404", "EP");

                await PopulateViewBags();

                return View(serviceman);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Serviceman");
            }
        }

        // POST: Serviceman/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Serviceman model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _servicemanRepository.UpdateServicemanAsync(model);
                    return RedirectToAction("Index");
                }

                await PopulateViewBags();

                return View(model);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Serviceman");
            }
        }

        // GET: Serviceman/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                if (!id.HasValue)
                    return RedirectToAction("Index", "Serviceman");

                var serviceman = await _servicemanRepository.GetServicemanByIdAsync(id.Value);
                if (serviceman == null)
                    return RedirectToAction("EP404", "EP");

                return View(serviceman);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return RedirectToAction("Index", "Serviceman");
            }
        }

        // POST: Serviceman/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _servicemanRepository.DeleteServicemanAsync(id);
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