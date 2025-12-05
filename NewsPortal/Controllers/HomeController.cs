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
        var lang = CurrentLanguage ?? "ru";


        // Подгружаем переводы для раздела "Кто мы"
        var whoTranslation = await _whoRepo.GetPageWithTranslationAsync(lang);

        // Подгружаем CTA
        var ctaTranslation = await _ctaRepo.GetFirstWithTranslationAsync(lang);

        // Подгружаем кейсы с переводами
        var cases = await _caseRepo.GetAllWithTranslationsAsync(lang);

        // Формируем ViewModel для HomeView
        var model = new HomeViewModel
        {
            CurrentLanguage = lang,
            WhoWeAre = whoTranslation?.WhoWeArePage ?? new WhoWeArePage(),
            CTA = ctaTranslation!,
            Cases = cases.Select(c =>
            {
                // Берем перевод текущего языка
                var translation = c.Translations.FirstOrDefault(t => t.Language == lang)
                                  ?? c.Translations.FirstOrDefault()!; // fallback

                return new CaseViewModel
                {
                    Id = c.Id,
                    Language = lang,
                    Title = translation.Title,
                    ShortDescription = translation.ShortDescription,
                    Country = translation.Country,
                    Organization = translation.Organization,
                    Status = translation.Status,
                    FlagImagePath = c.FlagImagePath,
                    StatusColor = c.StatusColor
                };
            }).ToList()
        };

        return View(model);
    }




}
