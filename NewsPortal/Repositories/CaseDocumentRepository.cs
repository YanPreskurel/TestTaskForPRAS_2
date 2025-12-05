using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Interfaces;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
    public class CaseDocumentRepository : Repository<CaseDocument>, ICaseDocumentRepository
    {
        public CaseDocumentRepository(AppDbContext db) : base(db) { }

        public async Task<CaseDocument?> GetWithTranslationsAsync(int id)
        {
            return await _table
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<CaseDocument>> GetAllWithTranslationsAsync()
        {
            return await _db.CaseDocuments
                .Include(d => d.Translations)
                .ToListAsync();
        }
    }
}
