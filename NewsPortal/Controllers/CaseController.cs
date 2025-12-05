using Microsoft.AspNetCore.Mvc;
using NewsPortal.Interfaces;
using NewsPortal.ViewModels;

public class CaseController : BaseController
{
    private readonly ICaseRepository _caseRepo;
    private readonly ICaseDocumentRepository _docRepo;
    private readonly ITagRepository _tagRepo;
    private readonly ILawyerRepository _lawyerRepo;
    private readonly ICaseNoteRepository _noteRepo;
    private readonly ICallToActionRepository _ctaRepo; 

    public CaseController(
        ICaseRepository caseRepo,
        ICaseDocumentRepository docRepo,
        ITagRepository tagRepo,
        ILawyerRepository lawyerRepo,
        ICaseNoteRepository noteRepo,
        ICallToActionRepository ctaRepo)
    {
        _caseRepo = caseRepo;
        _docRepo = docRepo;
        _tagRepo = tagRepo;
        _lawyerRepo = lawyerRepo;
        _noteRepo = noteRepo;
        _ctaRepo = ctaRepo;
    }

    public async Task<IActionResult> Details(int id)
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        var item = await _caseRepo.GetByIdWithTranslationsAsync(id);
        if (item == null)
            return NotFound();

        ViewBag.Documents = await _docRepo.GetAllWithTranslationsAsync();
        ViewBag.Tags = await _tagRepo.GetAllWithTranslationsAsync(lang);
        ViewBag.Lawyers = await _lawyerRepo.GetAllWithTranslationsAsync();
        ViewBag.Notes = await _noteRepo.GetAllWithTranslationsAsync();
        ViewBag.Cases = await _caseRepo.GetAllWithTranslationsAsync(lang);
        ViewBag.CTA = await _ctaRepo.GetFirstWithTranslationAsync(lang);

        ViewBag.Lang = lang;

        return View(item);
    }

    public async Task<IActionResult> Index()
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        var cases = await _caseRepo.GetAllWithTranslationsAsync(lang);

        // Преобразуем модели Case в CaseViewModel
        var caseViewModels = cases.Select(c => new CaseViewModel
        {
            Id = c.Id,
            Title = c.Translations.FirstOrDefault(t => t.Language == lang)?.Title ?? "",
            Country = c.Translations.FirstOrDefault(t => t.Language == lang)?.Country ?? "",
            Organization = c.Translations.FirstOrDefault(t => t.Language == lang)?.Organization ?? "",
            ShortDescription = c.Translations.FirstOrDefault(t => t.Language == lang)?.ShortDescription ?? "",
            Status = c.Translations.FirstOrDefault(t => t.Language == lang)?.Status ?? "",
            FlagImagePath = c.FlagImagePath,
            StatusColor = c.StatusColor
        }).ToList();

        ViewBag.Lang = lang;
        return View(caseViewModels); // Передаем список ViewModel в представление
    }
}
