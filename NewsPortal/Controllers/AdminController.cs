using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Models;

public class AdminController : BaseController
{
    private readonly AppDbContext _db;

    public AdminController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Index()
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        // Страница "О нас"
        var whoWeAre = await _db.WhoWeArePages
                                .Include(p => p.Translations)
                                .FirstOrDefaultAsync();

        var whoWeAreTranslation = whoWeAre?.Translations.FirstOrDefault(t => t.Language == lang)
                                    ?? whoWeAre?.Translations.FirstOrDefault();

        // Кейсы
        var cases = await _db.Cases
                             .Include(c => c.Translations)
                             .ThenInclude(t => t.CaseFullDescription)
                             .ToListAsync();

        // Блок "Звонок / Call to Action"
        var cta = await _db.CallToActionBlocks
                           .Include(c => c.Translations)
                           .FirstOrDefaultAsync();

        var ctaTranslation = cta?.Translations.FirstOrDefault(t => t.Language == lang)
                            ?? cta?.Translations.FirstOrDefault();

        ViewBag.WhoWeAre = whoWeAreTranslation;
        ViewBag.Cases = cases;
        ViewBag.CTA = ctaTranslation;

        return View();
    }


    // GET: Редактировать страницу "О нас"
    public async Task<IActionResult> EditWhoWeAre(int id = 1, string lang = "ru")
    {
        var page = await _db.WhoWeArePages
            .Include(p => p.Translations)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (page == null) return NotFound();

        // Берём перевод по языку или первый доступный
        var translation = page.Translations.FirstOrDefault(t => t.Language == lang)
                          ?? page.Translations.FirstOrDefault();

        return View(translation); // Передаём только нужный перевод
    }

    // POST: Сохраняем изменения
    [HttpPost]
    public async Task<IActionResult> EditWhoWeAre(int id, string lang, WhoWeArePageTranslation model)
    {
        // Ищем существующий перевод
        var page = await _db.WhoWeArePages
            .Include(p => p.Translations)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (page == null) return NotFound();

        var translation = page.Translations.FirstOrDefault(t => t.Language == lang);

        if (translation == null)
        {
            // Если перевода нет – добавляем новый
            translation = new WhoWeArePageTranslation
            {
                WhoWeArePageId = id,
                Language = lang
            };
            page.Translations.Add(translation);
        }

        // Обновляем поля из формы
        translation.Title = model.Title;
        translation.Description1 = model.Description1;
        translation.Description2 = model.Description2;
        translation.SectionTitle = model.SectionTitle;
        translation.SectionText1 = model.SectionText1;
        translation.SectionText2 = model.SectionText2;

        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(EditWhoWeAre));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Logout(string returnUrl = "/")
    {
        await HttpContext.SignOutAsync("AdminCookie");
        return LocalRedirect(returnUrl);
    }


    public async Task<IActionResult> EditCTA(int id = 1)
    {
        var cta = await _db.CallToActionBlocks
                           .Include(c => c.Translations)
                           .FirstOrDefaultAsync();

        var lang = Request.Cookies["lang"] ?? "ru";
        var translation = cta?.Translations.FirstOrDefault(t => t.Language == lang)
                          ?? cta?.Translations.FirstOrDefault();

        if (translation == null) return NotFound();

        return View(translation);
    }

    [HttpPost]
    public async Task<IActionResult> EditCTA(int id, string lang, CallToActionBlockTranslation model)
    {
        var cta = await _db.CallToActionBlocks
                           .Include(c => c.Translations)
                           .FirstOrDefaultAsync();

        var translation = cta?.Translations.FirstOrDefault(t => t.Language == lang);
        if (translation == null)
        {
            translation = new CallToActionBlockTranslation
            {
                CallToActionBlockId = cta.Id,
                Language = lang
            };
            cta.Translations.Add(translation);
        }

        translation.Title = model.Title;
        translation.Text = model.Text;
        translation.ButtonText = model.ButtonText;

        await _db.SaveChangesAsync();
        return RedirectToAction("Index");
    }


}
