using NewsPortal.Models;

namespace NewsPortal.Interfaces
{
    public interface ILawyerRepository : IRepository<Lawyer>
    {
        Task<Lawyer?> GetWithTranslationsAsync(int id);

        Task<List<Lawyer>> GetAllWithTranslationsAsync();
    }
}
