using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
    public class CaseRepository : ICaseRepository
    {
        private readonly AppDbContext _db;
        public CaseRepository(AppDbContext db) => _db = db;

        public async Task<List<Case>> GetAllWithTranslationsAsync(string lang)
        {
            return await _db.Cases
                            .Include(c => c.Translations)
                                .ThenInclude(t => t.CaseFullDescription)
                            .ToListAsync();
        }
    }
}
