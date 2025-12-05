using NewsPortal.Models;

namespace NewsPortal.Interfaces
{
    public interface ICaseDocumentRepository : IRepository<CaseDocument>
    {
        Task<CaseDocument?> GetWithTranslationsAsync(int id);

        Task<List<CaseDocument>> GetAllWithTranslationsAsync();
    }
}
