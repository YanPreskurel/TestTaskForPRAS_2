using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Interfaces;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
    public class CaseNoteRepository : Repository<CaseNote>, ICaseNoteRepository
    {
        public CaseNoteRepository(AppDbContext db) : base(db) { }

        public async Task<CaseNote?> GetWithTranslationsAsync(int id)
        {
            return await _table
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CaseNote>> GetAllWithTranslationsAsync()
        {
            return await _db.CaseNotes
                .Include(n => n.Translations)
                .ToListAsync();
        }
    }
}
