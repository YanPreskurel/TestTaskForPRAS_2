using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Models;

public class CallToActionRepository : ICallToActionRepository
{
    private readonly AppDbContext _db;
    public CallToActionRepository(AppDbContext db) => _db = db;

    public async Task<CallToActionBlockTranslation?> GetFirstWithTranslationAsync(string lang)
    {
        var cta = await _db.CallToActionBlocks
                           .Include(c => c.Translations)
                           .FirstOrDefaultAsync();

        return cta?.Translations.FirstOrDefault(t => t.Language == lang)
               ?? cta?.Translations.FirstOrDefault();
    }

    public async Task UpdateTranslationAsync(int id, string lang, CallToActionBlockTranslation model)
    {
        var cta = await _db.CallToActionBlocks
            .Include(c => c.Translations)
            .FirstOrDefaultAsync(c => c.Id == id);

        if (cta == null) throw new Exception("CTA block not found");

        var translation = cta.Translations.FirstOrDefault(t => t.Language == lang);
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
    }
}