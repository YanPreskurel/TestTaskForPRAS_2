using Microsoft.EntityFrameworkCore;
using NewsPortal.Data;
using NewsPortal.Interfaces;
using System.Linq.Expressions;

namespace NewsPortal.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly AppDbContext _db;
        protected readonly DbSet<T> _table;

        public Repository(AppDbContext db)
        {
            _db = db;
            _table = db.Set<T>();
        }

        public virtual async Task<T?> GetByIdAsync(int id)
        {
            return await _table.FindAsync(id);
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _table.ToListAsync();
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            return await _table.Where(predicate).ToListAsync();
        }

        public virtual async Task AddAsync(T entity)
        {
            if (entity == null) throw new ArgumentNullException(nameof(entity));
            await _table.AddAsync(entity);
            await SaveAsync();
        }

        public virtual async Task UpdateAsync(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));
            _table.Update(entity);
            await SaveAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
                _table.Remove(entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
