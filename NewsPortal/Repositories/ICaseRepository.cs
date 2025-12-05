using NewsPortal.Models;

public interface ICaseRepository
{
    Task<List<Case>> GetAllWithTranslationsAsync(string lang);
}