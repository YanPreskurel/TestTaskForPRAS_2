using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
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
    }
}
