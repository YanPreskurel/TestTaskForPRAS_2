using NewsPortal.Interfaces;
using NewsPortal.Models;

public interface ICaseRepository : IRepository<Case>
{
    Task<Case?> GetByIdWithTranslationsAsync(int id);
    Task<List<Case>> GetAllWithTranslationsAsync(string lang);
    Task DeleteWithTranslationsAsync(int id);

}