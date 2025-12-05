using NewsPortal.Models;

public interface IWhoWeArePageRepository
{
    Task<WhoWeArePageTranslation?> GetPageWithTranslationAsync(string lang);
    Task UpdateTranslationAsync(int pageId, string lang, WhoWeArePageTranslation model);
}
