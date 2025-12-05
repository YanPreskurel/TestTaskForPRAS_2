using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Models;

public class WhoWeArePageRepository : IWhoWeArePageRepository
{
    private readonly AppDbContext _db;
    public WhoWeArePageRepository(AppDbContext db) => _db = db;

    public async Task<WhoWeArePageTranslation?> GetPageWithTranslationAsync(string lang)
    {
        var page = await _db.WhoWeArePages
                            .Include(p => p.Translations)
                            .FirstOrDefaultAsync();

        return page?.Translations.FirstOrDefault(t => t.Language == lang)
               ?? page?.Translations.FirstOrDefault();
    }

    public async Task UpdateTranslationAsync(int pageId, string lang, WhoWeArePageTranslation model)
    {
        var page = await _db.WhoWeArePages
            .Include(p => p.Translations)
            .FirstOrDefaultAsync(p => p.Id == pageId);

        if (page == null) throw new Exception("Page not found");

        var translation = page.Translations.FirstOrDefault(t => t.Language == lang);
        if (translation == null)
        {
            translation = new WhoWeArePageTranslation
            {
                WhoWeArePageId = pageId,
                Language = lang
            };
            page.Translations.Add(translation);
        }

        translation.Title = model.Title;
        translation.Description1 = model.Description1;
        translation.Description2 = model.Description2;
        translation.SectionTitle = model.SectionTitle;
        translation.SectionText1 = model.SectionText1;
        translation.SectionText2 = model.SectionText2;

        await _db.SaveChangesAsync();
    }
}
