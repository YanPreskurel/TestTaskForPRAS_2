using NewsPortal.Models;

namespace NewsPortal.Interfaces
{
    public interface ITagRepository : IRepository<Tag>
    {
        Task<Tag?> GetWithTranslationsAsync(int id);

        Task<List<Tag>> GetAllWithTranslationsAsync(string lang);
    }
}
