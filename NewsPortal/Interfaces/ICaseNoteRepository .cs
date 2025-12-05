using NewsPortal.Models;

namespace NewsPortal.Interfaces
{
    public interface ICaseNoteRepository : IRepository<CaseNote>
    {
        Task<CaseNote?> GetWithTranslationsAsync(int id);

        Task<List<CaseNote>> GetAllWithTranslationsAsync();
    }
}
