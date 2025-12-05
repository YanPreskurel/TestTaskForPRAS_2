using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
    public class CaseRepository : Repository<Case>, ICaseRepository
    {
        public CaseRepository(AppDbContext db) : base(db) { }

        public async Task<List<Case>> GetAllWithTranslationsAsync(string lang)
        {
            return (await _db.Cases
                            .Include(c => c.Translations)
                                .ThenInclude(t => t.CaseFullDescription)
                            .ToListAsync());
        }

        public async Task<Case?> GetByIdWithTranslationsAsync(int id)
        {
            return await _db.Cases
                .Include(c => c.Translations)
                    .ThenInclude(t => t.CaseFullDescription)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task DeleteWithTranslationsAsync(int id)
        {
            var c = await _db.Cases
                .Include(c => c.Translations)
                    .ThenInclude(t => t.CaseFullDescription)
                //.Include(c => c.Documents)
                //.Include(c => c.Tags)
                //.Include(c => c.Lawyers)
                //.Include(c => c.Notes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (c != null)
            {
                _db.Cases.Remove(c);
                await _db.SaveChangesAsync();
            }
        }

    }
}
