using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Interfaces;
using NewsPortal.Models;

namespace NewsPortal.Repositories
{
    public class LawyerRepository : Repository<Lawyer>, ILawyerRepository
    {
        public LawyerRepository(AppDbContext db) : base(db) { }

        public async Task<Lawyer?> GetWithTranslationsAsync(int id)
        {
            return await _table
                .Include(x => x.Translations)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<Lawyer>> GetAllWithTranslationsAsync()
        {
            return await _db.Lawyers
                .Include(l => l.Translations)
                .ToListAsync();
        }
    }
}
