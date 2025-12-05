using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;

public class CaseController : BaseController
{
    private readonly AppDbContext _db;

    public CaseController(AppDbContext db)
    {
        _db = db;
    }

    public async Task<IActionResult> Details(int id)
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        var item = await _db.Cases
            .Include(c => c.Translations)
                .ThenInclude(t => t.CaseFullDescription)
            .FirstOrDefaultAsync(x => x.Id == id);

        if (item == null)
            return NotFound();

        // Документы
        ViewBag.Documents = _db.CaseDocuments
            .Include(d => d.Translations)
            .ToList();

        // Теги
        ViewBag.Tags = _db.Tags
            .Include(t => t.Translations)
            .ToList();

        // 🔥 Адвокаты
        ViewBag.Lawyers = _db.Lawyers
            .Include(l => l.Translations)
            .ToList();

        // 🔥 Пояснения
        ViewBag.Notes = _db.CaseNotes
            .Include(n => n.Translations)
            .ToList();

        // Похожие кейсы
        ViewBag.Cases = _db.Cases.Include(c => c.Translations).Take(3).ToList();

        ViewBag.CTA = new
        {
            Title = "У вас есть вопрос?",
            Text = "Наша компания осуществляет поддержку и профессиональную юридическую консультацию имигрантам за границей",
            ButtonText = "Получить консультацию"
        };

        ViewBag.Lang = lang;
        return View(item);
    }



    public IActionResult Index()
    {
        var lang = Request.Cookies["lang"] ?? "ru";

        var cases = _db.Cases
                       .Include(c => c.Translations)
                       .ToList();

        ViewBag.Lang = lang;

        return View(cases);
    }

}
