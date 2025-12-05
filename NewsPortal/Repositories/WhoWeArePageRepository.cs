using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Models;
using System.Linq;
using System.Threading.Tasks;

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
}
