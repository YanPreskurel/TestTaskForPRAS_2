using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Interfaces;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        public TagRepository(AppDbContext db) : base(db) { }

        public async Task<Tag?> GetWithTranslationsAsync(int id)
        {
            return await _table
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Tag>> GetAllWithTranslationsAsync(string lang)
        {
            return await _db.Tags
                .Include(t => t.Translations)
                .Select(t => new Tag
                {
                    Id = t.Id,
                    Color = t.Color,
                    Translations = t.Translations
                        .Where(tr => tr.Language == lang)
                        .ToList()
                })
                .ToListAsync();
        }

    }
}
