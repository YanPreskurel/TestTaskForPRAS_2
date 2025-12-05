using Microsoft.AspNetCore.Mvc;
using NewsPortal.Models;
using NewsPortal.ViewModels;

public class HomeController : BaseController
{
    private readonly IWhoWeArePageRepository _whoRepo;
    private readonly ICallToActionRepository _ctaRepo;
    private readonly ICaseRepository _caseRepo;

    public HomeController(
        IWhoWeArePageRepository whoRepo,
        ICallToActionRepository ctaRepo,
        ICaseRepository caseRepo)
    {
        _whoRepo = whoRepo;
        _ctaRepo = ctaRepo;
        _caseRepo = caseRepo;
    }

    public async Task<IActionResult> Index()
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        //  то мы
        var whoTranslation = await _whoRepo.GetPageWithTranslationAsync(lang);

        // CTA
        var ctaTranslation = await _ctaRepo.GetFirstWithTranslationAsync(lang);

        //  ейсы
        var cases = await _caseRepo.GetAllWithTranslationsAsync(lang);

        var model = new HomeViewModel
        {
            WhoWeAre = whoTranslation?.WhoWeArePage ?? new WhoWeArePage(),
            CTA = ctaTranslation!,
            Cases = cases.Select(c =>
            {
                var t = c.Translations.FirstOrDefault(tr => tr.Language == lang) ?? c.Translations.FirstOrDefault()!;
                return new CaseViewModel
                {
                    Id = c.Id,
                    Title = t.Title,
                    Country = t.Country,
                    Organization = t.Organization,
                    ShortDescription = t.ShortDescription,
                    Status = t.Status,
                    FlagImagePath = c.FlagImagePath,
                    StatusColor = c.StatusColor
                };
            }).ToList(),
            CurrentLanguage = lang
        };

        return View(model);
    }



}
