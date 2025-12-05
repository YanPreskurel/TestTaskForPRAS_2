using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Models;
using NewsPortal.Repositories;
using NewsPortal.ViewModels;

public class AdminController : BaseController
{
    private readonly IWhoWeArePageRepository _whoRepo;
    private readonly ICaseRepository _caseRepo;
    private readonly ICallToActionRepository _ctaRepo;

    public AdminController(
        IWhoWeArePageRepository whoRepo,
        ICaseRepository caseRepo,
        ICallToActionRepository ctaRepo)
    {
        _whoRepo = whoRepo;
        _caseRepo = caseRepo;
        _ctaRepo = ctaRepo;
    }

    public async Task<IActionResult> Index()
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        // О НАС
        var whoWeAreTranslation = await _whoRepo.GetPageWithTranslationAsync(lang);

        // Кейсы
        var cases = await _caseRepo.GetAllWithTranslationsAsync(lang);

        // CTA
        var ctaTranslation = await _ctaRepo.GetFirstWithTranslationAsync(lang);

        ViewBag.WhoWeAre = whoWeAreTranslation;
        ViewBag.Cases = cases;
        ViewBag.CTA = ctaTranslation;

        return View();
    }


    // ========== EDIT WHO WE ARE PAGE ==========

    public async Task<IActionResult> EditWhoWeAre(int id = 1, string lang = "ru")
    {
        var pageTranslation = await _whoRepo.GetPageWithTranslationAsync(lang);

        if (pageTranslation == null)
            return NotFound();

        return View(pageTranslation);
    }

    [HttpPost]
    public async Task<IActionResult> EditWhoWeAre(int id, string lang, WhoWeArePageTranslation model)
    {
        await _whoRepo.UpdateTranslationAsync(id, lang, model);
        return RedirectToAction(nameof(EditWhoWeAre));
    }


    // ========== LOGOUT ==========

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout(string returnUrl = "/")
    {
        await HttpContext.SignOutAsync("AdminCookie");
        return LocalRedirect(returnUrl);
    }


    // ========== CTA ==========

    // GET
    public async Task<IActionResult> EditCTA(int id = 1)
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        // Получаем сразу нужный перевод
        var translation = await _ctaRepo.GetFirstWithTranslationAsync(lang);

        if (translation == null) return NotFound();

        return View(translation);
    }

    // POST
    [HttpPost]
    public async Task<IActionResult> EditCTA(int id, string lang, CallToActionBlockTranslation model)
    {
        await _ctaRepo.UpdateTranslationAsync(id, lang, model);
        return RedirectToAction("Index");
    }


    public IActionResult Create()
    {
        return View(new CaseViewModel());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(IFormCollection form)
    {
        var newCase = new Case
        {
            FlagImagePath = form["FlagImagePath"].ToString() ?? "",
    StatusColor = form["StatusColor"].ToString() ?? "#000000"
        };

        // --- Русский перевод ---
        var ruTranslation = new CaseTranslation
        {
            Language = "ru",
            Title = form["Title_ru"],
            ShortDescription = form["ShortDescription_ru"],
            Country = form["Country_ru"],
            Organization = form["Organization_ru"],
            Status = form["Status_ru"],
            CaseFullDescription = new CaseFullDescription
            {
                MessageNumber = form["FullDescription_MessageNumber_ru"],
                Paragraph1 = form["FullDescription_Paragraph1_ru"],
                // Добавьте остальные поля для русского
            }
        };

        // --- Английский перевод ---
        var enTranslation = new CaseTranslation
        {
            Language = "en",
            Title = form["Title_en"],
            ShortDescription = form["ShortDescription_en"],
            Country = form["Country_en"],
            Organization = form["Organization_en"],
            Status = form["Status_en"],
            CaseFullDescription = new CaseFullDescription
            {
                MessageNumber = form["FullDescription_MessageNumber_en"],
                Paragraph1 = form["FullDescription_Paragraph1_en"],
                // Добавьте остальные поля для английского
            }
        };

        newCase.Translations.Add(ruTranslation);
        newCase.Translations.Add(enTranslation);

        await _caseRepo.AddAsync(newCase);

        return RedirectToAction("Index", "Case");
    }


    // =================== Edit ===================
    public async Task<IActionResult> Edit(int id, string lang = "ru")
    {
        var c = await _caseRepo.GetByIdWithTranslationsAsync(id);
        if (c == null) return NotFound();

        var ruTranslation = c.Translations.FirstOrDefault(t => t.Language == "ru");
        var enTranslation = c.Translations.FirstOrDefault(t => t.Language == "en");

        var model = new CaseViewModel
        {
            Id = c.Id,
            FlagImagePath = c.FlagImagePath,
            StatusColor = c.StatusColor,
            RU = ruTranslation != null ? new CaseTranslationViewModel
            {
                Title = ruTranslation.Title,
                ShortDescription = ruTranslation.ShortDescription,
                Country = ruTranslation.Country,
                Organization = ruTranslation.Organization,
                Status = ruTranslation.Status,
                FullDescription = MapFullDescription(ruTranslation.CaseFullDescription)
            } : new CaseTranslationViewModel(),
            EN = enTranslation != null ? new CaseTranslationViewModel
            {
                Title = enTranslation.Title,
                ShortDescription = enTranslation.ShortDescription,
                Country = enTranslation.Country,
                Organization = enTranslation.Organization,
                Status = enTranslation.Status,
                FullDescription = MapFullDescription(enTranslation.CaseFullDescription)
            } : new CaseTranslationViewModel()
        };

        return View(model);
    }

    private CaseFullDescriptionViewModel MapFullDescription(CaseFullDescription entity)
    {
        if (entity == null) return new CaseFullDescriptionViewModel();

        return new CaseFullDescriptionViewModel
        {
            MessageNumber = entity.MessageNumber,
            Paragraph1 = entity.Paragraph1,
            Paragraph2 = entity.Paragraph2,
            Paragraph3 = entity.Paragraph3,
            StatusText = entity.StatusText,
            CaseType = entity.CaseType,
            Section1Title = entity.Section1Title,
            Section1Text = entity.Section1Text,
            Quote = entity.Quote,
            Note1 = entity.Note1,
            Section2Title = entity.Section2Title,
            Section2Text = entity.Section2Text,
            ListTitle = entity.ListTitle,
            ListItems = entity.ListItems,
            Note2 = entity.Note2,
            Note3 = entity.Note3,
            DecisionTitle = entity.DecisionTitle,
            DecisionText = entity.DecisionText,
            DecisionLink = entity.DecisionLink
        };
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(CaseViewModel model)
    {
        var c = await _caseRepo.GetByIdWithTranslationsAsync(model.Id);
        if (c == null) return NotFound();

        // Обновляем поля сущности на основе того, что прислал пользователь
        c.FlagImagePath = model.FlagImagePath;
        c.StatusColor = model.StatusColor;

        // RU перевод
        var ruTranslation = c.Translations.FirstOrDefault(t => t.Language == "ru");
        if (ruTranslation != null)
        {
            ruTranslation.Title = model.RU.Title;
            ruTranslation.ShortDescription = model.RU.ShortDescription;
            ruTranslation.Country = model.RU.Country;
            ruTranslation.Organization = model.RU.Organization;
            ruTranslation.Status = model.RU.Status;
            ruTranslation.CaseFullDescription = MapFullDescription(model.RU.FullDescription, ruTranslation.CaseFullDescription);
        }

        // EN перевод
        var enTranslation = c.Translations.FirstOrDefault(t => t.Language == "en");
        if (enTranslation != null)
        {
            enTranslation.Title = model.EN.Title;
            enTranslation.ShortDescription = model.EN.ShortDescription;
            enTranslation.Country = model.EN.Country;
            enTranslation.Organization = model.EN.Organization;
            enTranslation.Status = model.EN.Status;
            enTranslation.CaseFullDescription = MapFullDescription(model.EN.FullDescription, enTranslation.CaseFullDescription);
        }

        await _caseRepo.UpdateAsync(c);
        return RedirectToAction("Index", "Case");
    }


    private CaseFullDescription MapFullDescription(CaseFullDescriptionViewModel vm, CaseFullDescription entity)
    {
        if (entity == null) entity = new CaseFullDescription();
        entity.MessageNumber = vm.MessageNumber;
        entity.Paragraph1 = vm.Paragraph1;
        entity.Paragraph2 = vm.Paragraph2;
        entity.Paragraph3 = vm.Paragraph3;
        entity.StatusText = vm.StatusText;
        entity.CaseType = vm.CaseType;
        entity.Section1Title = vm.Section1Title;
        entity.Section1Text = vm.Section1Text;
        entity.Quote = vm.Quote;
        entity.Note1 = vm.Note1;
        entity.Section2Title = vm.Section2Title;
        entity.Section2Text = vm.Section2Text;
        entity.ListTitle = vm.ListTitle;
        entity.ListItems = vm.ListItems;
        entity.Note2 = vm.Note2;
        entity.Note3 = vm.Note3;
        entity.DecisionTitle = vm.DecisionTitle;
        entity.DecisionText = vm.DecisionText;
        entity.DecisionLink = vm.DecisionLink;
        return entity;
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCase(int id)
    {
        await _caseRepo.DeleteWithTranslationsAsync(id); // кастомный метод репозитория
        return RedirectToAction("Index", "Case");
    }

}
